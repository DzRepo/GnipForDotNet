namespace PowerTrack.NET
{
    partial class frmPowerTrack
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPowerTrack));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldsToShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabRules = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgRules = new System.Windows.Forms.DataGridView();
            this.Rule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabStream = new System.Windows.Forms.TabPage();
            this.btnStreamToggle = new System.Windows.Forms.Button();
            this.dgvStream = new System.Windows.Forms.DataGridView();
            this.tabFieldChooser = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.clbTwitterEntities = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.clbGnip = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clbGenerator = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cblActor = new System.Windows.Forms.CheckedListBox();
            this.btnConfirmFieldChooser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.gbActivity = new System.Windows.Forms.GroupBox();
            this.cblActivity = new System.Windows.Forms.CheckedListBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbStreamName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAccountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabContainer.SuspendLayout();
            this.tabRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules)).BeginInit();
            this.tabStream.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStream)).BeginInit();
            this.tabFieldChooser.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbActivity.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.fileToolStripMenuItem.Text = "&Application";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(176, 30);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.validateToolStripMenuItem});
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(66, 29);
            this.rulesToolStripMenuItem.Text = "Rules";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.updateToolStripMenuItem.Text = "&Update";
            // 
            // validateToolStripMenuItem
            // 
            this.validateToolStripMenuItem.Name = "validateToolStripMenuItem";
            this.validateToolStripMenuItem.Size = new System.Drawing.Size(147, 30);
            this.validateToolStripMenuItem.Text = "&Validate";
            // 
            // streamToolStripMenuItem
            // 
            this.streamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.fieldsToShowToolStripMenuItem});
            this.streamToolStripMenuItem.Name = "streamToolStripMenuItem";
            this.streamToolStripMenuItem.Size = new System.Drawing.Size(80, 29);
            this.streamToolStripMenuItem.Text = "&Stream";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.startToolStripMenuItem.Size = new System.Drawing.Size(207, 30);
            this.startToolStripMenuItem.Text = "&Start / Stop";
            // 
            // fieldsToShowToolStripMenuItem
            // 
            this.fieldsToShowToolStripMenuItem.Name = "fieldsToShowToolStripMenuItem";
            this.fieldsToShowToolStripMenuItem.Size = new System.Drawing.Size(207, 30);
            this.fieldsToShowToolStripMenuItem.Text = "&Fields to Show";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 30);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 566);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(728, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsMessage
            // 
            this.tsMessage.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.tsMessage.ForeColor = System.Drawing.Color.Black;
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.Size = new System.Drawing.Size(168, 25);
            this.tsMessage.Text = "Messages go here...";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(537, 25);
            this.tsStatus.Spring = true;
            this.tsStatus.Text = "Status goes here...";
            this.tsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabSettings);
            this.tabContainer.Controls.Add(this.tabRules);
            this.tabContainer.Controls.Add(this.tabFieldChooser);
            this.tabContainer.Controls.Add(this.tabStream);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 24);
            this.tabContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(728, 542);
            this.tabContainer.TabIndex = 2;
            this.tabContainer.TabIndexChanged += new System.EventHandler(this.tabContainer_TabIndexChanged);
            // 
            // tabRules
            // 
            this.tabRules.BackColor = System.Drawing.Color.Gainsboro;
            this.tabRules.Controls.Add(this.button1);
            this.tabRules.Controls.Add(this.btnLoad);
            this.tabRules.Controls.Add(this.btnRefresh);
            this.tabRules.Controls.Add(this.btnUpdate);
            this.tabRules.Controls.Add(this.dgRules);
            this.tabRules.Location = new System.Drawing.Point(4, 29);
            this.tabRules.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabRules.Name = "tabRules";
            this.tabRules.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabRules.Size = new System.Drawing.Size(720, 509);
            this.tabRules.TabIndex = 0;
            this.tabRules.Text = "Rules";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(506, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(612, 459);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 32);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(722, 622);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(844, 622);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 35);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgRules
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dgRules.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgRules.BackgroundColor = System.Drawing.Color.Silver;
            this.dgRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rule});
            this.dgRules.Location = new System.Drawing.Point(4, 5);
            this.dgRules.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgRules.Name = "dgRules";
            this.dgRules.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgRules.RowHeadersWidth = 30;
            this.dgRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRules.Size = new System.Drawing.Size(708, 428);
            this.dgRules.TabIndex = 0;
            this.dgRules.CurrentCellChanged += new System.EventHandler(this.dgRules_CurrentCellChanged);
            // 
            // Rule
            // 
            this.Rule.DataPropertyName = "value";
            this.Rule.HeaderText = "Rule";
            this.Rule.Name = "Rule";
            this.Rule.Width = 67;
            // 
            // tabStream
            // 
            this.tabStream.BackColor = System.Drawing.Color.Gainsboro;
            this.tabStream.Controls.Add(this.btnStreamToggle);
            this.tabStream.Controls.Add(this.dgvStream);
            this.tabStream.Location = new System.Drawing.Point(4, 29);
            this.tabStream.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabStream.Name = "tabStream";
            this.tabStream.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabStream.Size = new System.Drawing.Size(720, 509);
            this.tabStream.TabIndex = 1;
            this.tabStream.Text = "Stream";
            // 
            // btnStreamToggle
            // 
            this.btnStreamToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStreamToggle.Location = new System.Drawing.Point(590, 459);
            this.btnStreamToggle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStreamToggle.Name = "btnStreamToggle";
            this.btnStreamToggle.Size = new System.Drawing.Size(112, 35);
            this.btnStreamToggle.TabIndex = 1;
            this.btnStreamToggle.Text = "Start";
            this.btnStreamToggle.UseVisualStyleBackColor = true;
            this.btnStreamToggle.Click += new System.EventHandler(this.btnStreamToggle_Click);
            // 
            // dgvStream
            // 
            this.dgvStream.AllowUserToAddRows = false;
            this.dgvStream.AllowUserToDeleteRows = false;
            this.dgvStream.AllowUserToOrderColumns = true;
            this.dgvStream.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStream.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStream.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStream.Location = new System.Drawing.Point(4, 9);
            this.dgvStream.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvStream.Name = "dgvStream";
            this.dgvStream.ReadOnly = true;
            this.dgvStream.Size = new System.Drawing.Size(706, 419);
            this.dgvStream.TabIndex = 0;
            this.dgvStream.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStream_DataError);
            // 
            // tabFieldChooser
            // 
            this.tabFieldChooser.BackColor = System.Drawing.Color.Silver;
            this.tabFieldChooser.Controls.Add(this.groupBox5);
            this.tabFieldChooser.Controls.Add(this.groupBox4);
            this.tabFieldChooser.Controls.Add(this.groupBox3);
            this.tabFieldChooser.Controls.Add(this.groupBox2);
            this.tabFieldChooser.Controls.Add(this.btnConfirmFieldChooser);
            this.tabFieldChooser.Controls.Add(this.label5);
            this.tabFieldChooser.Controls.Add(this.gbActivity);
            this.tabFieldChooser.Location = new System.Drawing.Point(4, 29);
            this.tabFieldChooser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabFieldChooser.Name = "tabFieldChooser";
            this.tabFieldChooser.Size = new System.Drawing.Size(720, 509);
            this.tabFieldChooser.TabIndex = 2;
            this.tabFieldChooser.Text = "Field Chooser";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Silver;
            this.groupBox5.Controls.Add(this.clbTwitterEntities);
            this.groupBox5.Location = new System.Drawing.Point(204, 199);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(183, 105);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Twitter Entities";
            // 
            // clbTwitterEntities
            // 
            this.clbTwitterEntities.BackColor = System.Drawing.Color.Silver;
            this.clbTwitterEntities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbTwitterEntities.FormattingEnabled = true;
            this.clbTwitterEntities.Items.AddRange(new object[] {
            "hashtags",
            "user_mentions",
            "urls"});
            this.clbTwitterEntities.Location = new System.Drawing.Point(10, 31);
            this.clbTwitterEntities.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clbTwitterEntities.Name = "clbTwitterEntities";
            this.clbTwitterEntities.Size = new System.Drawing.Size(164, 63);
            this.clbTwitterEntities.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Silver;
            this.groupBox4.Controls.Add(this.clbGnip);
            this.groupBox4.Location = new System.Drawing.Point(395, 145);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(183, 128);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gnip";
            // 
            // clbGnip
            // 
            this.clbGnip.BackColor = System.Drawing.Color.Silver;
            this.clbGnip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbGnip.FormattingEnabled = true;
            this.clbGnip.Items.AddRange(new object[] {
            "matching_rules",
            "klout_score",
            "klout_profile",
            "language"});
            this.clbGnip.Location = new System.Drawing.Point(10, 31);
            this.clbGnip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clbGnip.Name = "clbGnip";
            this.clbGnip.Size = new System.Drawing.Size(164, 84);
            this.clbGnip.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.clbGenerator);
            this.groupBox3.Location = new System.Drawing.Point(395, 52);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(183, 83);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generator";
            // 
            // clbGenerator
            // 
            this.clbGenerator.BackColor = System.Drawing.Color.Silver;
            this.clbGenerator.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbGenerator.FormattingEnabled = true;
            this.clbGenerator.Items.AddRange(new object[] {
            "displayName",
            "link"});
            this.clbGenerator.Location = new System.Drawing.Point(8, 29);
            this.clbGenerator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clbGenerator.Name = "clbGenerator";
            this.clbGenerator.Size = new System.Drawing.Size(164, 42);
            this.clbGenerator.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.cblActor);
            this.groupBox2.Location = new System.Drawing.Point(204, 52);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(183, 137);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actor";
            // 
            // cblActor
            // 
            this.cblActor.BackColor = System.Drawing.Color.Silver;
            this.cblActor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cblActor.FormattingEnabled = true;
            this.cblActor.Items.AddRange(new object[] {
            "id",
            "link",
            "displayName",
            "postedTime"});
            this.cblActor.Location = new System.Drawing.Point(10, 31);
            this.cblActor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cblActor.Name = "cblActor";
            this.cblActor.Size = new System.Drawing.Size(164, 84);
            this.cblActor.TabIndex = 0;
            // 
            // btnConfirmFieldChooser
            // 
            this.btnConfirmFieldChooser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmFieldChooser.Location = new System.Drawing.Point(592, 444);
            this.btnConfirmFieldChooser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConfirmFieldChooser.Name = "btnConfirmFieldChooser";
            this.btnConfirmFieldChooser.Size = new System.Drawing.Size(112, 35);
            this.btnConfirmFieldChooser.TabIndex = 2;
            this.btnConfirmFieldChooser.Text = "Confirm";
            this.btnConfirmFieldChooser.UseVisualStyleBackColor = true;
            this.btnConfirmFieldChooser.Click += new System.EventHandler(this.btnConfirmFieldChooser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(333, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Select fields of tweets to display in Stream tab";
            // 
            // gbActivity
            // 
            this.gbActivity.BackColor = System.Drawing.Color.Silver;
            this.gbActivity.Controls.Add(this.cblActivity);
            this.gbActivity.Location = new System.Drawing.Point(12, 52);
            this.gbActivity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbActivity.Name = "gbActivity";
            this.gbActivity.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbActivity.Size = new System.Drawing.Size(183, 208);
            this.gbActivity.TabIndex = 0;
            this.gbActivity.TabStop = false;
            this.gbActivity.Text = "Activity";
            // 
            // cblActivity
            // 
            this.cblActivity.BackColor = System.Drawing.Color.Silver;
            this.cblActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cblActivity.FormattingEnabled = true;
            this.cblActivity.Items.AddRange(new object[] {
            "id",
            "verb",
            "link",
            "body",
            "postedTime",
            "favoritesCount",
            "twitter_filter_level",
            "twitter_lang"});
            this.cblActivity.Location = new System.Drawing.Point(10, 31);
            this.cblActivity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cblActivity.Name = "cblActivity";
            this.cblActivity.Size = new System.Drawing.Size(164, 168);
            this.cblActivity.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Location = new System.Drawing.Point(4, 29);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSettings.Size = new System.Drawing.Size(720, 509);
            this.tabSettings.TabIndex = 4;
            this.tabSettings.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.tbStreamName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbAccountName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(699, 220);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Settings";
            // 
            // tbStreamName
            // 
            this.tbStreamName.BackColor = System.Drawing.SystemColors.Control;
            this.tbStreamName.Location = new System.Drawing.Point(141, 158);
            this.tbStreamName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbStreamName.Name = "tbStreamName";
            this.tbStreamName.Size = new System.Drawing.Size(175, 26);
            this.tbStreamName.TabIndex = 9;
            this.tbStreamName.TextChanged += new System.EventHandler(this.tbSettingTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stream Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.SystemColors.Control;
            this.tbPassword.Location = new System.Drawing.Point(141, 118);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(229, 26);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbSettingTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.SystemColors.Control;
            this.tbUsername.Location = new System.Drawing.Point(141, 78);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(229, 26);
            this.tbUsername.TabIndex = 5;
            this.tbUsername.TextChanged += new System.EventHandler(this.tbSettingTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "User Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbAccountName
            // 
            this.tbAccountName.BackColor = System.Drawing.SystemColors.Control;
            this.tbAccountName.Location = new System.Drawing.Point(141, 38);
            this.tbAccountName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAccountName.Name = "tbAccountName";
            this.tbAccountName.Size = new System.Drawing.Size(229, 26);
            this.tbAccountName.TabIndex = 3;
            this.tbAccountName.TextChanged += new System.EventHandler(this.tbSettingTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmPowerTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 588);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPowerTrack";
            this.Text = "PowerTrack.NET";
            this.tabContainer.ResumeLayout(false);
            this.tabRules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRules)).EndInit();
            this.tabStream.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStream)).EndInit();
            this.tabFieldChooser.ResumeLayout(false);
            this.tabFieldChooser.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbActivity.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldsToShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabRules;
        private System.Windows.Forms.TabPage tabStream;
        private System.Windows.Forms.TabPage tabFieldChooser;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.ToolStripStatusLabel tsMessage;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbStreamName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAccountName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rule;
        private System.Windows.Forms.DataGridView dgvStream;
        private System.Windows.Forms.GroupBox gbActivity;
        private System.Windows.Forms.CheckedListBox cblActivity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConfirmFieldChooser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox cblActor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clbGenerator;
        private System.Windows.Forms.Button btnStreamToggle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox clbGnip;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox clbTwitterEntities;
    }
}

