namespace LBSVideoLib
{
    partial class frmPlayVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayVideo));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRewind = new System.Windows.Forms.Button();
            this.btnFastForward = new System.Windows.Forms.Button();
            this.btnFullScreen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1141, 646);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFullScreen);
            this.panel1.Controls.Add(this.btnFastForward);
            this.panel1.Controls.Add(this.btnRewind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 646);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 40);
            this.panel1.TabIndex = 1;
            // 
            // btnRewind
            // 
            this.btnRewind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRewind.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRewind.Image = ((System.Drawing.Image)(resources.GetObject("btnRewind.Image")));
            this.btnRewind.Location = new System.Drawing.Point(0, 0);
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Size = new System.Drawing.Size(112, 40);
            this.btnRewind.TabIndex = 0;
            this.btnRewind.UseVisualStyleBackColor = true;
            this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
            // 
            // btnFastForward
            // 
            this.btnFastForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFastForward.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFastForward.Image = ((System.Drawing.Image)(resources.GetObject("btnFastForward.Image")));
            this.btnFastForward.Location = new System.Drawing.Point(1029, 0);
            this.btnFastForward.Name = "btnFastForward";
            this.btnFastForward.Size = new System.Drawing.Size(112, 40);
            this.btnFastForward.TabIndex = 1;
            this.btnFastForward.UseVisualStyleBackColor = true;
            this.btnFastForward.Click += new System.EventHandler(this.btnFastForward_Click);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFullScreen.Location = new System.Drawing.Point(112, 0);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(917, 40);
            this.btnFullScreen.TabIndex = 2;
            this.btnFullScreen.Text = "Full Screen";
            this.btnFullScreen.UseVisualStyleBackColor = true;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // frmPlayVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 686);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "frmPlayVideo";
            this.Text = "frmPlayVideo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPlayVideo_FormClosed);
            this.Load += new System.EventHandler(this.frmPlayVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRewind;
        private System.Windows.Forms.Button btnFastForward;
        private System.Windows.Forms.Button btnFullScreen;
    }
}