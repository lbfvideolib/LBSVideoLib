using LBFVideoLib.Common;
using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace LBFVideoLib.Client
{
    public partial class frmDashboard : Form
    {
        //private string _clientRootPath = "";
        //private string _clientInfoFilePath = "";
        public Form ParentFormControl { get; set; }
        public ClientInfo ClientInfoObject { get; set; }
        public TreeNode SelectedNode { get; set; }
        private Dictionary<string, string> _bookVideoList = new Dictionary<string, string>();
        private bool _skipNodeSelection = true;
        private List<VideoInfo> _mostWatchedVideos = new List<VideoInfo>();
        private List<VideoInfo> _mostRecommandedVideos = new List<VideoInfo>();
        private bool _formLoaded = false;
        //private List<ThumbnailInfo> _mostWatchedVideosThumbList = new List<ThumbnailInfo>();
        //private List<ThumbnailInfo> _mostRecommandedVideosThumbList = new List<ThumbnailInfo>();


        public frmDashboard()
        {
            InitializeComponent();
        }


        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _formLoaded = true;
            lblSessionYears.Text = ClientHelper.GetSessionString(ClientInfoObject.SessionString);
            lblSchoolWelcome.Text = ClientHelper.GetWelcomeString(ClientInfoObject.SchoolName, ClientInfoObject.SchoolCity, ClientInfoObject.SchoolId);
            lblExpireDate.Text = ClientHelper.GetExpiryDateString(ClientInfoObject.SessionEndDate);

            FillTreeView();
            treeView1.CollapseAll();

            AddRecomandatedVideos();
            AddMostWatchedVideos();
            label11.Location = new System.Drawing.Point(panel4.Width / 2 - 150, 11);
            label2.Location = new System.Drawing.Point(panel4.Width / 2 - 75, 15);
        }

        private void FillVideoList()
        {
            // Fill video list
            string videoRelativePath = "";
            for (int i = 0; i < ClientInfoObject.SelectedVideoDetails.Count; i++)
            {
                ClassFB classFB = ClientInfoObject.SelectedVideoDetails[i];
                videoRelativePath = Path.Combine(ClientHelper.GetClientVideoFilePath(ClientInfoObject.SchoolId, ClientInfoObject.SchoolCity), classFB.Name);
                for (int k = 0; k < classFB.Series.Count; k++)
                {
                    string seriesVideoPath = Path.Combine(videoRelativePath, classFB.Series[k].Name);
                    for (int j = 0; j < classFB.Series[k].Subjects.Count; j++)
                    {
                        string subjectVideoPath = Path.Combine(seriesVideoPath, classFB.Series[k].Subjects[j].Name);
                        for (int l = 0; l < classFB.Series[k].Subjects[j].Books.Count; l++)
                        {
                            string bookVideoPath = Path.Combine(subjectVideoPath, classFB.Series[k].Subjects[j].Books[l].Name);
                            string[] videoList = Directory.GetFiles(bookVideoPath);
                            for (int m = 0; m < videoList.Length; m++)
                            {
                                _bookVideoList.Add(Path.Combine(bookVideoPath, videoList[m]), videoList[m]);
                            }
                        }
                    }
                }
            }
        }

        #region Private Methods

        private void FillTreeView()
        {
            treeView1.Nodes.Clear();

            // Fill Tree
            string[] rootDirectoryList = Directory.GetDirectories(ClientHelper.GetClientVideoFilePath(ClientInfoObject.SchoolId, ClientInfoObject.SchoolCity));

            string[] sortedRootDirectoryList = new string[8];

            for (int i = 0; i < rootDirectoryList.Length; i++)
            {
                string classDirectoryName = Path.GetFileName(rootDirectoryList[i]);
                int sortOrder = CommonHelper.GetClassSortOrder(classDirectoryName);
                sortedRootDirectoryList[sortOrder - 1] = rootDirectoryList[i];
            }

            for (int i = 0; i < sortedRootDirectoryList.Length; i++)
            {
                if (sortedRootDirectoryList[i] != null)
                {
                    TreeNode rootNode = new TreeNode(Path.GetFileName(sortedRootDirectoryList[i]));
                    rootNode.Name = rootNode.Text;

                    TreeTag treeTag = new TreeTag();
                    treeTag.CurrentDirectoryPath = sortedRootDirectoryList[i];
                    rootNode.Tag = treeTag;
                    treeView1.Nodes.Add(rootNode);
                    AddTreeNode(rootNode, sortedRootDirectoryList[i]);
                }
            }

            //for (int i = 0; i < rootDirectoryList.Length; i++)
            //{
            //    TreeNode rootNode = new TreeNode(Path.GetFileName(rootDirectoryList[i]));
            //    rootNode.Name = rootNode.Text;

            //    TreeTag treeTag = new TreeTag();
            //    treeTag.CurrentDirectoryPath = rootDirectoryList[i];
            //    rootNode.Tag = treeTag;
            //    treeView1.Nodes.Add(rootNode);
            //    AddTreeNode(rootNode, rootDirectoryList[i]);
            //}
        }

        private void AddTreeNode(TreeNode parentNode, string currentDirectoryPath)
        {
            string[] directoryList = Directory.GetDirectories(currentDirectoryPath);
            string[] fileList = Directory.GetFiles(currentDirectoryPath);
            if (fileList.Length > 0)
            {
                parentNode.Tag = fileList;
            }
            else
            {
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

        private void OpenVideoLibrary(TreeNode selectedNode)
        {
            frmVideoLibrary frmVideoLibrary = new frmVideoLibrary();
            frmVideoLibrary.ParentFormControl = this;
            frmVideoLibrary.DashboardFormControl = this;
            frmVideoLibrary.ClientInfoObject = this.ClientInfoObject;
            frmVideoLibrary.SelectedNode = selectedNode;
            frmVideoLibrary.Show();
            CommonAppStateDataHelper.AddForm(this);
            this.Hide();
        }

        #endregion



        private void myButton1_Click(object sender, EventArgs e)
        {
            PlayVideo();
        }

        private void PlayVideo()
        {
            // frmPlayVideo playVideo = new frmPlayVideo();
            frmUpCommingVideo upcomingVideo = new frmUpCommingVideo();
            upcomingVideo.ParentFormControl = this;
            upcomingVideo.ClientInfoObject = this.ClientInfoObject;
            upcomingVideo.EncryptedVideo = false;
            //upcomingVideo.NextVideoFileList = new string[] { Path.Combine(ClientHelper.GetClientVideoFilePath(ClientInfoObject.SchoolId, ClientInfoObject.SchoolCity), @"First\First-S1\First-S1-English\First-S1-English-Basic\VID-20150929-WA0005.mp4") };
            upcomingVideo.Show();
            this.Hide();
        }

        private void myButton8_Click(object sender, EventArgs e)
        {
            PlayVideo();
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ClientHelper.GetContactMessageString(), "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddRecomandatedVideos()
        {
            _mostRecommandedVideos.Clear();
            Random random = new Random();
            int[] randomVideoIndexList = Enumerable.Repeat<int>(-1, CommonAppStateDataHelper.ClientInfoObject.VideoInfoList.Count).ToArray(); //new int[CommonAppStateDataHelper.ClientInfoObject.VideoInfoList.Count];
            int noOfIterations = 0;
            do
            {
                noOfIterations++;
                int newRandomNumber = random.Next(0, CommonAppStateDataHelper.ClientInfoObject.VideoInfoList.Count - 1);
                if (randomVideoIndexList.Contains(newRandomNumber) == false)
                {
                    _mostRecommandedVideos.Add(CommonAppStateDataHelper.ClientInfoObject.VideoInfoList[newRandomNumber]);
                    randomVideoIndexList[newRandomNumber] = newRandomNumber;
                }
            }
            while ((_mostRecommandedVideos.Count < 5 && _mostRecommandedVideos.Count <= CommonAppStateDataHelper.ClientInfoObject.VideoInfoList.Count) && noOfIterations < (CommonAppStateDataHelper.ClientInfoObject.VideoInfoList.Count * 2));

            if (_mostRecommandedVideos.Count < 5 && _mostRecommandedVideos.Count < CommonAppStateDataHelper.ClientInfoObject.VideoInfoList.Count)
            {
                int intialCounterValue = _mostRecommandedVideos.Count == 0 ? 0 : _mostRecommandedVideos.Count - 1;
                for (int i = intialCounterValue; i < 5 && i < CommonAppStateDataHelper.ClientInfoObject.VideoInfoList.Count; i++)
                {
                    // int newRandomNumber = 0;
                    if (randomVideoIndexList[i] < 0)
                    {
                        _mostRecommandedVideos.Add(CommonAppStateDataHelper.ClientInfoObject.VideoInfoList[i]);
                        randomVideoIndexList[i] = i;
                    }
                }
            }
            for (int i = 0; _mostRecommandedVideos != null && i < _mostRecommandedVideos.Count; i++)
            {
                // Nitin Start
                //ThumbnailInfo thumbInfo = new ThumbnailInfo();
                //thumbInfo.FileName = _mostRecommandedVideos[i].VideoName;
                //thumbInfo.ThumbnailFilePath = Path.Combine(ClientHelper.GetClientThumbanailPath(), ThumbnailHelper.GetThumbnailFileName(ClientHelper.GetClientThumbanailPath(),_mostRecommandedVideos[i].ClassName, _mostRecommandedVideos[i].Book));
                //thumbInfo.VideoFullUrl = _mostRecommandedVideos[i].VideoFullUrl;
                //_mostRecommandedVideosThumbList.Add(thumbInfo);
                _mostRecommandedVideos[i].ThumbnailFilePath = ThumbnailHelper.GetThumbnailFilePathByVideoPath(_mostRecommandedVideos[i].VideoFullUrl);
                // Nitin End
            }
            if (_mostRecommandedVideos != null && _mostRecommandedVideos.Count > 0)
            {
                AddVideoThumbnailControls(pnlRecomVideo, _mostRecommandedVideos, CtlMostWatchedVideo_Click);
            }
        }

        private void AddMostWatchedVideos()
        {
            _mostWatchedVideos.Clear();
            _mostWatchedVideos = CommonAppStateDataHelper.ClientInfoObject.VideoInfoList.OrderByDescending(k => k.WatchCount).Take(5).ToList<VideoInfo>();

            for (int i = 0; _mostWatchedVideos != null && i < _mostWatchedVideos.Count; i++)
            {
                // Nitin Start
                //ThumbnailInfo thumbInfo = new ThumbnailInfo();
                //thumbInfo.FileName = _mostWatchedVideos[i].VideoName;
                //thumbInfo.ThumbnailFilePath = Path.Combine(ClientHelper.GetClientThumbanailPath(), ThumbnailHelper.GetThumbnailFileName(ClientHelper.GetClientThumbanailPath(),_mostWatchedVideos[i].ClassName, _mostWatchedVideos[i].Book));
                //thumbInfo.VideoFullUrl = _mostWatchedVideos[i].VideoFullUrl;
                //_mostWatchedVideosThumbList.Add(thumbInfo);
                _mostWatchedVideos[i].ThumbnailFilePath = ThumbnailHelper.GetThumbnailFilePathByVideoPath(_mostWatchedVideos[i].VideoFullUrl);
                // Nitin End
            }
            if (_mostWatchedVideos != null && _mostWatchedVideos.Count > 0)
            {
                AddVideoThumbnailControls(pnlMostWatchVideo, _mostWatchedVideos, CtlMostWatchedVideo_Click);
            }
        }

        // Nitin Start
        private void AddVideoThumbnailControls(FlowLayoutPanel flowLayoutPanel, List<VideoInfo> videoInfoList, Action<object, EventArgs> clickDeligate)
        {
            flowLayoutPanel.Controls.Clear();
            for (int j = 0; j < videoInfoList.Count; j++)
            {
                CustomeThumbControl ctlThumb = new CustomeThumbControl(clickDeligate);
                ctlThumb.ThumbnailInformation = videoInfoList[j];
                ctlThumb.ThumbName = videoInfoList[j].VideoName;
                ctlThumb.ThumbUrl = videoInfoList[j].ThumbnailFilePath;
                ctlThumb.VideoUrl = videoInfoList[j].VideoFullUrl;
                ctlThumb.LabelWidth = 118;
                ctlThumb.Size = new System.Drawing.Size(120, 183);
                ctlThumb.Margin = new Padding(12, 0, 5, 0);
                flowLayoutPanel.Controls.Add(ctlThumb);
            }
        }


        private void CtlRecommanded_Click(object sender, EventArgs e)
        {
            try
            {
                _skipNodeSelection = true;
                CustomeThumbControl ctl = sender as CustomeThumbControl;

                this.treeView1.SelectedNode = this.SelectedNode = treeView1.FindByFullPath(ctl.VideoUrl).FirstOrDefault();

                List<VideoInfo> nextVideoList = new List<VideoInfo>();
                List<VideoInfo> previousVideoList = new List<VideoInfo>();

                CreatePreviousAndNextPlaylist(_mostRecommandedVideos, ctl.VideoUrl, out nextVideoList, out previousVideoList);

                frmUpCommingVideo upcomingVideoForm = new frmUpCommingVideo();
                upcomingVideoForm.ParentFormControl = this;
                upcomingVideoForm.ClientInfoObject = this.ClientInfoObject;
                upcomingVideoForm.EncryptedVideo = false;
                upcomingVideoForm.NextVideoFileList = nextVideoList;
                upcomingVideoForm.PreviousVideoFileList = previousVideoList;
                upcomingVideoForm.CurrentVideoInfo = ctl.ThumbnailInformation;//new VideoInfo() { FileName = ctl.ThumbnailInformation.VideoName, ThumbnailFilePath = ctl.ThumbUrl, VideoFullUrl = ctl.VideoUrl };
                upcomingVideoForm.EncryptedVideo = true;
                upcomingVideoForm.SelectedNode = this.treeView1.SelectedNode;
                upcomingVideoForm.DashboardFormControl = this;
                upcomingVideoForm.Show();
                this.Hide();
            }
            finally
            {
                _skipNodeSelection = false;
            }
        }

        private void CtlMostWatchedVideo_Click(object sender, EventArgs e)
        {
            try
            {
                _skipNodeSelection = true;
                CustomeThumbControl ctl = sender as CustomeThumbControl;
                // Find index of currently selected video in list.
                List<VideoInfo> nextVideoList = new List<VideoInfo>();
                List<VideoInfo> previousVideoList = new List<VideoInfo>();

                this.treeView1.SelectedNode = this.SelectedNode = FindVideoParentTreeNode(ctl.VideoUrl);

                CreatePreviousAndNextPlaylist(_mostWatchedVideos, ctl.VideoUrl, out nextVideoList, out previousVideoList);

                frmUpCommingVideo upcomingVideoForm = (CommonAppStateDataHelper.FindFormByFormType("frmUpCommingVideo") as frmUpCommingVideo);
                if (upcomingVideoForm == null)
                {
                    upcomingVideoForm = new frmUpCommingVideo();
                }
                upcomingVideoForm.ParentFormControl = this;
                upcomingVideoForm.ClientInfoObject = this.ClientInfoObject;
                upcomingVideoForm.EncryptedVideo = false;
                upcomingVideoForm.NextVideoFileList = nextVideoList;
                upcomingVideoForm.PreviousVideoFileList = previousVideoList;
                upcomingVideoForm.CurrentVideoInfo = ctl.ThumbnailInformation; //  new VideoInfo() { VideoName = ctl.ThumbnailInformation.VideoName, ThumbnailFilePath = ctl.ThumbnailInformation.ThumbnailFilePath, VideoFullUrl = ctl.ThumbnailInformation.VideoFullUrl };
                upcomingVideoForm.EncryptedVideo = true;
                upcomingVideoForm.SelectedNode = this.treeView1.SelectedNode;
                upcomingVideoForm.DashboardFormControl = this;
                upcomingVideoForm.Show();
                this.Hide();
            }
            finally
            {
                _skipNodeSelection = false;
            }
        }


        private TreeNode FindVideoParentTreeNode(string videoFullUrl)
        {
            return treeView1.FindByFullPath(videoFullUrl).FirstOrDefault();
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

        private void frmDashboard_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && this._formLoaded)
            {
                this.SelectedNode = treeView1.Nodes[0];
                treeView1.CollapseAll();
            }

            if (this.SelectedNode != null && this.Visible)
            {
                TreeNode[] searchedNode = this.treeView1.Nodes.Find(this.SelectedNode.Name, true);
                if (searchedNode.Length > 0)
                {
                    _skipNodeSelection = true;
                    this.treeView1.SelectedNode = searchedNode[0];
                    _skipNodeSelection = false;
                }
                AddMostWatchedVideos();
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (_skipNodeSelection == false)
                {
                    if (e.Node.Tag != null)
                    {
                        OpenVideoLibrary(e.Node);
                    }
                }
                else
                {
                    _skipNodeSelection = false;
                }
            }
            finally
            {
                _skipNodeSelection = false;
            }
        }

        private void lblPrivacyPolicy_Click(object sender, EventArgs e)
        {
            frmPrivacyPolicy frm = new frmPrivacyPolicy();
            frm.Show();
        }
    }
}
