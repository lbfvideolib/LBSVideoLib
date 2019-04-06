using LBFVideoLib.Common;
using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Threading;

namespace LBFVideoLib.Admin
{
    public partial class frmSchoolRegistration : Form
    {
        #region Private members
        //private string _clientTargetPath = "";
        private string _sourceVideoFolderPath = "";
        private string _clientDistributionRootPath = "";
        private string _clientInfoFileName = "";

        List<SchoolClass> _classList = new List<SchoolClass>();
        List<Series> _seriesList = new List<Series>();
        List<Subject> _subjectList = new List<Subject>();
        List<Book> _bookList = new List<Book>();
        List<ClassFB> _regInfoFB = new List<ClassFB>();

        private bool _seriesListBindingInProgress = false;
        private bool _subjectListBindingInProgress = false;

        ToolTip chkListTooltip = new ToolTip();
        int toolTipIndex = -1;
        private string[] _nonHiddenFiles = { "lbfvideolib.client.exe", "clientinfo.txt" };

        #endregion

        public frmSchoolRegistration()
        {
            InitializeComponent();
        }

        #region Events

        private void frmSchoolRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                // read configuration information
                _sourceVideoFolderPath = ConfigHelper.SourceVideoFolderPath;
                _clientDistributionRootPath = ConfigHelper.ClientDistributionTargetRootPath;
                _clientInfoFileName = ConfigHelper.ClientInfoFileName;

