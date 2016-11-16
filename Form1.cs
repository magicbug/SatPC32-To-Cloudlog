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

namespace SatPC32_Cloudlog_Interface
{

    public partial class Form1 : Form
    {
        public string AppStatus;

        public Form1()
        {
            InitializeComponent();

            textBox1.Text = ConfigurationManager.AppSettings["CloudlogURL"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ThreadProc(Object stateInfo)
        {
             
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");

            NDde.Client.DdeClient client = new NDde.Client.DdeClient("SatPC32", "SatPcDdeConv");
            client.Connect();
            client.StartAdvise("SatPcDdeItem", 1, true, 60000);

            while (true)
            {
                if(AppStatus == "stopped")
                {
                    client.Disconnect();
                    client.Dispose();
                    break;
                }
                string satdata = client.Request("SatPcDdeItem", 60000);

                string[] words = satdata.Split(' ');

                //Console.WriteLine(word);
                string satname = "";
                string downlink_freq = "";
                string uplink_freq = "";
                string downlink_mode = "";
                string uplink_mode = "";

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
                        uplink_freq = word.Remove(0, 2);
                    }
                    else if (word.StartsWith("UM"))
                    {
                        uplink_mode = word.Remove(0, 2);
                    }
                    else if (word.StartsWith("DN"))
                    {
                        downlink_freq = word.Remove(0, 2);
                    }
                    else if (word.StartsWith("DM"))
                    {
                        downlink_mode = word.Remove(0, 2);
                    }
                }

                var cli = new WebClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                string response = cli.UploadString(textBox1.Text + "/index.php/api/radio", "{\"radio\":\"SatPC32\",\"frequency\":0,\"mode\":\"non\",\"sat_name\":\"" + satname + "\",\"downlink_freq\":\"" + downlink_freq + "\",\"uplink_freq\":\"" + uplink_freq + "\",\"downlink_mode\":\"" + downlink_mode + "\",\"uplink_mode\":\"" + uplink_mode + "\",\"timestamp\":\"2012 / 04 / 07 16:47\"}");
                Console.WriteLine(response);

                System.Threading.Thread.Sleep(1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("CloudlogURL");
            config.AppSettings.Settings.Add("CloudlogURL", textBox1.Text);
            config.Save(ConfigurationSaveMode.Modified);

            if (AppStatus != "running")
            {
                ThreadPool.QueueUserWorkItem(ThreadProc);
                button1.Text = "SatPC32 & Cloudlog Link Running";
                AppStatus = "running";
            } else {
                AppStatus = "stopped";
                button1.Text = "Stopped";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
