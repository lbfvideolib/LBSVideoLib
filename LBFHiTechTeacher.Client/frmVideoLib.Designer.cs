namespace LBSVideoLib
{
    partial class frmVideoLib
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVideoLib));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.myButton5 = new LBSVideoLib.Client.myButton();
            this.myButton6 = new LBSVideoLib.Client.myButton();
            this.myButton7 = new LBSVideoLib.Client.myButton();
            this.myButton8 = new LBSVideoLib.Client.myButton();
            this.myButton4 = new LBSVideoLib.Client.myButton();
            this.myButton3 = new LBSVideoLib.Client.myButton();
            this.myButton2 = new LBSVideoLib.Client.myButton();
            this.myButton1 = new LBSVideoLib.Client.myButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSchoolName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 20);
            this.panel3.Size = new System.Drawing.Size(1370, 749);
            this.panel3.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.myButton5);
            this.panel7.Controls.Add(this.myButton6);
            this.panel7.Controls.Add(this.myButton7);
            this.panel7.Controls.Add(this.myButton8);
            this.panel7.Controls.Add(this.myButton4);
            this.panel7.Controls.Add(this.myButton3);
            this.panel7.Controls.Add(this.myButton2);
            this.panel7.Controls.Add(this.myButton1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(328, 110);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1042, 619);
            this.panel7.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1042, 62);
            this.panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 7);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 42);
            this.textBox1.TabIndex = 0;
            // 
            // myButton5
            // 
            this.myButton5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myButton5.ButtonName = "Video1";
            this.myButton5.Location = new System.Drawing.Point(792, 288);
            this.myButton5.Name = "myButton5";
            this.myButton5.Size = new System.Drawing.Size(201, 173);
            this.myButton5.TabIndex = 7;
            // 
            // myButton6
            // 
            this.myButton6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myButton6.ButtonName = "Video1";
            this.myButton6.Location = new System.Drawing.Point(553, 288);
            this.myButton6.Name = "myButton6";
            this.myButton6.Size = new System.Drawing.Size(201, 173);
            this.myButton6.TabIndex = 6;
            // 
            // myButton7
            // 
            this.myButton7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myButton7.ButtonName = "Video1";
            this.myButton7.Location = new System.Drawing.Point(311, 288);
            this.myButton7.Name = "myButton7";
            this.myButton7.Size = new System.Drawing.Size(201, 173);
            this.myButton7.TabIndex = 5;
            // 
            // myButton8
            // 
            this.myButton8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myButton8.ButtonName = "Video1";
            this.myButton8.Location = new System.Drawing.Point(49, 288);
            this.myButton8.Name = "myButton8";
            this.myButton8.Size = new System.Drawing.Size(201, 173);
            this.myButton8.TabIndex = 4;
            // 
            // myButton4
            // 
            this.myButton4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myButton4.ButtonName = "Video1";
            this.myButton4.Location = new System.Drawing.Point(790, 85);
            this.myButton4.Name = "myButton4";
            this.myButton4.Size = new System.Drawing.Size(201, 173);
            this.myButton4.TabIndex = 3;
            // 
            // myButton3
            // 
            this.myButton3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myButton3.ButtonName = "Video1";
            this.myButton3.Location = new System.Drawing.Point(554, 85);
            this.myButton3.Name = "myButton3";
            this.myButton3.Size = new System.Drawing.Size(201, 173);
            this.myButton3.TabIndex = 2;
            // 
            // myButton2
            // 
            this.myButton2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myButton2.ButtonName = "Video1";
            this.myButton2.Location = new System.Drawing.Point(309, 85);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(201, 173);
            this.myButton2.TabIndex = 1;
            // 
            // myButton1
            // 
            this.myButton1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myButton1.ButtonName = "Video1";
            this.myButton1.Location = new System.Drawing.Point(47, 85);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(201, 173);
            this.myButton1.TabIndex = 0;
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.lblSchoolName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(328, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1042, 100);
            this.panel4.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(872, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.AutoSize = true;
            this.lblSchoolName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolName.ForeColor = System.Drawing.Color.White;
            this.lblSchoolName.Location = new System.Drawing.Point(27, 37);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(79, 24);
            this.lblSchoolName.TabIndex = 0;
            this.lblSchoolName.Text = "{0} - {1}";
            this.lblSchoolName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 719);
            this.panel1.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.treeView1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 149);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(328, 570);
            this.panel6.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
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
            this.treeView1.Size = new System.Drawing.Size(328, 570);
            this.treeView1.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(328, 149);
            this.panel5.TabIndex = 0;
            // 
            // frmVideoLib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel3);
            this.Name = "frmVideoLib";
            this.Text = "Video Library";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVideoLib_FormClosed);
            this.Load += new System.EventHandler(this.frmVideoLib_Load);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSchoolName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel5;
        private Client.myButton myButton1;
        private System.Windows.Forms.Panel panel2;
        private Client.myButton myButton5;
        private Client.myButton myButton6;
        private Client.myButton myButton7;
        private Client.myButton myButton8;
        private Client.myButton myButton4;
        private Client.myButton myButton3;
        private Client.myButton myButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}