                InitializeRegistrationForm();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // string clientSchoolCodeFolderPath = "";
            try
            {
                if (ValidateRegistrationForm() == false)
                {
                    return;
                }

                CreateClientSchoolPackage();

            }

            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void CreateClientSchoolPackage()
        {
            string clientSchoolCodePath = "";
            try
            {
                progressBar1.Visible = true;
                progressBar1.Value = 10;

                string schoolCode = txtSchoolCode.Text.Trim();
                clientSchoolCodePath = Path.Combine(_clientDistributionRootPath, schoolCode);
                string clientVideoPath = ClientHelper.GetRegisteredSchoolPackageVideoPath(schoolCode, txtSchoolCity.Text.Trim());
               // string clientThumbnailPath = ClientHelper.GetRegisteredSchoolPackageThumbnailPath(schoolCode); // Path.Combine(clientPacakgeFolderPath, "Thumbnails");
                string clientVideoFolderName = ClientHelper.GetClientVideoFolderName(schoolCode, txtSchoolCity.Text.Trim());

                List<VideoInfo> videoInfoList = new List<VideoInfo>();

                #region Create Folder Structure

                // Create client distribution root folder.
                if (Directory.Exists(_clientDistributionRootPath) == false)
                {
                    Directory.CreateDirectory(_clientDistributionRootPath);
                }

                // Define client pacakge root folder path i.e. school code
                if (Directory.Exists(clientSchoolCodePath) == false)
                {
                    Directory.CreateDirectory(clientSchoolCodePath);
                }

                // Delete all old directory and files
                else if (Directory.Exists(clientSchoolCodePath))
                {
                    string[] oldClientFiles = Directory.GetDirectories(clientSchoolCodePath);
                    for (int i = 0; i < oldClientFiles.Length; i++)
                    {
                        //System.IO.File.Delete(Path.Combine(clientSchoolCodeFolderPath, oldClientFiles[i]));
                        System.IO.Directory.Delete(oldClientFiles[i], true);
                    }
                    oldClientFiles = Directory.GetFiles(clientSchoolCodePath);
                    for (int i = 0; i < oldClientFiles.Length; i++)
                    {
                        System.IO.File.Delete(oldClientFiles[i]);
                    }
                }
                progressBar1.Value = 25;

                //// Define client pacakge folder path i.e. pacakage
                //string clientPacakgeFolderPath = ClientHelper.GetClientRegistrationPackagePath(schoolCode); // Path.Combine(clientSchoolCodeFolderPath, "Package");
                //if (Directory.Exists(clientPacakgeFolderPath) == false)
                //{
                //    Directory.CreateDirectory(clientPacakgeFolderPath);
                //}

                // Define client video folder path i.e. SchoolCode_City_LBFVideos
                if (Directory.Exists(clientVideoPath) == false)
                {
                    Directory.CreateDirectory(clientVideoPath);
                }

                // Make client video folder hidden
                DirectoryInfo clientVideoFolderInfo = new DirectoryInfo(clientVideoPath);
                clientVideoFolderInfo.Attributes = FileAttributes.Hidden;

                //if (Directory.Exists(clientThumbnailPath) == false)
                //{
                //    Directory.CreateDirectory(clientThumbnailPath);
                //}
                //DirectoryInfo clientPackageThumbnailPathDirInfo = new DirectoryInfo(clientThumbnailPath);
                //clientPackageThumbnailPathDirInfo.Attributes = FileAttributes.Hidden;

                progressBar1.Value = 30;

                #endregion

                #region Copy Client Distribution

                if (Directory.Exists(ConfigHelper.ClientDistributionPath))
                {
                    string[] clientDistributionFiles = Directory.GetFiles(ConfigHelper.ClientDistributionPath);
                    for (int i = 0; i < clientDistributionFiles.Length; i++)
                    {
                        string targetFilePath = Path.Combine(clientSchoolCodePath, Path.GetFileName(clientDistributionFiles[i]));

                        System.IO.File.Copy(Path.Combine(ConfigHelper.ClientDistributionPath, clientDistributionFiles[i]), targetFilePath, true);

                        if (_nonHiddenFiles.Contains(Path.GetFileName(targetFilePath).ToLower()) == false)
                        {
                            FileInfo targetFileInfo = new FileInfo(targetFilePath);
                            targetFileInfo.Attributes = FileAttributes.Hidden;
                        }
                    }

                    //// Create shortcut of exe.
                    //WshShellClass shell = new WshShellClass();
                    //IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(clientSchoolCodeFolderPath, "LBSVideoLib.Client.exe.lnk"));
                    //shortcut.TargetPath = Path.Combine(clientPacakgeFolderPath, "LBSVideoLib.Client.exe");
                    //// add Description of Short cut
                    //shortcut.Description = "Run this exe to play LBF Video Library.";
                    //// save it / create
                    //shortcut.Save();
                }
                else
                {
                    MessageBox.Show("Unable to find client distribution on specified path.", "Error", MessageBoxButtons.OK);
                }

                progressBar1.Value = 45;

                for (int i = 0; i < chkListBooks.CheckedItems.Count; i++)
                {
                    Book selectedBook = (chkListBooks.CheckedItems[i]) as Book;

                    if (selectedBook.VideoList != null)
                    {
                        //   string[] selectedBookVideos =  Directory.GetFiles(selectedBook.BookId);

                        foreach (string selectedBookVideo in selectedBook.VideoList)
                        {
                            string clientTargetVideoPath = Path.Combine(clientVideoPath, selectedBook.ClassName);
                            string clientVideoRelativePath = Path.Combine(clientVideoFolderName, selectedBook.ClassName);

                            if (Directory.Exists(clientTargetVideoPath) == false)
                            {
                                Directory.CreateDirectory(clientTargetVideoPath);
                            }

                            DirectoryInfo clientTargetVideoPathInfo = new DirectoryInfo(clientTargetVideoPath);
                            clientTargetVideoPathInfo.Attributes = FileAttributes.Hidden;

                            clientTargetVideoPath = Path.Combine(clientTargetVideoPath, selectedBook.SeriesName);
                            clientVideoRelativePath = Path.Combine(clientVideoRelativePath, selectedBook.SeriesName);

                            if (Directory.Exists(clientTargetVideoPath) == false)
                            {
                                Directory.CreateDirectory(clientTargetVideoPath);
                            }
                            clientTargetVideoPathInfo = new DirectoryInfo(clientTargetVideoPath);
                            clientTargetVideoPathInfo.Attributes = FileAttributes.Hidden;

                            clientTargetVideoPath = Path.Combine(clientTargetVideoPath, selectedBook.SubjectName);
                            clientVideoRelativePath = Path.Combine(clientVideoRelativePath, selectedBook.SubjectName);

                            if (Directory.Exists(clientTargetVideoPath) == false)
                            {
                                Directory.CreateDirectory(clientTargetVideoPath);
                            }
                            clientTargetVideoPathInfo = new DirectoryInfo(clientTargetVideoPath);
                            clientTargetVideoPathInfo.Attributes = FileAttributes.Hidden;

                            clientTargetVideoPath = Path.Combine(clientTargetVideoPath, selectedBook.BookName);
                            clientVideoRelativePath = Path.Combine(clientVideoRelativePath, selectedBook.BookName);

                            if (Directory.Exists(clientTargetVideoPath) == false)
                            {
                                Directory.CreateDirectory(clientTargetVideoPath);
                            }
                            clientTargetVideoPathInfo = new DirectoryInfo(clientTargetVideoPath);
                            clientTargetVideoPathInfo.Attributes = FileAttributes.Hidden;


                            if (Directory.Exists(clientTargetVideoPath) == false)
                            {
                                Directory.CreateDirectory(clientTargetVideoPath);
                            }
                            clientTargetVideoPathInfo = new DirectoryInfo(clientTargetVideoPath);
                            clientTargetVideoPathInfo.Attributes = FileAttributes.Hidden;

                            VideoInfo videoInfo = new VideoInfo();
                            videoInfo.VideoName = Path.GetFileName(selectedBookVideo);
                            videoInfo.ClassName = selectedBook.ClassName;
                            videoInfo.SeriesName = selectedBook.SeriesName;
                            videoInfo.Subject = selectedBook.SubjectName;
                            videoInfo.Book = selectedBook.BookName;
                            clientTargetVideoPath = Path.Combine(clientTargetVideoPath, Path.GetFileName(selectedBookVideo));
                            clientVideoRelativePath = Path.Combine(clientVideoRelativePath, Path.GetFileName(selectedBookVideo));
                            //videoInfo.VideoFullUrl = clientTargetVideoPath;
                            videoInfo.VideoFullUrl = clientVideoRelativePath;
                            videoInfo.VideoRelativeUrl = clientVideoRelativePath;

                            Cryptograph.EncryptFile(selectedBookVideo, clientTargetVideoPath);

                            // Nitin Start 03-Sep
                            // Copy thumbnail file
                            string targetThumbnailFilePath = ThumbnailHelper.GetThumbnailDirectoryPathByVideoPath(clientTargetVideoPath);

                            if (System.IO.File.Exists(targetThumbnailFilePath) == false)
                            {
                                if (Directory.Exists(targetThumbnailFilePath) == false)
                                {
                                    Directory.CreateDirectory(targetThumbnailFilePath);
                                }
                                string sourceThumbnailFilePath = ThumbnailHelper.GetThumbnailFilePathByVideoPath(selectedBookVideo);
                                targetThumbnailFilePath = Path.Combine(targetThumbnailFilePath, ThumbnailHelper.GetThumbnailFileNameByVideoPath(selectedBookVideo));
                                System.IO.File.Copy(sourceThumbnailFilePath, targetThumbnailFilePath, true);
                            }
                            // Nitin End 03-Sep

                            FileInfo clientTargetVideoPathFileInfo = new FileInfo(clientTargetVideoPath);
                            clientTargetVideoPathFileInfo.Attributes = FileAttributes.Hidden;

                            videoInfoList.Add(videoInfo);
                        }
                    }
                }

                // Nitin Start
                //string[] subjectThumbnailFiles = Directory.GetFiles(ClientHelper.GetSubjectThumbnailSourcePath());
                //for (int i = 0; i < subjectThumbnailFiles.Length; i++)
                //{
                //    string thumbnailFilePath = Path.Combine(clientThumbnailPath, Path.GetFileName(subjectThumbnailFiles[i]));
                //    System.IO.File.Copy(subjectThumbnailFiles[i], thumbnailFilePath, true);

                //    FileInfo thumbnailFilePathFileInfo = new FileInfo(thumbnailFilePath);
                //    thumbnailFilePathFileInfo.Attributes = FileAttributes.Hidden;
                //}
                // Nitin End
                #endregion

                progressBar1.Value = 70;

                string newMemoNumber = GenerateNewMemoNumber();

                // Save data on firebase
                RegInfoFB selectedClassList = SaveRegDataOnFireBase(newMemoNumber);

                string registeredSchoolInfo = Newtonsoft.Json.JsonConvert.SerializeObject(selectedClassList);

                // Nitin Start
                CreateRegisteredSchoolInfoFile(registeredSchoolInfo, schoolCode, txtSchoolCity.Text.Trim(), txtSchoolName.Text.Trim(), newMemoNumber);
                // Nitin End

                progressBar1.Value = 80;

                // Set client email, password and license date in client info class.
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.EmailId = txtEmailId.Text.ToLower().Trim();
                clientInfo.Password = txtPwd.Text.Trim();
                clientInfo.RegistrationDate = DateTime.Now;
                clientInfo.SessionStartDate = LicenseHelper.GetSessionStartDateBySessionString(cmbSchoolSession.SelectedItem.ToString());
                clientInfo.SessionEndDate = LicenseHelper.GetSessionEndDateBySessionString(cmbSchoolSession.SelectedItem.ToString());
                clientInfo.LastAccessEndTime = clientInfo.SessionStartDate;
                clientInfo.SessionString = cmbSchoolSession.SelectedItem.ToString();
                clientInfo.SchoolId = this.txtSchoolCode.Text.Trim();
                clientInfo.SchoolName = this.txtSchoolName.Text.Trim();
                clientInfo.SchoolCity = txtSchoolCity.Text.Trim();
                clientInfo.SelectedVideoDetails = selectedClassList.Classes;
                clientInfo.VideoInfoList = videoInfoList;
                clientInfo.MemoNumber = newMemoNumber;

                // Generate client info json file and encrypt it.
                string clientInfoFilePath = Path.Combine(clientSchoolCodePath, _clientInfoFileName);
                Cryptograph.EncryptObject(clientInfo, clientInfoFilePath);
                FileInfo clientInfoFileInfo = new FileInfo(clientInfoFilePath);
                clientInfoFileInfo.Attributes = FileAttributes.Hidden;

                progressBar1.Value = 99;

                //string clientInfoPlainText = Newtonsoft.Json.JsonConvert.SerializeObject(clientInfo);
                //sw = System.IO.File.CreateText(Path.Combine(ClientHelper.GetRegisteredSchoolInfoFilePath(), this.txtSchoolCode.Text.Trim() + "-Plain.txt"));
                //sw.Write(clientInfoPlainText);
                //sw.Flush();
                //sw.Close();

                progressBar1.Value = 100;
                progressBar1.Visible = false;

                // Copy client project bin folder to target location.
                MessageBox.Show("Registration completed successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InitializeRegistrationForm();

            }
            catch (Exception ex)
            {

                // Delete all file on folder
                if (Directory.Exists(clientSchoolCodePath))
                {
                    // Delete created package folder inside school code
                    System.IO.Directory.Delete(clientSchoolCodePath, true);
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }

        private string GenerateNewMemoNumber()
        {
            // Decrypt file
            int counter = 1;

            try
            {
                if (System.IO.File.Exists(ClientHelper.GetMemoNumberFilePath()))
                {
                    counter = Cryptograph.DecryptObject<int>(ClientHelper.GetMemoNumberFilePath());

                    // Increment memo number and store it
                    counter += 1;
                    // Encrypt file with new memo number.
                    System.IO.File.Delete(ClientHelper.GetMemoNumberFilePath());
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "", false);
            }
            finally
            {
                Cryptograph.EncryptObject(counter, ClientHelper.GetMemoNumberFilePath());
            }
            return counter.ToString();
        }

        // Nitin Start
        private void CreateRegisteredSchoolInfoFile(string registeredSchoolInfo, string schoolCode, string schoolCity, string schoolName, string memoNumber)
        {
            try
            {
                string fileName = string.Format("{0}-{1}-{2}-{3}", memoNumber, schoolName, schoolCity, schoolCode);
                if (Directory.Exists(ClientHelper.NewRegisteredSchoolInfoFilePath()) == false)
                {
                    Directory.CreateDirectory(ClientHelper.NewRegisteredSchoolInfoFilePath());
                }

                string[] existingFiles = Directory.GetFiles(ClientHelper.NewRegisteredSchoolInfoFilePath());
                Int16 existingFileCounter = 0;
                for (int i = 0; i < existingFiles.Length; i++)
                {
                    string existingFileName = Path.GetFileNameWithoutExtension(existingFiles[i]).ToLower();
                    string[] existingFileSpilitedName = existingFileName.Split('-');
                    //if (existingFileName.StartsWith(fileName.ToLower()))
                    //{
                    //    existingFileCounter++;
                    //}

                    if (existingFileSpilitedName[1].ToLower().Equals(schoolName.ToLower()) && existingFileSpilitedName[2].ToLower().Equals(schoolCity.ToLower()) && existingFileSpilitedName[3].ToLower().Equals(schoolCode.ToLower()))
                    {
                        existingFileCounter++;
                    }
                }

                if (existingFileCounter > 0)
                {
                    fileName = string.Format("{0}-{1}", fileName, existingFileCounter);
                }


                StreamWriter sw = System.IO.File.CreateText(Path.Combine(ClientHelper.NewRegisteredSchoolInfoFilePath(), fileName + ".txt"));
                sw.Write(registeredSchoolInfo);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "", false);
            }
        }

        #region Check List Item Check Events

        private void chkListClass_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                SchoolClass selectedClass = (chkListClass.Items[e.Index] as SchoolClass);
                updateSeriesListBinding(e.NewValue, selectedClass, e.Index);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void chkListSeries_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                Series selectedSeries = (chkListSeries.Items[e.Index] as Series);
                updateSubjectListBinding(e.NewValue, selectedSeries);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void chkListSubject_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                Subject selectedSubject = (chkListSubject.Items[e.Index] as Subject);
                updateBookListBinding(e.NewValue, selectedSubject);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void chkListBook_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                if (_subjectListBindingInProgress == false)
                {
                    Book selectedBook = (chkListBooks.Items[e.Index] as Book);
                    if (e.NewValue == CheckState.Checked)
                    {
                        selectedBook.Selected = true;
                    }
                    else if (e.NewValue == CheckState.Unchecked)
                    {
                        selectedBook.Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }

        #endregion

        #endregion

        #region Update Check List Item Binding Methods

        private void updateSeriesListBinding(CheckState checkedState, SchoolClass selectedClass, int selectedClassIndex)
        {
            try
            {
                _seriesListBindingInProgress = true;

                List<Series> removedSeriesList = new List<Series>();
                // On each item check/un-check fill series
                if (checkedState == CheckState.Checked)
                {
                    // add series
                    selectedClass.Selected = true;
                    string[] seriesFolderList = Directory.GetDirectories(selectedClass.ClassId);
                    for (int i = 0; i < seriesFolderList.Length; i++)
                    {
                        //chkListSeries.Items.Add(seriesList[i]);
                        Series series = new Series();
                        series.SeriesId = seriesFolderList[i];
                        series.SeriesName = Path.GetFileName(seriesFolderList[i]);
                        series.ClassName = selectedClass.ClassName;
                        _seriesList.Add(series);
                    }
                }
                else if (checkedState == CheckState.Unchecked)
                {
                    selectedClass.Selected = false;
                    // remove series
                    SchoolClass selectedClassName = (chkListClass.Items[selectedClassIndex] as SchoolClass);
                    string[] seriesFolderList = Directory.GetDirectories(selectedClassName.ClassId);//Directory.GetDirectories(Path.Combine(_sourceFolderPath, selectedClassName));

                    _seriesList = _seriesList.Where(b =>
                    {
                        if (b.ClassName != selectedClassName.ClassName)
                        {
                            return true;
                        }
                        else
                        {
                            removedSeriesList.Add(b);
                            return false;
                        }
                    }
                    ).ToList<Series>();

                }

                ((ListBox)this.chkListSeries).DataSource = null;
                ((ListBox)this.chkListSeries).DataSource = _seriesList;
                ((ListBox)this.chkListSeries).DisplayMember = "SeriesName";
                ((ListBox)this.chkListSeries).ValueMember = "Selected";

                for (int i = 0; i < _seriesList.Count; i++)
                {
                    if (_seriesList[i].Selected)
                    {
                        this.chkListSeries.SetItemChecked(i, true);
                    }
                }
                _seriesListBindingInProgress = false;
                foreach (Series removedSeries in removedSeriesList)
                {
                    updateSubjectListBinding(CheckState.Unchecked, removedSeries);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex, "", false);
            }
            finally
            {
                _seriesListBindingInProgress = false;
            }
        }

        private void updateSubjectListBinding(CheckState checkedState, Series selectedSeries)
        {
            try
            {
                if (_seriesListBindingInProgress == false)
                {
                    _subjectListBindingInProgress = true;
                    List<Subject> removedSubjectList = new List<Subject>();
                    // On each item check/un-check fill series
                    if (checkedState == CheckState.Checked)
                    {
                        // add series
                        string[] subjectFolderList = Directory.GetDirectories(selectedSeries.SeriesId); // Directory.GetDirectories(Path.Combine(_sourceFolderPath, Path.Combine(selectedSeries.ClassName, selectedSeries.SeriesName)));
                        for (int i = 0; i < subjectFolderList.Length; i++)
                        {
                            //chkListSeries.Items.Add(seriesList[i]);
                            Subject subject = new Subject();
                            subject.SubjectId = subjectFolderList[i];
                            subject.SubjectName = Path.GetFileName(subjectFolderList[i]);
                            subject.SeriesName = selectedSeries.SeriesName;
                            subject.ClassName = selectedSeries.ClassName;
                            _subjectList.Add(subject);
                        }
                        selectedSeries.Selected = true;

                    }
                    else if (checkedState == CheckState.Unchecked)
                    {
                        selectedSeries.Selected = false;

                        // remove series
                        string[] subjectFolderList = Directory.GetDirectories(Path.Combine(_sourceVideoFolderPath, Path.Combine(selectedSeries.ClassName, selectedSeries.SeriesName)));
                        _subjectList = _subjectList.Where(b =>
                        {
                            if (b.SeriesName != selectedSeries.SeriesName)
                            {
                                return true;
                            }
                            else
                            {
                                removedSubjectList.Add(b);
                                return false;
                            }
                        }
                        ).ToList<Subject>();
                    }

                   ((ListBox)this.chkListSubject).DataSource = null;
                    ((ListBox)this.chkListSubject).DataSource = _subjectList;
                    ((ListBox)this.chkListSubject).DisplayMember = "SubjectName";
                    ((ListBox)this.chkListSubject).ValueMember = "Selected";

                    for (int i = 0; i < _subjectList.Count; i++)
                    {
                        if (_subjectList[i].Selected)
                        {
                            this.chkListSubject.SetItemChecked(i, true);
                        }
                    }

                    _subjectListBindingInProgress = false;
                    foreach (Subject removedSeries in removedSubjectList)
                    {
                        updateBookListBinding(CheckState.Unchecked, removedSeries);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex, "", false);
            }
            finally
            {
                _subjectListBindingInProgress = false;
            }
        }

        private void updateBookListBinding(CheckState checkedState, Subject selectedSubject)
        {
            try
            {
                if (_subjectListBindingInProgress == false)
                {
                    if (checkedState == CheckState.Checked)
                    {
                        // add series
                        string[] bookFolderList = Directory.GetDirectories(selectedSubject.SubjectId);

                        for (int i = 0; i < bookFolderList.Length; i++)
                        {
                            Book book = new Book();
                            book.BookId = bookFolderList[i];
                            book.BookName = Path.GetFileName(bookFolderList[i]);
                            book.SubjectName = selectedSubject.SubjectName;
                            book.ClassName = selectedSubject.ClassName;
                            book.SeriesName = selectedSubject.SeriesName;

                            string[] videoList = Directory.GetFiles(bookFolderList[i]);

                            if (videoList.Length > 0)
                            {
                                book.VideoList = videoList;
                            }

                            if (bookFolderList.Length == 1)
                            {
                                book.Selected = true;
                            }

                            _bookList.Add(book);
                        }
                        selectedSubject.Selected = true;
                    }
                    else if (checkedState == CheckState.Unchecked)
                    {
                        selectedSubject.Selected = false;

                        // remove series
                        string[] bookFolderList = Directory.GetDirectories(Path.Combine(_sourceVideoFolderPath, Path.Combine(Path.Combine(selectedSubject.ClassName, selectedSubject.SeriesName), selectedSubject.SubjectName)));
                        _bookList = _bookList.Where(b =>
                        {
                            if (b.SubjectName != selectedSubject.SubjectName)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        ).ToList<Book>();

                    }

                          ((ListBox)this.chkListBooks).DataSource = null;
                    ((ListBox)this.chkListBooks).DataSource = _bookList;
                    ((ListBox)this.chkListBooks).DisplayMember = "BookName";
                    ((ListBox)this.chkListBooks).ValueMember = "Selected";


                    for (int i = 0; i < _bookList.Count; i++)
                    {
                        if (_bookList[i].Selected)
                        {
                            this.chkListBooks.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex, "", false);
            }
            //finally
            //{
            //    _subjectListBindingInProgress = false;
            //}
        }

        #endregion

        #region Private Methods
        private void InitializeRegistrationForm()
        {
            try
            {
                progressBar1.Visible = false;

                txtEmailId.Text = "";
                txtPwd.Text = "";
                txtSchoolCity.Text = "";
                txtSchoolCode.Text = "";
                txtSchoolName.Text = "";
                txtNoOfPcs.Text = "";
                cmbSchoolSession.DataSource = LicenseHelper.GetSessionList();
                cmbSchoolSession.SelectedIndex = 0;

                _classList.Clear();
                _seriesList.Clear();
                _subjectList.Clear();
                _bookList.Clear();
                _regInfoFB.Clear();

                // Read all folders to fill classes
                string[] classNameList = Directory.GetDirectories(_sourceVideoFolderPath);

                for (int i = 0; i < classNameList.Length; i++)
                {
                    SchoolClass schoolClass = new SchoolClass();
                    schoolClass.ClassId = classNameList[i];
                    schoolClass.ClassName = Path.GetFileName(classNameList[i]);
                    schoolClass.SortOrder = CommonHelper.GetClassSortOrder(schoolClass.ClassName);
                    _classList.Add(schoolClass);
                }

                // Sort Class Name
                _classList = _classList.OrderBy(s => s.SortOrder).ToList();
                chkListClass.DataSource = null;
                chkListSeries.DataSource = null;
                chkListSubject.DataSource = null;
                chkListBooks.DataSource = null;

                // Fill list box with class list.
                ((ListBox)this.chkListClass).DataSource = _classList;
                ((ListBox)this.chkListClass).DisplayMember = "ClassName";
                ((ListBox)this.chkListClass).ValueMember = "Selected";
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "", false);
            }
        }

        private bool ValidateRegistrationForm()
        {
            try
            {
                if (txtEmailId.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Email Id is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (txtPwd.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Password is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (txtSchoolCity.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("School city is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (txtSchoolCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("School code is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (txtSchoolName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("School name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                int noOfPCs = 0;
                if (int.TryParse(txtNoOfPcs.Text, out noOfPCs) == false)
                {
                    MessageBox.Show("Invalid field value Number of pc's.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (noOfPCs <= 0)
                {
                    MessageBox.Show("Number of pc's is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (cmbSchoolSession.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a valid session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (chkListBooks.CheckedItems.Count < 1)
                {
                    MessageBox.Show("Please select atleast one book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "", false);
            }

            return true;

        }

        private RegInfoFB SaveRegDataOnFireBase(string newMemoNumber)
        {

            RegInfoFB info = new RegInfoFB();
            info.RegDate = DateTime.Now.ToString();
            info.LoginEmail = txtEmailId.Text;
            info.Password = txtPwd.Text;
            info.SchoolName = txtSchoolName.Text;
            info.City = txtSchoolCity.Text;
            info.Session = cmbSchoolSession.Text;
            info.NoOfPcs = Convert.ToInt32(txtNoOfPcs.Text);
            info.Classes = new List<ClassFB>();
            info.MemoNumber = newMemoNumber;
            info.ExpiryDate = info.ExpiryDate = LicenseHelper.GetSessionEndDateBySessionString(cmbSchoolSession.SelectedItem.ToString());
            info.SchoolCode = txtSchoolCode.Text.Trim();

            for (int i = 0; i < chkListBooks.CheckedItems.Count; i++)
            {
                Book selectedBook = (chkListBooks.CheckedItems[i]) as Book;

                ClassFB selectedFBClass = info.Classes.Find(k => k.Name == selectedBook.ClassName);
                if (selectedFBClass == null)
                {
                    selectedFBClass = new ClassFB();
                    selectedFBClass.Name = selectedBook.ClassName;
                    info.Classes.Add(selectedFBClass);
                }
                SeriesFB selectedFBSeries = selectedFBClass.Series.Find(k => k.Name == selectedBook.SeriesName);

                if (selectedFBSeries == null)
                {
                    selectedFBSeries = new SeriesFB();
                    selectedFBSeries.Name = selectedBook.SeriesName;
                    selectedFBClass.Series.Add(selectedFBSeries);
                }

                SubjectFB selectedFBSubject = selectedFBSeries.Subjects.Find(k => k.Name == selectedBook.SubjectName);

                if (selectedFBSubject == null)
                {
                    selectedFBSubject = new SubjectFB();
                    selectedFBSubject.Name = selectedBook.SubjectName;
                    selectedFBSeries.Subjects.Add(selectedFBSubject);
                }

                BookFB selectedFBBook = new BookFB();
                selectedFBBook.Name = selectedBook.BookName;
                selectedFBSubject.Books.Add(selectedFBBook);
            }

            try
            {
                string jsonString1 = JsonHelper.ParseObjectToJSON<RegInfoFB>(info);
                string url = string.Format("registrations-data/{0}-{1}", txtSchoolCode.Text, cmbSchoolSession.Text);
                FirebaseHelper.PatchData(jsonString1, url);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw new Exception("Internet connectivity issue.");
            }
            return info;
        }
        #endregion

        private void chkListClass_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                showClassCheckBoxToolTip(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void showClassCheckBoxToolTip(object sender, MouseEventArgs e)
        {
            try
            {
                if (toolTipIndex != this.chkListClass.IndexFromPoint(e.Location))
                {
                    toolTipIndex = chkListClass.IndexFromPoint(chkListClass.PointToClient(MousePosition));
                    if (toolTipIndex > -1)
                    {
                        chkListTooltip.SetToolTip(chkListClass, (chkListClass.Items[toolTipIndex] as SchoolClass).ClassName.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void chkListSeries_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                showSeriesCheckBoxToolTip(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void showSeriesCheckBoxToolTip(object sender, MouseEventArgs e)
        {
            try
            {
                if (toolTipIndex != this.chkListSeries.IndexFromPoint(e.Location))
                {
                    toolTipIndex = chkListSeries.IndexFromPoint(chkListSeries.PointToClient(MousePosition));
                    if (toolTipIndex > -1)
                    {
                        chkListTooltip.SetToolTip(chkListSeries, (chkListSeries.Items[toolTipIndex] as Series).SeriesName.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void chkListSubject_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                showSubjectCheckBoxToolTip(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void showSubjectCheckBoxToolTip(object sender, MouseEventArgs e)
        {
            try
            {
                if (toolTipIndex != this.chkListSubject.IndexFromPoint(e.Location))
                {
                    toolTipIndex = chkListSubject.IndexFromPoint(chkListSubject.PointToClient(MousePosition));
                    if (toolTipIndex > -1)
                    {
                        chkListTooltip.SetToolTip(chkListSubject, (chkListSubject.Items[toolTipIndex] as Subject).SubjectName.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void chkListBooks_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                showBookCheckBoxToolTip(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void showBookCheckBoxToolTip(object sender, MouseEventArgs e)
        {
            try
            {
                if (toolTipIndex != this.chkListBooks.IndexFromPoint(e.Location))
                {
                    toolTipIndex = chkListBooks.IndexFromPoint(chkListBooks.PointToClient(MousePosition));
                    if (toolTipIndex > -1)
                    {
                        chkListTooltip.SetToolTip(chkListBooks, (chkListBooks.Items[toolTipIndex] as Book).BookName.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

