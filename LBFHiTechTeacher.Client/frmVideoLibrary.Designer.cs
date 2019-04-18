namespace LBFVideoLib.Client
{
    partial class frmVideoLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVideoLibrary));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblVersionNo = new System.Windows.Forms.Label();
            this.lblPrivacyPolicy = new System.Windows.Forms.Label();
            this.lblExpireDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSessionYears = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flowLayoutVideoPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeading = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSchoolWelcome = new System.Windows.Forms.Label();
            this.pnlBottome = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
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
            this.treeView1.Size = new System.Drawing.Size(318, 384);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.pnlLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 653);
            this.panel1.TabIndex = 25;
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
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            this.panel4.Size = new System.Drawing.Size(1370, 43);
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
            this.lblPrivacyPolicy.Location = new System.Drawing.Point(1236, 11);
            this.lblPrivacyPolicy.Name = "lblPrivacyPolicy";
            this.lblPrivacyPolicy.Size = new System.Drawing.Size(107, 16);
            this.lblPrivacyPolicy.TabIndex = 3;
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
            this.lblExpireDate.TabIndex = 2;
            this.lblExpireDate.Text = "Expires on {0}";
            this.lblExpireDate.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(663, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "LBF Hi-Tech Teacher";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblContact
            // 
            this.lblContact.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.White;
            this.lblContact.Location = new System.Drawing.Point(1263, 15);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(80, 24);
            this.lblContact.TabIndex = 4;
            this.lblContact.Text = "Contact";
            this.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContact.Click += new System.EventHandler(this.lblContact_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.lblSessionYears);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblContact);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 53);
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
            this.lblSessionYears.TabIndex = 7;
            this.lblSessionYears.Text = "Session {0}";
            this.lblSessionYears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.flowLayoutVideoPanel);
            this.pnlMain.Controls.Add(this.pnlHeading);
            this.pnlMain.Controls.Add(this.pnlBottome);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.panel4);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1370, 749);
            this.pnlMain.TabIndex = 1;
            // 
            // flowLayoutVideoPanel
            // 
            this.flowLayoutVideoPanel.AutoScroll = true;
            this.flowLayoutVideoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutVideoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutVideoPanel.Location = new System.Drawing.Point(348, 176);
            this.flowLayoutVideoPanel.Name = "flowLayoutVideoPanel";
            this.flowLayoutVideoPanel.Size = new System.Drawing.Size(998, 513);
            this.flowLayoutVideoPanel.TabIndex = 53;
            // 
            // pnlHeading
            // 
            this.pnlHeading.Controls.Add(this.txtSearch);
            this.pnlHeading.Controls.Add(this.lblEmail);
            this.pnlHeading.Controls.Add(this.lblSchoolWelcome);
            this.pnlHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeading.Location = new System.Drawing.Point(348, 75);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(998, 101);
            this.pnlHeading.TabIndex = 51;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(89, 50);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 24);
            this.txtSearch.TabIndex = 32;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(5, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(84, 24);
            this.lblEmail.TabIndex = 31;
            this.lblEmail.Text = "Search";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSchoolWelcome
            // 
            this.lblSchoolWelcome.AutoEllipsis = true;
            this.lblSchoolWelcome.BackColor = System.Drawing.Color.White;
            this.lblSchoolWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.lblSchoolWelcome.Location = new System.Drawing.Point(5, 3);
            this.lblSchoolWelcome.Name = "lblSchoolWelcome";
            this.lblSchoolWelcome.Size = new System.Drawing.Size(662, 29);
            this.lblSchoolWelcome.TabIndex = 7;
            this.lblSchoolWelcome.Text = "Welcome, {0}, {1}, [{2}]";
            // 
            // pnlBottome
            // 
            this.pnlBottome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottome.Location = new System.Drawing.Point(348, 689);
            this.pnlBottome.Name = "pnlBottome";
            this.pnlBottome.Size = new System.Drawing.Size(998, 17);
            this.pnlBottome.TabIndex = 50;
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(348, 53);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(998, 22);
            this.pnlTop.TabIndex = 49;
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1346, 53);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(24, 653);
            this.pnlRight.TabIndex = 48;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(320, 53);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(28, 653);
            this.pnlLeft.TabIndex = 47;
            // 
            // frmVideoLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVideoLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LBF Hi-Tech Teacher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVideoLibrary_FormClosed);
            this.Load += new System.EventHandler(this.frmVideoLibrary_Load);
            this.VisibleChanged += new System.EventHandler(this.frmVideoLibrary_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlHeading.ResumeLayout(false);
            this.pnlHeading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblExpireDate;
        private System.Windows.Forms.Label lblSessionYears;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutVideoPanel;
        private System.Windows.Forms.Panel pnlHeading;
        private System.Windows.Forms.Label lblSchoolWelcome;
        private System.Windows.Forms.Panel pnlBottome;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPrivacyPolicy;
        private System.Windows.Forms.Label lblVersionNo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}