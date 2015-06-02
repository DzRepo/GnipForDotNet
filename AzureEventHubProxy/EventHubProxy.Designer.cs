namespace AzureEventHubProxy
{
    partial class EventHubProxy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventHubProxy));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblActivitiesReceived = new System.Windows.Forms.Label();
            this.lblEventsSent = new System.Windows.Forms.Label();
            this.tbMessages = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblThreadCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHandles = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "This application acts as a proxy between a Gnip PowerTrack stream and Azure Event" +
    " Bus";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of Activities received";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of Events sent";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStartStop.Location = new System.Drawing.Point(0, 424);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(477, 47);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblActivitiesReceived
            // 
            this.lblActivitiesReceived.AutoSize = true;
            this.lblActivitiesReceived.Location = new System.Drawing.Point(232, 109);
            this.lblActivitiesReceived.Name = "lblActivitiesReceived";
            this.lblActivitiesReceived.Size = new System.Drawing.Size(18, 20);
            this.lblActivitiesReceived.TabIndex = 4;
            this.lblActivitiesReceived.Text = "0";
            // 
            // lblEventsSent
            // 
            this.lblEventsSent.AutoSize = true;
            this.lblEventsSent.Location = new System.Drawing.Point(232, 130);
            this.lblEventsSent.Name = "lblEventsSent";
            this.lblEventsSent.Size = new System.Drawing.Size(18, 20);
            this.lblEventsSent.TabIndex = 5;
            this.lblEventsSent.Text = "0";
            // 
            // tbMessages
            // 
            this.tbMessages.Location = new System.Drawing.Point(0, 233);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.ReadOnly = true;
            this.tbMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMessages.Size = new System.Drawing.Size(477, 170);
            this.tbMessages.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Messages:";
            // 
            // lblThreadCount
            // 
            this.lblThreadCount.AutoSize = true;
            this.lblThreadCount.Location = new System.Drawing.Point(232, 150);
            this.lblThreadCount.Name = "lblThreadCount";
            this.lblThreadCount.Size = new System.Drawing.Size(18, 20);
            this.lblThreadCount.TabIndex = 9;
            this.lblThreadCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Number of current threads";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHandles
            // 
            this.lblHandles.AutoSize = true;
            this.lblHandles.Location = new System.Drawing.Point(232, 170);
            this.lblHandles.Name = "lblHandles";
            this.lblHandles.Size = new System.Drawing.Size(18, 20);
            this.lblHandles.TabIndex = 11;
            this.lblHandles.Text = "0";
            this.lblHandles.Click += new System.EventHandler(this.label5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Number of current handles";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // EventHubProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 471);
            this.Controls.Add(this.lblHandles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblThreadCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.lblEventsSent);
            this.Controls.Add(this.lblActivitiesReceived);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EventHubProxy";
            this.Text = "Gnip -> Azure Event Hub Proxy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblActivitiesReceived;
        private System.Windows.Forms.Label lblEventsSent;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThreadCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHandles;
        private System.Windows.Forms.Label label7;

    }
}

