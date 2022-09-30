using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Reflection;

namespace SatPC32_Cloudlog_Interface
{

    public partial class Form1 : Form
    {
        public string AppStatus;

        public Form1()
        {
            InitializeComponent();

            textBox1.Text = ConfigurationManager.AppSettings["CloudlogURL"];
            textBox2.Text = ConfigurationManager.AppSettings["CloudlogAPIKey"];
            textBox3.Text = ConfigurationManager.AppSettings["CloudlogIdentifier"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_version.Text = "SatPC32-To-Cloudlog v"+ Assembly.GetExecutingAssembly().GetName().Version; ;
        }

        public void ThreadProc(Object stateInfo)
        {
             
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");

            NDde.Client.DdeClient client = new NDde.Client.DdeClient("SatPC32", "SatPcDdeConv");

            string identifier = "n/a";
            identifier = textBox3.Text;

            try
            {
                client.Connect();
                client.StartAdvise("SatPcDdeItem", 1, true, 60000);

                panel_status.Invoke((MethodInvoker)delegate {
                    panel_status.Visible = true;
                });

                while (true)
                {

                    if (AppStatus == "stopped")
                    {
                        client.Disconnect();
                        client.Dispose();
                        break;
                    }

                    string satdata = client.Request("SatPcDdeItem", 60000);

                    string[] words = satdata.Split(' ');

                    //Console.WriteLine(word);
                    string satname = "";
                    string frequency_rx = "";
                    string frequency = "";
                    string mode_rx = "";
                    string mode = "";

                    foreach (string word in words)
                    {
                        // Get Satellite Name
                        if (word.StartsWith("SN"))
                        {
                            satname = word.Remove(0, 2);
                        }
                        else if (word.StartsWith("AZ"))
                        {
                            string azimuth = word.Remove(0, 2);
                        }
                        else if (word.StartsWith("EL"))
                        {
                            string elevation = word.Remove(0, 2);
                        }
                        else if (word.StartsWith("UP"))
                        {
                            frequency = word.Remove(0, 2);
                        }
                        else if (word.StartsWith("UM"))
                        {
                            mode = word.Remove(0, 2);
                        }
                        else if (word.StartsWith("DN"))
                        {
                            frequency_rx = word.Remove(0, 2);
                        }
                        else if (word.StartsWith("DM"))
                        {
                            mode_rx = word.Remove(0, 2);
                        }

                        label_satname.Invoke((MethodInvoker)delegate {
                            label_satname.Text = satname;
                        });

                        label_uplink_freq.Invoke((MethodInvoker)delegate {
                            label_uplink_freq.Text = frequency;
                        });

                        label_downlink_freq.Invoke((MethodInvoker)delegate {
                            label_downlink_freq.Text = frequency_rx;
                        });

                        label_satmode_up.Invoke((MethodInvoker)delegate {
                            label_satmode_up.Text = mode;
                        });

                        label_satmode_down.Invoke((MethodInvoker)delegate {
                            label_satmode_down.Text = mode_rx;
                        });

                        label_cloudlog_status.Invoke((MethodInvoker)delegate {
                            label_cloudlog_status.Text = "Connected";
                        });

                        button1.Invoke((MethodInvoker)delegate {
                            button1.Text = "Stop SatPC32 <> Cloudlog Link";
                        });
                    }

                    using (WebClient cli = new WebClient())
                    {
                        try
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                            string response = cli.UploadString(textBox1.Text + "/index.php/api/radio", "{\"radio\":\"SatPC32 (" + identifier + ")\",\"frequency\":" + frequency + ",\"mode\":\"" + mode + "\",\"sat_name\":\"" + satname + "\",\"downlink_freq\":\"" + frequency_rx + "\",\"downlink_mode\":\"" + mode_rx + "\",\"key\":\"" + textBox2.Text +"\"}");
                            Console.WriteLine(response);
                            label_cloudlog_status.Invoke((MethodInvoker)delegate {
                                label_cloudlog_status.Text = "Connected";
                            });
                        }
                        catch (WebException e)
                        {
                            // ERROR: Application forced to stop the thread although buttons etc not activated.
                            label_cloudlog_status.Invoke((MethodInvoker)delegate {
                                label_cloudlog_status.Text = "Disconnected";
                            });

                            panel_status.Invoke((MethodInvoker)delegate {
                                panel_status.Visible = false;
                            });

                            button1.Invoke((MethodInvoker)delegate {
                                button1.Text = "SatPC32 <> Cloudlog Connect";
                            });

                            textBox1.Invoke((MethodInvoker)delegate {
                                textBox1.ReadOnly = false;
                            });

                            string text = "Lost connection to Cloudlog";
                            MessageBox.Show(text);

                            AppStatus = "stopped";

                            break;
                        }
                    }

                    System.Threading.Thread.Sleep(1000);
                }
            } catch
            {

                panel_status.Invoke((MethodInvoker)delegate {
                    panel_status.Visible = false;
                });

                button1.Invoke((MethodInvoker)delegate {
                    button1.Text = "SatPC32 <> Cloudlog Connect";
                });

                textBox1.Invoke((MethodInvoker)delegate {
                    textBox1.ReadOnly = false;
                });

                string text = "DDE Connection to SatPC32 Failed";
                MessageBox.Show(text);

                AppStatus = "stopped";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("CloudlogURL");
            config.AppSettings.Settings.Remove("CloudlogAPIKey");
            config.AppSettings.Settings.Remove("CloudlogIdentifier");
            config.AppSettings.Settings.Add("CloudlogURL", textBox1.Text);
            config.AppSettings.Settings.Add("CloudlogAPIKey", textBox2.Text);
            config.AppSettings.Settings.Add("CloudlogIdentifier", textBox3.Text);
            config.Save(ConfigurationSaveMode.Modified);

            if (AppStatus != "running")
            {
                textBox1.ReadOnly = true;
                ThreadPool.QueueUserWorkItem(ThreadProc);
                button1.Text = "SatPC32 <> Cloudlog Link Running";
                AppStatus = "running";
            } else {
                AppStatus = "stopped";
                button1.Text = "Stopped";
                textBox1.ReadOnly = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
