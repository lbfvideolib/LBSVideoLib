using LBSVideoLib.Common;
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
    public partial class frmVideoLib : Form
    {
        private string _clientRootPath = "";
        private string _clientInfoFilePath = "";

        public frmVideoLib()
        {
            InitializeComponent();
        }

        public Form ParentFormControl { get; set; }
        public ClientInfo ClientInfoObject { get; set; }

        private void frmVideoLib_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ParentFormControl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPlayVideo frmVideo = new frmPlayVideo();
            frmVideo.Show();
        }

        private void frmVideoLib_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            _clientRootPath = ConfigHelper.TargetFolderPath;
            _clientInfoFilePath = Path.Combine(_clientRootPath, ConfigHelper.ClientInfoFileName);
            this.ClientInfoObject.LastAccessEndTime = DateTime.UtcNow;
            this.ClientInfoObject.LastAccessStartTime = DateTime.UtcNow;
            Cryptograph.EncryptObject(this.ClientInfoObject, _clientInfoFilePath);
            //this.lblSchoolName.Text = this.ClientInfoObject.SchoolName;
            this.lblSchoolName.Text = string.Format(this.lblSchoolName.Text, this.ClientInfoObject.SchoolName, this.ClientInfoObject.SchoolId);

            // Fill Tree
            // get root
            string[] rootDirectoryList = Directory.GetDirectories(_clientRootPath);
            for (int i = 0; i < rootDirectoryList.Length; i++)
            {
                TreeNode rootNode = new TreeNode(Path.GetFileName(rootDirectoryList[i]));
                treeView1.Nodes.Add(rootNode);
                AddTreeNode(rootNode, rootDirectoryList[i]);
            }
        }

        private void AddTreeNode(TreeNode parentNode, string currentDirectoryPath)
        {
            string[] directoryList = Directory.GetDirectories(currentDirectoryPath);
            string[] fileList = Directory.GetFiles(currentDirectoryPath);
            if (fileList.Length > 0)
            {
                //for (int i = 0; i < fileList.Length; i++)
                //{
                //    TreeNode rootNode = new TreeNode(fileList[i]);
                //    parentNode.Nodes.Add(rootNode);                    
                //}
                parentNode.Tag = fileList;
            }

            //else { 
            for (int i = 0; i < directoryList.Length; i++)
            {
                TreeNode rootNode = new TreeNode(Path.GetFileName(directoryList[i]));
                parentNode.Nodes.Add(rootNode);
                AddTreeNode(rootNode, directoryList[i]);
            }
            //}
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.ParentFormControl.Show();
            this.Close();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //MessageBox.Show(e.Node.Tag.ToString());
                frmPlayVideo playVideo = new frmPlayVideo();
                playVideo.ParentFormControl = this;
                playVideo.NextVideoFileList = (string[])e.Node.Tag;
                this.Hide();
                playVideo.Show();
            }
        }

        private void myButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
