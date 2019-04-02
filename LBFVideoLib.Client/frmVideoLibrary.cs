using LBFVideoLib.Common;
using LBFVideoLib.Common.Entity;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LBFVideoLib.Client
{
    public partial class frmVideoLibrary : Form
    {
        private string _clientRootPath = "";
        private string _clientInfoFilePath = "";
        private string _clientVideoRootFilePath = "";
        private List<VideoInfo> _videoThumbnailFilePathList = new List<VideoInfo>();
        //   private TreeNode _lastSelectedNode = null;
        private bool _searchApplied = false;
        private bool _skipNodeSelection = true;
        List<VideoInfo> _searchList = new List<VideoInfo>();

        public Form ParentFormControl { get; set; }
        public Form DashboardFormControl { get; set; }
        public ClientInfo ClientInfoObject { get; set; }
        public TreeNode SelectedNode { get; set; }
        public bool UpdateTreeSelectedNode { get; set; }



        public frmVideoLibrary()
        {
            InitializeComponent();
        }

        #region Form Events

        private void frmVideoLibrary_Load(object sender, EventArgs e)
        {
            label11.Location = new System.Drawing.Point(panel4.Width / 2 - 150, 11);
            label2.Location = new System.Drawing.Point(panel4.Width / 2 - 75, 15);

            _clientInfoFilePath = ClientHelper.GetClientInfoFilePath();
            //this.ClientInfoObject.LastAccessEndTime = DateTime.UtcNow;
            //Cryptograph.EncryptObject(this.ClientInfoObject, _clientInfoFilePath);

            CommonAppStateDataHelper.ClientInfoObject.LastAccessEndTime = this.ClientInfoObject.LastAccessEndTime = DateTime.Now;

            FileInfo clientInfoFileInfo = new FileInfo(ClientHelper.GetClientInfoFilePath());
            clientInfoFileInfo.Attributes &= ~FileAttributes.Hidden;
            Cryptograph.EncryptObject(this.ClientInfoObject, _clientInfoFilePath);
            clientInfoFileInfo.Attributes |= FileAttributes.Hidden;

            _clientRootPath = ClientHelper.GetClientRootPath();
            _clientVideoRootFilePath = ClientHelper.GetClientVideoFilePath(this.ClientInfoObject.SchoolId, this.ClientInfoObject.SchoolCity);
            lblSessionYears.Text = ClientHelper.GetSessionString(ClientInfoObject.SessionString);
            lblSchoolWelcome.Text = ClientHelper.GetWelcomeString(ClientInfoObject.SchoolName, ClientInfoObject.SchoolCity, ClientInfoObject.SchoolId);
            // lblSchoolWelcome.Text = "Welcome, Only demo purpose only testing for demo, Indor, [0755-2549529]";
            lblExpireDate.Text = ClientHelper.GetExpiryDateString(ClientInfoObject.SessionEndDate);

            FillTreeView();
            treeView1.CollapseAll();

            UpdateTreeNodeSelection();
            FillVideoLibrary(this.treeView1.SelectedNode.Tag as TreeTag);

        }

        private void UpdateTreeNodeSelection()
        {
            try
            {
                _skipNodeSelection = true;
                if (this.SelectedNode != null)
                {
                    TreeNode[] searchedNode = this.treeView1.Nodes.Find(this.SelectedNode.Name, true);
                    if (searchedNode.Length > 0)
                    {
                        this.treeView1.SelectedNode = searchedNode[0];
                    }
                }
                else
                {
                    this.treeView1.SelectedNode = this.treeView1.Nodes[0];
                }
            }
            finally
            {
                _skipNodeSelection = false;
            }
        }

        private void frmVideoLibrary_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (e.CloseReason != CloseReason.ApplicationExitCall)
            //{
            //    (this.DashboardFormControl as frmDashboard).SelectedNode = treeView1.SelectedNode;
            //    this.DashboardFormControl.Show();
            //}
            Application.Exit();
        }

        #endregion

        #region Tree Methods & Events

        private void FillTreeView()
        {
            treeView1.Nodes.Clear();

            // Fill Tree
            string[] rootDirectoryList = Directory.GetDirectories(ClientHelper.GetClientVideoFilePath(ClientInfoObject.SchoolId, ClientInfoObject.SchoolCity));
            for (int i = 0; i < rootDirectoryList.Length; i++)
            {
                //TreeNode rootNode = new TreeNode(ClientInfoObject.SchoolName);
                //treeView1.Nodes.Add(rootNode);
                TreeNode rootNode = new TreeNode(Path.GetFileName(rootDirectoryList[i]));
                rootNode.Name = rootNode.Text;
                TreeTag treeTag = new TreeTag();
                treeTag.CurrentDirectoryPath = rootDirectoryList[i];
                rootNode.Tag = treeTag;
                treeView1.Nodes.Add(rootNode);
                AddTreeNode(rootNode, rootDirectoryList[i]);
            }
        }

        private void AddTreeNode(TreeNode parentNode, string currentDirectoryPath)
        {
            string[] fileList = Directory.GetFiles(currentDirectoryPath);
            if (fileList.Length > 0)
            {
                TreeTag treeTag = new TreeTag();
                treeTag.CurrentDirectoryPath = Directory.GetParent(fileList[0]).FullName;
                treeTag.BookVideoList = new List<string>(fileList);
                parentNode.Tag = treeTag;
            }

            else
            {
                string[] directoryList = Directory.GetDirectories(currentDirectoryPath);

                for (int i = 0; i < directoryList.Length; i++)
                {
                    TreeNode rootNode = new TreeNode(Path.GetFileName(directoryList[i]));
                    rootNode.Name = rootNode.Text;
                    TreeTag treeTag = new TreeTag();
                    treeTag.CurrentDirectoryPath = directoryList[i];
                    rootNode.Tag = treeTag;
                    parentNode.Nodes.Add(rootNode);
                    AddTreeNode(rootNode, directoryList[i]);
                }
            }
        }

        #endregion

        private void CtlThumb_Click(object sender, EventArgs e)
        {
            CustomeThumbControl ctl = sender as CustomeThumbControl;
            // Find index of currently selected video in list.

            List<VideoInfo> nextVideoList = new List<VideoInfo>();
            List<VideoInfo> previousVideoList = new List<VideoInfo>();
            if (_searchApplied)
            {
                CreatePreviousAndNextPlaylist(_searchList, ctl.VideoUrl, out nextVideoList, out previousVideoList);
            }
            else
            {
                CreatePreviousAndNextPlaylist(_videoThumbnailFilePathList, ctl.VideoUrl, out nextVideoList, out previousVideoList);
            }

            frmUpCommingVideo upcomingVideoForm = new frmUpCommingVideo();
            upcomingVideoForm.ParentFormControl = this;
            upcomingVideoForm.ClientInfoObject = this.ClientInfoObject;
            upcomingVideoForm.NextVideoFileList = nextVideoList;
            upcomingVideoForm.PreviousVideoFileList = previousVideoList;
            upcomingVideoForm.CurrentVideoInfo = ctl.ThumbnailInformation;// new VideoInfo() { VideoName = ctl.ThumbnailInformation.VideoName, ThumbnailFilePath = ctl.ThumbnailInformation.ThumbnailFilePath, VideoFullUrl = ctl.ThumbnailInformation.VideoFullUrl};
            upcomingVideoForm.EncryptedVideo = true;
            upcomingVideoForm.SelectedNode = this.treeView1.SelectedNode;
            upcomingVideoForm.DashboardFormControl = this.DashboardFormControl;
            upcomingVideoForm.Show();
            this.Hide();
        }

        private void CreatePreviousAndNextPlaylist(List<VideoInfo> thumbnailList, string videoUrl, out List<VideoInfo> nextVideoList, out List<VideoInfo> previousVideoList)
        {
            nextVideoList = new List<VideoInfo>();
            previousVideoList = new List<VideoInfo>();
            int index = thumbnailList.FindIndex(k => k.VideoFullUrl.Equals(videoUrl));
            for (int i = index + 1; (i < index + 1 + 3) && (i < thumbnailList.Count); i++)
            {
                nextVideoList.Add(thumbnailList[i]);
            }

            for (int i = index - 1; (i > index - 1 - 3) && (i > -1); i--)
            {
                previousVideoList.Add(thumbnailList[i]);
            }
        }

        private void lblContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ClientHelper.GetContactMessageString(), "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pnlLogo_Click(object sender, EventArgs e)
        {
            (this.DashboardFormControl as frmDashboard).SelectedNode = this.treeView1.SelectedNode;
            this.DashboardFormControl.Show();
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim().ToLower();
                ApplySearch(searchText);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, ex.Message, false);
                throw;
            }
        }

        private void ApplySearch(string searchText)
        {
            if (searchText.Length > 0)
            {
                _searchApplied = true;
                //string searchText = txtSearch.Text.Trim().ToLower();
                _searchList = _videoThumbnailFilePathList.Where(item => item.VideoName.ToLower().Contains(searchText)).ToList<VideoInfo>();
                AddVideoThumbnailControls(_searchList);
            }
            else if (_searchApplied)
            {
                _searchApplied = false;
                _searchList.Clear();
                AddVideoThumbnailControls(_videoThumbnailFilePathList);
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                FillVideoLibrary(e.Node.Tag as TreeTag);
                string searchText = txtSearch.Text.Trim();
                if (searchText.Length > 0)
                {
                    ApplySearch(searchText);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, ex.Message, false);
                throw;
            }
        }

        private void OpenUpcomingVideoForm(string[] nextVideoFileList)
        {
            frmUpCommingVideo upcomingVideoForm = new frmUpCommingVideo();
            upcomingVideoForm.ParentFormControl = this;
            upcomingVideoForm.ClientInfoObject = this.ClientInfoObject;
            upcomingVideoForm.EncryptedVideo = false;
            //upcomingVideoForm.NextVideoFileList = new string[] { Path.Combine(ClientHelper.GetClientVideoFilePath(ClientInfoObject.SchoolId, ClientInfoObject.SchoolCity), @"First\First-S1\First-S1-English\First-S1-English-Basic\VID-20150929-WA0005.mp4") };
            upcomingVideoForm.DashboardFormControl = this.DashboardFormControl;
            upcomingVideoForm.Show();
            this.Hide();
        }

        private void FillVideoLibrary(TreeTag currentNodeTag)
        {
            _videoThumbnailFilePathList.Clear();
            if (currentNodeTag.BookVideoList.Count == 0)
            {
                string[] currentDirectoryList = Directory.GetDirectories(currentNodeTag.CurrentDirectoryPath);
                for (int i = 0; i < currentDirectoryList.Length; i++)
                {
                    GetVideoFileList(currentDirectoryList[i], _videoThumbnailFilePathList);
                }
            }
            else
            {
                GetVideoFileList(currentNodeTag.CurrentDirectoryPath, _videoThumbnailFilePathList);
            }

            for (int i = 0; flowLayoutVideoPanel.Controls != null && i < flowLayoutVideoPanel.Controls.Count; i++)
            {
                if (flowLayoutVideoPanel.Controls[i].IsDisposed == false)
                {
                    flowLayoutVideoPanel.Controls[i].Click -= CtlThumb_Click;
                    flowLayoutVideoPanel.Controls[i].Dispose();
                }
            }
            flowLayoutVideoPanel.Controls.Clear();

            AddVideoThumbnailControls(_videoThumbnailFilePathList);
        }

        private void AddVideoThumbnailControls(List<VideoInfo> thumbnailInfoList)
        {
            flowLayoutVideoPanel.Controls.Clear();
            for (int j = 0; j < thumbnailInfoList.Count; j++)
            {
                CustomeThumbControl ctlThumb = new CustomeThumbControl(CtlThumb_Click);
                ctlThumb.ThumbName = thumbnailInfoList[j].VideoName;
                ctlThumb.ThumbUrl = thumbnailInfoList[j].ThumbnailFilePath; //Path.Combine(thumbnailSubjectPath, "Subjects_ENGLISH.png");
                ctlThumb.VideoUrl = thumbnailInfoList[j].VideoFullUrl;
                ctlThumb.ThumbnailInformation = thumbnailInfoList[j];
                //ctlThumb.Click += CtlThumb_Click;
                ctlThumb.LabelWidth = 118;
                ctlThumb.Margin = new Padding(5, 0, 10, 0);
                ctlThumb.Size = new System.Drawing.Size(120, 183);

                //ctlThumb
                flowLayoutVideoPanel.Controls.Add(ctlThumb);
            }
        }

        private void GetVideoFileList(string currentPath, List<VideoInfo> videoFilePathList)
        {
            if (Directory.GetFiles(currentPath).Length > 0)
            {
                string[] fileList = Directory.GetFiles(currentPath);
                for (int i = 0; i < fileList.Length; i++)
                {
                    VideoInfo thumbnailInfo = new VideoInfo();
                    thumbnailInfo.VideoFullUrl = fileList[i];
                    thumbnailInfo.VideoName = Path.GetFileName(fileList[i]);
                    // Nitin Start
                    //thumbnailInfo.ThumbnailFilePath = Path.Combine(ClientHelper.GetClientThumbanailPath(), ThumbnailHelper.GetThumbnailFileName(ClientHelper.GetClientThumbanailPath(), ClientHelper.GetClassNameFromFullPath(currentPath), currentPath));
                    thumbnailInfo.ThumbnailFilePath = ThumbnailHelper.GetThumbnailFilePathByVideoPath(fileList[i]);
                    // Nitin End
                    videoFilePathList.Add(thumbnailInfo);
                }
            }
            else
            {
                string[] currentDirectoryList = Directory.GetDirectories(currentPath);
                for (int i = 0; i < currentDirectoryList.Length; i++)
                {
                    GetVideoFileList(currentDirectoryList[i], videoFilePathList);
                }
            }
        }

        private void lblPrivacyPolicy_Click(object sender, EventArgs e)
        {
            try
            {
                frmPrivacyPolicy frm = new frmPrivacyPolicy();
                frm.Show();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, ex.Message, false);
                throw;
            }
        }

        private void frmVideoLibrary_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (UpdateTreeSelectedNode)
                {
                    UpdateTreeSelectedNode = false;
                    UpdateTreeNodeSelection();
                    FillVideoLibrary(this.treeView1.SelectedNode.Tag as TreeTag);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, ex.Message, false);
                throw;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                (this.DashboardFormControl as frmDashboard).SelectedNode = this.treeView1.SelectedNode;
                this.DashboardFormControl.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, ex.Message, false);
                throw;
            }
        }
    }
}

