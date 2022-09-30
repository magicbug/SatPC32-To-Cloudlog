namespace SatPC32_Cloudlog_Interface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel_status = new System.Windows.Forms.Panel();
            this.label_cloudlog_status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_downlink_freq = new System.Windows.Forms.Label();
            this.label_uplink_freq = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_satmode_down = new System.Windows.Forms.Label();
            this.label_satmode_up = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_satname = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(18, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(303, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cloudlog Website Address:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel_status
            // 
            this.panel_status.Controls.Add(this.label_cloudlog_status);
            this.panel_status.Controls.Add(this.label5);
            this.panel_status.Controls.Add(this.label_downlink_freq);
            this.panel_status.Controls.Add(this.label_uplink_freq);
            this.panel_status.Controls.Add(this.label4);
            this.panel_status.Controls.Add(this.label_satmode_down);
            this.panel_status.Controls.Add(this.label_satmode_up);
            this.panel_status.Controls.Add(this.label3);
            this.panel_status.Controls.Add(this.label2);
            this.panel_status.Controls.Add(this.label_satname);
            this.panel_status.Location = new System.Drawing.Point(18, 175);
            this.panel_status.Name = "panel_status";
            this.panel_status.Size = new System.Drawing.Size(303, 108);
            this.panel_status.TabIndex = 4;
            this.panel_status.Visible = false;
            this.panel_status.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label_cloudlog_status
            // 
            this.label_cloudlog_status.AutoSize = true;
            this.label_cloudlog_status.Location = new System.Drawing.Point(98, 84);
            this.label_cloudlog_status.Name = "label_cloudlog_status";
            this.label_cloudlog_status.Size = new System.Drawing.Size(60, 13);
            this.label_cloudlog_status.TabIndex = 9;
            this.label_cloudlog_status.Text = "Link Status";
            this.label_cloudlog_status.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cloudlog Link:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label_downlink_freq
            // 
            this.label_downlink_freq.AutoSize = true;
            this.label_downlink_freq.Location = new System.Drawing.Point(175, 39);
            this.label_downlink_freq.Name = "label_downlink_freq";
            this.label_downlink_freq.Size = new System.Drawing.Size(75, 13);
            this.label_downlink_freq.TabIndex = 7;
            this.label_downlink_freq.Text = "Downlink Freq";
            // 
            // label_uplink_freq
            // 
            this.label_uplink_freq.AutoSize = true;
            this.label_uplink_freq.Location = new System.Drawing.Point(98, 39);
            this.label_uplink_freq.Name = "label_uplink_freq";
            this.label_uplink_freq.Size = new System.Drawing.Size(45, 13);
            this.label_uplink_freq.TabIndex = 6;
            this.label_uplink_freq.Text = "Up Freq";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Satellite Freq:";
            // 
            // label_satmode_down
            // 
            this.label_satmode_down.AutoSize = true;
            this.label_satmode_down.Location = new System.Drawing.Point(175, 53);
            this.label_satmode_down.Name = "label_satmode_down";
            this.label_satmode_down.Size = new System.Drawing.Size(84, 13);
            this.label_satmode_down.TabIndex = 4;
            this.label_satmode_down.Text = "Sat Mode Down";
            // 
            // label_satmode_up
            // 
            this.label_satmode_up.AutoSize = true;
            this.label_satmode_up.Location = new System.Drawing.Point(98, 53);
            this.label_satmode_up.Name = "label_satmode_up";
            this.label_satmode_up.Size = new System.Drawing.Size(70, 13);
            this.label_satmode_up.TabIndex = 3;
            this.label_satmode_up.Text = "Sat Mode Up";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(14, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Satellite Mode:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Satellite Name:";
            // 
            // label_satname
            // 
            this.label_satname.AutoSize = true;
            this.label_satname.Location = new System.Drawing.Point(98, 12);
            this.label_satname.Name = "label_satname";
            this.label_satname.Size = new System.Drawing.Size(54, 13);
            this.label_satname.TabIndex = 0;
            this.label_satname.Text = "Sat Name";
            this.label_satname.Click += new System.EventHandler(this.label2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cloudlog API Key:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(18, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(303, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Cloudlog Identifier:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(18, 103);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(303, 20);
            this.textBox3.TabIndex = 8;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(333, 295);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel_status);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "SatPC32 <> Cloudlog Interface";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_status.ResumeLayout(false);
            this.panel_status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel_status;
        private System.Windows.Forms.Label label_satname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_satmode_up;
        private System.Windows.Forms.Label label_satmode_down;
        private System.Windows.Forms.Label label_downlink_freq;
        private System.Windows.Forms.Label label_uplink_freq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_cloudlog_status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
    }
}

