namespace LBFVideoLib.Client
{
    partial class frmUpCommingVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpCommingVideo));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Urdu");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("First-S1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("First", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Maths");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Second-S1", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Hindi");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Second-S2", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Second", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("English");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Third-S1", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Third", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Classes", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode8,
            treeNode11});
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.btnFastForward = new System.Windows.Forms.Button();
            this.btnRewind = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblWatchCount = new System.Windows.Forms.Label();
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.pnlSep = new System.Windows.Forms.Panel();
            this.pnlUpcomingVideo = new System.Windows.Forms.Panel();
            this.flowLayoutPanelUpcoming = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUpcomming = new System.Windows.Forms.Label();
            this.pnlPreviousVideo = new System.Windows.Forms.Panel();
            this.flowLayoutPanelPrevious = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeading = new System.Windows.Forms.Panel();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlBottome = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblVersionNo = new System.Windows.Forms.Label();
            this.lblPrivacyPolicy = new System.Windows.Forms.Label();
            this.lblExpireDate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSessionYears = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlMain.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlVideo.SuspendLayout();
            this.pnlUpcomingVideo.SuspendLayout();
            this.pnlPreviousVideo.SuspendLayout();
            this.pnlHeading.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.panel9);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.panel4);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1349, 749);
            this.pnlMain.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.progressBar1);
            this.panel9.Controls.Add(this.axWindowsMediaPlayer1);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.panel8);
            this.panel9.Controls.Add(this.pnlVideo);
            this.panel9.Controls.Add(this.pnlHeading);
            this.panel9.Controls.Add(this.pnlBottome);
            this.panel9.Controls.Add(this.pnlTop);
            this.panel9.Controls.Add(this.pnlRight);
            this.panel9.Controls.Add(this.pnlLeft);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(320, 48);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1029, 658);
            this.panel9.TabIndex = 39;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(411, 172);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 26);
            this.progressBar1.TabIndex = 7;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(28, 42);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(977, 395);
            this.axWindowsMediaPlayer1.TabIndex = 68;
            this.axWindowsMediaPlayer1.KeyDownEvent += new AxWMPLib._WMPOCXEvents_KeyDownEventHandler(this.axWindowsMediaPlayer1_KeyDownEvent);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnFullScreen);
            this.panel10.Controls.Add(this.btnFastForward);
            this.panel10.Controls.Add(this.btnRewind);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(28, 437);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(977, 35);
            this.panel10.TabIndex = 67;
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.BackColor = System.Drawing.Color.White;
            this.btnFullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFullScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFullScreen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFullScreen.Location = new System.Drawing.Point(98, 0);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(767, 35);
            this.btnFullScreen.TabIndex = 5;
            this.btnFullScreen.Text = "Full Screen (F11)";
            this.btnFullScreen.UseVisualStyleBackColor = false;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click_1);
            // 
            // btnFastForward
            // 
            this.btnFastForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFastForward.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFastForward.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFastForward.Image = ((System.Drawing.Image)(resources.GetObject("btnFastForward.Image")));
            this.btnFastForward.Location = new System.Drawing.Point(865, 0);
            this.btnFastForward.Name = "btnFastForward";
            this.btnFastForward.Size = new System.Drawing.Size(112, 35);
            this.btnFastForward.TabIndex = 4;
            this.btnFastForward.UseVisualStyleBackColor = true;
            this.btnFastForward.Click += new System.EventHandler(this.btnFastForward_Click);
            // 
            // btnRewind
            // 
            this.btnRewind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRewind.BackgroundImage")));
            this.btnRewind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRewind.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRewind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRewind.Image = ((System.Drawing.Image)(resources.GetObject("btnRewind.Image")));
            this.btnRewind.Location = new System.Drawing.Point(0, 0);
            this.btnRewind.Margin = new System.Windows.Forms.Padding(0);
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Size = new System.Drawing.Size(98, 35);
            this.btnRewind.TabIndex = 3;
            this.btnRewind.UseVisualStyleBackColor = true;
            this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblWatchCount);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(28, 472);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(977, 25);
            this.panel8.TabIndex = 66;
            // 
            // lblWatchCount
            // 
            this.lblWatchCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWatchCount.BackColor = System.Drawing.Color.White;
            this.lblWatchCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWatchCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblWatchCount.Location = new System.Drawing.Point(806, 5);
            this.lblWatchCount.Name = "lblWatchCount";
            this.lblWatchCount.Size = new System.Drawing.Size(170, 17);
            this.lblWatchCount.TabIndex = 12;
            this.lblWatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlVideo
            // 
            this.pnlVideo.Controls.Add(this.pnlSep);
            this.pnlVideo.Controls.Add(this.pnlUpcomingVideo);
            this.pnlVideo.Controls.Add(this.pnlPreviousVideo);
            this.pnlVideo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlVideo.Location = new System.Drawing.Point(28, 497);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(977, 150);
            this.pnlVideo.TabIndex = 65;
            // 
            // pnlSep
            // 
            this.pnlSep.BackColor = System.Drawing.Color.LightGray;
            this.pnlSep.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSep.Location = new System.Drawing.Point(481, 0);
            this.pnlSep.Name = "pnlSep";
            this.pnlSep.Size = new System.Drawing.Size(2, 150);
            this.pnlSep.TabIndex = 67;
            this.pnlSep.Visible = false;
            // 
            // pnlUpcomingVideo
            // 
            this.pnlUpcomingVideo.Controls.Add(this.flowLayoutPanelUpcoming);
            this.pnlUpcomingVideo.Controls.Add(this.lblUpcomming);
            this.pnlUpcomingVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpcomingVideo.Location = new System.Drawing.Point(481, 0);
            this.pnlUpcomingVideo.Name = "pnlUpcomingVideo";
            this.pnlUpcomingVideo.Size = new System.Drawing.Size(496, 150);
            this.pnlUpcomingVideo.TabIndex = 65;
            // 
            // flowLayoutPanelUpcoming
            // 
            this.flowLayoutPanelUpcoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelUpcoming.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelUpcoming.Location = new System.Drawing.Point(0, 22);
            this.flowLayoutPanelUpcoming.Name = "flowLayoutPanelUpcoming";
            this.flowLayoutPanelUpcoming.Size = new System.Drawing.Size(496, 128);
            this.flowLayoutPanelUpcoming.TabIndex = 63;
            // 
            // lblUpcomming
            // 
            this.lblUpcomming.BackColor = System.Drawing.Color.White;
            this.lblUpcomming.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUpcomming.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomming.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblUpcomming.Location = new System.Drawing.Point(0, 0);
            this.lblUpcomming.Name = "lblUpcomming";
            this.lblUpcomming.Size = new System.Drawing.Size(496, 22);
            this.lblUpcomming.TabIndex = 10;
            this.lblUpcomming.Text = "Upcoming Videos";
            this.lblUpcomming.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlPreviousVideo
            // 
            this.pnlPreviousVideo.Controls.Add(this.flowLayoutPanelPrevious);
            this.pnlPreviousVideo.Controls.Add(this.label1);
            this.pnlPreviousVideo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPreviousVideo.Location = new System.Drawing.Point(0, 0);
            this.pnlPreviousVideo.Name = "pnlPreviousVideo";
            this.pnlPreviousVideo.Size = new System.Drawing.Size(481, 150);
            this.pnlPreviousVideo.TabIndex = 64;
            // 
            // flowLayoutPanelPrevious
            // 
            this.flowLayoutPanelPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPrevious.Location = new System.Drawing.Point(0, 22);
            this.flowLayoutPanelPrevious.Name = "flowLayoutPanelPrevious";
            this.flowLayoutPanelPrevious.Size = new System.Drawing.Size(481, 128);
            this.flowLayoutPanelPrevious.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Previous Videos";
            // 
            // pnlHeading
            // 
            this.pnlHeading.Controls.Add(this.lblFileName);
            this.pnlHeading.Controls.Add(this.lblWelcome);
            this.pnlHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeading.Location = new System.Drawing.Point(28, 10);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(977, 32);
            this.pnlHeading.TabIndex = 61;
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.BackColor = System.Drawing.Color.White;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblFileName.Location = new System.Drawing.Point(615, 0);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFileName.Size = new System.Drawing.Size(358, 20);
            this.lblFileName.TabIndex = 11;
            this.lblFileName.Text = "  ";
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoEllipsis = true;
            this.lblWelcome.BackColor = System.Drawing.Color.White;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblWelcome.Location = new System.Drawing.Point(1, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(608, 23);
            this.lblWelcome.TabIndex = 7;
            this.lblWelcome.Text = "  ";
            // 
            // pnlBottome
            // 
            this.pnlBottome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottome.Location = new System.Drawing.Point(28, 647);
            this.pnlBottome.Name = "pnlBottome";
            this.pnlBottome.Size = new System.Drawing.Size(977, 11);
            this.pnlBottome.TabIndex = 45;
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(28, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(977, 10);
            this.pnlTop.TabIndex = 44;
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1005, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(24, 658);
            this.pnlRight.TabIndex = 43;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(28, 658);
            this.pnlLeft.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.pnlLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 658);
            this.panel1.TabIndex = 25;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.treeView1.Location = new System.Drawing.Point(0, 267);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node12";
            treeNode1.Text = "Urdu";
            treeNode2.Name = "Node2";
            treeNode2.Text = "First-S1";
            treeNode3.Name = "Node1";
            treeNode3.Text = "First";
            treeNode4.Name = "Node11";
            treeNode4.Text = "Maths";
            treeNode5.Name = "Node4";
            treeNode5.Text = "Second-S1";
            treeNode6.Name = "Node10";
            treeNode6.Text = "Hindi";
            treeNode7.Name = "Node5";
            treeNode7.Text = "Second-S2";
            treeNode8.Name = "Node3";
            treeNode8.Text = "Second";
            treeNode9.Name = "Node9";
            treeNode9.Text = "English";
            treeNode10.Name = "Node8";
            treeNode10.Text = "Third-S1";
            treeNode11.Name = "Node7";
            treeNode11.Text = "Third";
            treeNode12.Name = "Node0";
            treeNode12.Text = "Classes";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.treeView1.Size = new System.Drawing.Size(318, 389);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.White;
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlLogo.Controls.Add(this.pictureBox1);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(318, 267);
            this.pnlLogo.TabIndex = 1;
            this.pnlLogo.Click += new System.EventHandler(this.pnlLogo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(318, 267);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel4.Controls.Add(this.lblVersionNo);
            this.panel4.Controls.Add(this.lblPrivacyPolicy);
            this.panel4.Controls.Add(this.lblExpireDate);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 706);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1349, 43);
            this.panel4.TabIndex = 24;
            // 
            // lblVersionNo
            // 
            this.lblVersionNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblVersionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblVersionNo.ForeColor = System.Drawing.Color.White;
            this.lblVersionNo.Location = new System.Drawing.Point(38, 11);
            this.lblVersionNo.Name = "lblVersionNo";
            this.lblVersionNo.Size = new System.Drawing.Size(129, 16);
            this.lblVersionNo.TabIndex = 23;
            this.lblVersionNo.Text = "Version 1.0";
            this.lblVersionNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrivacyPolicy
            // 
            this.lblPrivacyPolicy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPrivacyPolicy.AutoSize = true;
            this.lblPrivacyPolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivacyPolicy.ForeColor = System.Drawing.Color.White;
            this.lblPrivacyPolicy.Location = new System.Drawing.Point(1230, 11);
            this.lblPrivacyPolicy.Name = "lblPrivacyPolicy";
            this.lblPrivacyPolicy.Size = new System.Drawing.Size(107, 16);
            this.lblPrivacyPolicy.TabIndex = 4;
            this.lblPrivacyPolicy.Text = "Privacy Policy";
            this.lblPrivacyPolicy.Click += new System.EventHandler(this.lblPrivacyPolicy_Click);
            // 
            // lblExpireDate
            // 
            this.lblExpireDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpireDate.AutoSize = true;
            this.lblExpireDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpireDate.ForeColor = System.Drawing.Color.White;
            this.lblExpireDate.Location = new System.Drawing.Point(63, 11);
            this.lblExpireDate.Name = "lblExpireDate";
            this.lblExpireDate.Size = new System.Drawing.Size(105, 16);
            this.lblExpireDate.TabIndex = 3;
            this.lblExpireDate.Text = "Expires on {0}";
            this.lblExpireDate.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(579, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(337, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "LBF Publications Pvt. Ltd. |  All Rights Reserved";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.lblSessionYears);
            this.panel2.Controls.Add(this.lblAppTitle);
            this.panel2.Controls.Add(this.lblContact);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1349, 48);
            this.panel2.TabIndex = 12;
            // 
            // lblSessionYears
            // 
            this.lblSessionYears.AutoSize = true;
            this.lblSessionYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionYears.ForeColor = System.Drawing.Color.White;
            this.lblSessionYears.Location = new System.Drawing.Point(22, 15);
            this.lblSessionYears.Name = "lblSessionYears";
            this.lblSessionYears.Size = new System.Drawing.Size(115, 24);
            this.lblSessionYears.TabIndex = 6;
            this.lblSessionYears.Text = "Session {0}";
            this.lblSessionYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAppTitle.AutoEllipsis = true;
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(318, 13);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(22, 24);
            this.lblAppTitle.TabIndex = 5;
            this.lblAppTitle.Text = "  ";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContact
            // 
            this.lblContact.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.White;
            this.lblContact.Location = new System.Drawing.Point(1244, 13);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(80, 24);
            this.lblContact.TabIndex = 4;
            this.lblContact.Text = "Contact";
            this.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContact.Click += new System.EventHandler(this.lblContact_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmUpCommingVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 749);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUpCommingVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LBF AR Books";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpCommingVideo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUpCommingVideo_FormClosed);
            this.Load += new System.EventHandler(this.frmUpCommingVideo_Load);
            this.VisibleChanged += new System.EventHandler(this.frmUpCommingVideo_VisibleChanged);
            this.pnlMain.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.pnlVideo.ResumeLayout(false);
            this.pnlUpcomingVideo.ResumeLayout(false);
            this.pnlPreviousVideo.ResumeLayout(false);
            this.pnlHeading.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblExpireDate;
        private System.Windows.Forms.Label lblSessionYears;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlBottome;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlHeading;
        private System.Windows.Forms.Label lblWelcome;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Button btnFastForward;
        private System.Windows.Forms.Button btnRewind;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.Panel pnlUpcomingVideo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUpcoming;
        private System.Windows.Forms.Label lblUpcomming;
        private System.Windows.Forms.Panel pnlPreviousVideo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPrevious;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrivacyPolicy;
        private System.Windows.Forms.Panel pnlSep;
        private System.Windows.Forms.Label lblWatchCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblVersionNo;
    }
}