namespace Gnip.SearchDemo
{
    partial class frmSearchAndUsageDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchAndUsageDemo));
            this.btnGetResults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGetCounts = new System.Windows.Forms.Button();
            this.btnGetUsage = new System.Windows.Forms.Button();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAccountName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStreamName = new System.Windows.Forms.TextBox();
            this.tbMaxResults = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFromDate = new System.Windows.Forms.CheckBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lbFromDate = new System.Windows.Forms.Label();
            this.lbToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.cbToDate = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBucket = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnShowJson = new System.Windows.Forms.Button();
            this.gbSearchEndPoint = new System.Windows.Forms.GroupBox();
            this.rbFAS = new System.Windows.Forms.RadioButton();
            this.rb30Day = new System.Windows.Forms.RadioButton();
            this.gbSearchEndPoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetResults
            // 
            this.btnGetResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetResults.Location = new System.Drawing.Point(736, 240);
            this.btnGetResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetResults.Name = "btnGetResults";
            this.btnGetResults.Size = new System.Drawing.Size(125, 38);
            this.btnGetResults.TabIndex = 15;
            this.btnGetResults.Text = "Get Results";
            this.btnGetResults.UseVisualStyleBackColor = true;
            this.btnGetResults.Click += new System.EventHandler(this.btnGetResults_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Query:";
            // 
            // tbQuery
            // 
            this.tbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuery.Location = new System.Drawing.Point(128, 135);
            this.tbQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbQuery.Multiline = true;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(806, 94);
            this.tbQuery.TabIndex = 4;
            this.tbQuery.TextChanged += new System.EventHandler(this.tbQuery_TextChanged);
            // 
            // tbResults
            // 
            this.tbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResults.Location = new System.Drawing.Point(12, 329);
            this.tbResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResults.Size = new System.Drawing.Size(922, 247);
            this.tbResults.TabIndex = 18;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(811, 584);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 38);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGetCounts
            // 
            this.btnGetCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetCounts.Location = new System.Drawing.Point(736, 280);
            this.btnGetCounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetCounts.Name = "btnGetCounts";
            this.btnGetCounts.Size = new System.Drawing.Size(125, 38);
            this.btnGetCounts.TabIndex = 16;
            this.btnGetCounts.Text = "Get Counts";
            this.btnGetCounts.UseVisualStyleBackColor = true;
            this.btnGetCounts.Click += new System.EventHandler(this.btnGetCounts_Click);
            // 
            // btnGetUsage
            // 
            this.btnGetUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetUsage.Location = new System.Drawing.Point(813, 13);
            this.btnGetUsage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetUsage.Name = "btnGetUsage";
            this.btnGetUsage.Size = new System.Drawing.Size(125, 38);
            this.btnGetUsage.TabIndex = 100;
            this.btnGetUsage.Text = "Get Usage";
            this.btnGetUsage.UseVisualStyleBackColor = true;
            this.btnGetUsage.Click += new System.EventHandler(this.btnGetUsage_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(126, 38);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(178, 26);
            this.tbUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(126, 70);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(178, 26);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Account:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbAccountName
            // 
            this.tbAccountName.Location = new System.Drawing.Point(126, 6);
            this.tbAccountName.Name = "tbAccountName";
            this.tbAccountName.Size = new System.Drawing.Size(178, 26);
            this.tbAccountName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "EndPoint:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbStreamName
            // 
            this.tbStreamName.Location = new System.Drawing.Point(126, 102);
            this.tbStreamName.Name = "tbStreamName";
            this.tbStreamName.Size = new System.Drawing.Size(178, 26);
            this.tbStreamName.TabIndex = 3;
            // 
            // tbMaxResults
            // 
            this.tbMaxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMaxResults.Location = new System.Drawing.Point(678, 252);
            this.tbMaxResults.Name = "tbMaxResults";
            this.tbMaxResults.Size = new System.Drawing.Size(45, 26);
            this.tbMaxResults.TabIndex = 13;
            this.tbMaxResults.Text = "500";
            this.tbMaxResults.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(576, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Max Results";
            // 
            // cbFromDate
            // 
            this.cbFromDate.AutoSize = true;
            this.cbFromDate.Location = new System.Drawing.Point(9, 239);
            this.cbFromDate.Name = "cbFromDate";
            this.cbFromDate.Size = new System.Drawing.Size(22, 21);
            this.cbFromDate.TabIndex = 6;
            this.cbFromDate.UseVisualStyleBackColor = true;
            this.cbFromDate.CheckedChanged += new System.EventHandler(this.cbFromDate_CheckedChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "M/dd/yyyy - HH:mm";
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(128, 236);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(210, 26);
            this.dtpFromDate.TabIndex = 7;
            this.dtpFromDate.Value = new System.DateTime(2015, 8, 10, 13, 34, 50, 0);
            // 
            // lbFromDate
            // 
            this.lbFromDate.AutoSize = true;
            this.lbFromDate.Enabled = false;
            this.lbFromDate.Location = new System.Drawing.Point(37, 240);
            this.lbFromDate.Name = "lbFromDate";
            this.lbFromDate.Size = new System.Drawing.Size(85, 20);
            this.lbFromDate.TabIndex = 19;
            this.lbFromDate.Text = "From Date";
            this.lbFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbToDate
            // 
            this.lbToDate.AutoSize = true;
            this.lbToDate.Enabled = false;
            this.lbToDate.Location = new System.Drawing.Point(56, 269);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(66, 20);
            this.lbToDate.TabIndex = 22;
            this.lbToDate.Text = "To Date";
            this.lbToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "M/dd/yyyy - HH:mm";
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(128, 268);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(210, 26);
            this.dtpToDate.TabIndex = 9;
            this.dtpToDate.Value = new System.DateTime(2015, 8, 10, 13, 34, 57, 0);
            // 
            // cbToDate
            // 
            this.cbToDate.AutoSize = true;
            this.cbToDate.Location = new System.Drawing.Point(9, 269);
            this.cbToDate.Name = "cbToDate";
            this.cbToDate.Size = new System.Drawing.Size(22, 21);
            this.cbToDate.TabIndex = 8;
            this.cbToDate.UseVisualStyleBackColor = true;
            this.cbToDate.CheckedChanged += new System.EventHandler(this.cbToDate_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(576, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Bucket";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cbBucket
            // 
            this.cbBucket.AllowDrop = true;
            this.cbBucket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBucket.DisplayMember = "Day";
            this.cbBucket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBucket.FormattingEnabled = true;
            this.cbBucket.Items.AddRange(new object[] {
            "day",
            "hour",
            "minute"});
            this.cbBucket.Location = new System.Drawing.Point(641, 286);
            this.cbBucket.Name = "cbBucket";
            this.cbBucket.Size = new System.Drawing.Size(82, 28);
            this.cbBucket.TabIndex = 14;
            this.cbBucket.ValueMember = "Day";
            this.cbBucket.SelectedIndexChanged += new System.EventHandler(this.cbBucket_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Results";
            // 
            // btnShowJson
            // 
            this.btnShowJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowJson.Location = new System.Drawing.Point(867, 240);
            this.btnShowJson.Name = "btnShowJson";
            this.btnShowJson.Size = new System.Drawing.Size(66, 78);
            this.btnShowJson.TabIndex = 17;
            this.btnShowJson.Text = "Show JSON";
            this.btnShowJson.UseVisualStyleBackColor = true;
            this.btnShowJson.Click += new System.EventHandler(this.btnShowJson_Click);
            // 
            // gbSearchEndPoint
            // 
            this.gbSearchEndPoint.Controls.Add(this.rbFAS);
            this.gbSearchEndPoint.Controls.Add(this.rb30Day);
            this.gbSearchEndPoint.Location = new System.Drawing.Point(356, 236);
            this.gbSearchEndPoint.Name = "gbSearchEndPoint";
            this.gbSearchEndPoint.Size = new System.Drawing.Size(200, 89);
            this.gbSearchEndPoint.TabIndex = 10;
            this.gbSearchEndPoint.TabStop = false;
            this.gbSearchEndPoint.Text = "Search Endpoint";
            this.gbSearchEndPoint.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbFAS
            // 
            this.rbFAS.AutoSize = true;
            this.rbFAS.Checked = true;
            this.rbFAS.Location = new System.Drawing.Point(7, 57);
            this.rbFAS.Name = "rbFAS";
            this.rbFAS.Size = new System.Drawing.Size(170, 24);
            this.rbFAS.TabIndex = 12;
            this.rbFAS.TabStop = true;
            this.rbFAS.Text = "Full Archive Search";
            this.rbFAS.UseVisualStyleBackColor = true;
            // 
            // rb30Day
            // 
            this.rb30Day.AutoSize = true;
            this.rb30Day.Location = new System.Drawing.Point(7, 28);
            this.rb30Day.Name = "rb30Day";
            this.rb30Day.Size = new System.Drawing.Size(140, 24);
            this.rb30Day.TabIndex = 11;
            this.rb30Day.TabStop = true;
            this.rb30Day.Text = "30-Day Search";
            this.rb30Day.UseVisualStyleBackColor = true;
            // 
            // frmSearchAndUsageDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 635);
            this.Controls.Add(this.gbSearchEndPoint);
            this.Controls.Add(this.btnShowJson);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbBucket);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.cbToDate);
            this.Controls.Add(this.lbFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cbFromDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbMaxResults);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbStreamName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbAccountName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.btnGetUsage);
            this.Controls.Add(this.btnGetCounts);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.tbQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(770, 500);
            this.Name = "frmSearchAndUsageDemo";
            this.Text = "SearchAPI & UsageAPI Demo";
            this.gbSearchEndPoint.ResumeLayout(false);
            this.gbSearchEndPoint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGetCounts;
        private System.Windows.Forms.Button btnGetUsage;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAccountName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStreamName;
        private System.Windows.Forms.TextBox tbMaxResults;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lbFromDate;
        private System.Windows.Forms.Label lbToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.CheckBox cbToDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBucket;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnShowJson;
        private System.Windows.Forms.GroupBox gbSearchEndPoint;
        private System.Windows.Forms.RadioButton rbFAS;
        private System.Windows.Forms.RadioButton rb30Day;
    }
}

