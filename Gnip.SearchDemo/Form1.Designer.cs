namespace Gnip.SearchDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGetResults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGetCounts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetResults
            // 
            this.btnGetResults.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetResults.Location = new System.Drawing.Point(833, 121);
            this.btnGetResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetResults.Name = "btnGetResults";
            this.btnGetResults.Size = new System.Drawing.Size(125, 38);
            this.btnGetResults.TabIndex = 0;
            this.btnGetResults.Text = "Get Results";
            this.btnGetResults.UseVisualStyleBackColor = true;
            this.btnGetResults.Click += new System.EventHandler(this.btnGetResults_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Query";
            // 
            // tbQuery
            // 
            this.tbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuery.Location = new System.Drawing.Point(75, 130);
            this.tbQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(744, 26);
            this.tbQuery.TabIndex = 2;
            // 
            // tbResults
            // 
            this.tbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResults.Location = new System.Drawing.Point(14, 167);
            this.tbResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResults.Size = new System.Drawing.Size(1074, 466);
            this.tbResults.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(964, 647);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(125, 38);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGetCounts
            // 
            this.btnGetCounts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetCounts.Location = new System.Drawing.Point(964, 121);
            this.btnGetCounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetCounts.Name = "btnGetCounts";
            this.btnGetCounts.Size = new System.Drawing.Size(125, 38);
            this.btnGetCounts.TabIndex = 5;
            this.btnGetCounts.Text = "Get Counts";
            this.btnGetCounts.UseVisualStyleBackColor = true;
            this.btnGetCounts.Click += new System.EventHandler(this.btnGetCounts_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 698);
            this.Controls.Add(this.btnGetCounts);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.tbQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "SearchAPI Demo";
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
    }
}

