using LBFVideoLib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LBSVideoLib
{
    public partial class frmPlayVideo : Form
    {
        public frmPlayVideo()
        {
            InitializeComponent();
        }

        public Form ParentFormControl { get; set; }
        public ClientInfo ClientInfoObject { get; set; }

        public string[] NextVideoFileList
        {
            get; set;
        }

        public bool EncryptedVideo { get; set; }

        private void frmPlayVideo_Load(object sender, EventArgs e)
        {
            if (this.NextVideoFileList.Length > 0)
            {
                if (EncryptedVideo)
                {
                    string tempDirectory = Path.Combine(Path.GetDirectoryName(this.NextVideoFileList[0]), "Temp");
                    System.IO.Directory.CreateDirectory(tempDirectory);
                    string tempFilePath = Path.Combine(tempDirectory, Path.GetFileName(this.NextVideoFileList[0]));
                    Cryptograph.DecryptFile(this.NextVideoFileList[0], tempFilePath);
                    //try
                    //{
                    //    if (System.IO.File.Exists(tempFilePath))
                    //    {
                    //        System.IO.File.Delete(tempFilePath);                        
                    //    }
                    //    Cryptograph.DecryptFile(this.NextVideoFileList[0], tempFilePath);
                    //}
                    //catch (Exception ex)
                    //{
                    //    TextFileLogger.Log("frmPlayVideo_Load", ex.Message);
                    //}

                    this.axWindowsMediaPlayer1.URL = tempFilePath;
                }
                else
                {
                    this.axWindowsMediaPlayer1.URL = this.NextVideoFileList[0];
                }
            }
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (this.axWindowsMediaPlayer1.fullScreen == false)
                this.axWindowsMediaPlayer1.fullScreen = true;
        }

        private void btnRewind_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 10;

        }

        private void btnFastForward_Click(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition += 30;
        }

        private void frmPlayVideo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ParentFormControl.Show();
        }
    }
}