//private void FillTreeView()
//{
//    treeView1.Nodes.Clear();

//    string[] rootDirectoryList = Directory.GetDirectories(_clientVideoRootFilePath);
//    for (int i = 0; i < rootDirectoryList.Length; i++)
//    {
//        TreeNode rootNode = new TreeNode(Path.GetFileName(rootDirectoryList[i]));
//        TreeTag treeTag = new TreeTag();
//        treeTag.CurrentDirectoryPath = rootDirectoryList[i];
//        rootNode.Tag = treeTag;
//        treeView1.Nodes.Add(rootNode);
//        AddTreeNode(rootNode, rootDirectoryList[i], "");

//    }
//}

//private void AddTreeNode(TreeNode parentNode, string currentDirectoryPath, string selectedNodeFullPath)
//{
//    string[] directoryList = Directory.GetDirectories(currentDirectoryPath);
//    string[] fileList = Directory.GetFiles(currentDirectoryPath);
//    if (fileList.Length > 0)
//    {
//        (parentNode.Tag as TreeTag).BookVideoList = new List<string>(fileList);
//    }

//    else
//    {
//        for (int i = 0; i < directoryList.Length; i++)
//        {
//            TreeNode rootNode = new TreeNode(Path.GetFileName(directoryList[i]));
//            TreeTag treeTag = new TreeTag();
//            treeTag.CurrentDirectoryPath = directoryList[i];
//            rootNode.Tag = treeTag;
//            parentNode.Nodes.Add(rootNode);
//            //if (rootNode.FullPath.Equals(selectedNodeFullPath))
//            //{
//            //    treeView1.SelectedNode = rootNode;
//            //}
//            AddTreeNode(rootNode, directoryList[i], "");
//        }
//    }
//}
