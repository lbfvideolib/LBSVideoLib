using LBSVideoLib.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace LBSVideoLib.Admin
{
    public partial class frmRegistration : Form
    {
        //private string _clientInfoFilePath = Path.Combine(Directory.GetCurrentDirectory(), "clientInfo-encrypt.txt");
        private string _clientTargetPath = "";// Path.Combine(Directory.GetCurrentDirectory(), "clientTarget");
        private string _sourceFolderPath = "";
        private string _targetFolderPath = "";
        private string _clientInfoFileName = "";

        List<SchoolClass> _classList = new List<SchoolClass>();
        List<Series> seriesList = new List<Series>();
        List<Book> bookList = new List<Book>();

       
        public frmRegistration()
        {
            InitializeComponent();
        }

        public Form ParentFormControl
        {
            get; set;
        }

        #region Control Events

        private void Submit_Click(object sender, EventArgs e)
        {

            string[] oldClientFiles = Directory.GetFiles(_clientTargetPath);
            for (int i = 0; i < oldClientFiles.Length - 1; i++)
            {
                File.Delete(Path.Combine(_clientTargetPath, oldClientFiles[i]));
            }

            // Set client email, password and license date in client info class.
            ClientInfo clientInfo = new ClientInfo();
            clientInfo.EmailId = txtClientEmail.Text.ToLower().Trim();
            clientInfo.Password = txtClientPassword.Text.Trim();
            clientInfo.ExpiryDate = TimeZoneInfo.ConvertTime(dtExpiryDate.Value, TimeZoneInfo.Utc);
            clientInfo.SchoolId = this.txtSchoolId.Text.Trim();
            clientInfo.SchoolName = this.txtSchoolName.Text.Trim();

            // Generate client info json file and encrypt it.
            Cryptograph.EncryptObject(clientInfo,Path.Combine(_clientTargetPath, _clientInfoFileName));
         
            //  File.Move(_clientInfoFilePath, Path.Combine(_clientTargetPath, Path.GetFileName(_clientInfoFilePath)));

            for (int i = 0; i < chkListBooks.CheckedItems.Count; i++)
            {
                Book selectedBook = (chkListBooks.CheckedItems[i]) as Book;

                string[] selectedBookVideos = Directory.GetFiles(selectedBook.BookId);
                foreach (string selectedBookVideo in selectedBookVideos)
                {
                    string clientTargetVideoPath = Path.Combine(_clientTargetPath, selectedBook.ClassName);

                    clientTargetVideoPath = Path.Combine(clientTargetVideoPath, selectedBook.SeriesName);
                    clientTargetVideoPath = Path.Combine(clientTargetVideoPath, selectedBook.BookName);
                    if (Directory.Exists(clientTargetVideoPath) == false)
                    {
                        Directory.CreateDirectory(clientTargetVideoPath);
                    }
                    clientTargetVideoPath = Path.Combine(clientTargetVideoPath, Path.GetFileName(selectedBookVideo));
                
                    Cryptograph.EncryptFile(selectedBookVideo, clientTargetVideoPath);
                }
                //string encryptedFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "-crypted.mp4");
                //Cryptograph.EncryptFile(filePath, encryptedFilePath);
                //// Copy encrypted files to some target location.
                //File.Copy(encryptedFilePath, Path.Combine(_clientTargetPath, Path.GetFileName(encryptedFilePath)));
            }



            //// Encrypt selected source files.
            //string videoFolderPath = @"D:\School\Videos";
            //foreach (string filePath in Directory.GetFiles(videoFolderPath))
            //{
            //    string encryptedFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "-crypted.mp4");
            //    Cryptograph.EncryptFile(filePath, encryptedFilePath);
            //    // Copy encrypted files to some target location.
            //    File.Copy(encryptedFilePath, Path.Combine(_clientTargetPath, Path.GetFileName(encryptedFilePath)));
            //}


            // Copy client project bin folder to target location.
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkListClass_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            SchoolClass selectedClass = (chkListClass.Items[e.Index] as SchoolClass);
            updateSeriesListBinding(e.NewValue, selectedClass, e.Index);
        }

        private void chkListSeries_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Series selectedSeries = (chkListSeries.Items[e.Index] as Series);
            updateBookListBinding(e.NewValue, selectedSeries);
        }

        private void chkListBooks_ItemCheck(object sender, ItemCheckEventArgs e)
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

        #endregion

        #region Form Events

        private void frmRegistration_Load(object sender, EventArgs e)
        {

            // read configuration information
            _sourceFolderPath = ConfigHelper.SourceVideoFolderPath;
            _clientTargetPath = _targetFolderPath = ConfigHelper.ClientDistributionTargetRootPath;
            _clientInfoFileName = ConfigHelper.ClientInfoFileName;
            this.lblSessionYears.Text = string.Format(ConfigHelper.SessionYears, ConfigHelper.SessionYears);

            // Copy encrypted client info json file to target location.
            if (Directory.Exists(_targetFolderPath) == false)
            {
                Directory.CreateDirectory(_targetFolderPath);
            }
            chkListClass.Items.Clear();
            chkListSeries.Items.Clear();
            chkListBooks.Items.Clear();

       
            // Read all folders to fill classes
            string[] classNameList = Directory.GetDirectories(_sourceFolderPath);

            for (int i = 0; i < classNameList.Length; i++)
            {
                SchoolClass schoolClass = new SchoolClass();
                schoolClass.ClassId = classNameList[i];
                schoolClass.ClassName = Path.GetFileName(classNameList[i]);
                _classList.Add(schoolClass);
            }

            ((ListBox)this.chkListClass).DataSource = _classList;
            ((ListBox)this.chkListClass).DisplayMember = "ClassName";
            ((ListBox)this.chkListClass).ValueMember = "Selected";

        }

        private void frmRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmAdminLogin adminLogin = new frmAdminLogin();
            //adminLogin.MdiParent = this.MdiParent;
            //adminLogin.Show();
            this.ParentFormControl.Show();

        }

        #endregion

        private void updateSeriesListBinding(CheckState checkedState, SchoolClass selectedClass, int selectedClassIndex)
        {
            List<Series> removedSeriesList = new List<Series>();
            // On each item check/un-check fill series
            if (checkedState == CheckState.Checked)
            {
                // add series
                //SchoolClass selectedClass = (chkListClass.Items[e.Index] as SchoolClass);
                selectedClass.Selected = true;
                string[] seriesFolderList = Directory.GetDirectories(selectedClass.ClassId); //Directory.GetDirectories(Path.Combine(_sourceFolderPath, selectedClassName));
                for (int i = 0; i < seriesFolderList.Length; i++)
                {
                    //chkListSeries.Items.Add(seriesList[i]);
                    Series series = new Series();
                    series.SeriesId = seriesFolderList[i];
                    series.SeriesName = Path.GetFileName(seriesFolderList[i]);
                    series.ClassName = selectedClass.ClassName;
                    seriesList.Add(series);
                }
            }
            else if (checkedState == CheckState.Unchecked)
            {
                selectedClass.Selected = false;
                // remove series
                SchoolClass selectedClassName = (chkListClass.Items[selectedClassIndex] as SchoolClass);
                string[] seriesFolderList = Directory.GetDirectories(selectedClassName.ClassId);//Directory.GetDirectories(Path.Combine(_sourceFolderPath, selectedClassName));

                //seriesList.RemoveAll(s =>
                // {
                //     if (s.ClassName == selectedClassName.ClassName)
                //     {
                //         removedSeriesList.Add(s);
                //         return true;
                //     }
                //     else
                //     {
                //         return false;
                //     }
                // }
                //  );
                seriesList = seriesList.Where(b =>
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
            ((ListBox)this.chkListSeries).DataSource = seriesList;
            ((ListBox)this.chkListSeries).DisplayMember = "SeriesName";
            ((ListBox)this.chkListSeries).ValueMember = "Selected";


            for (int i = 0; i < seriesList.Count; i++)
            {
                if (seriesList[i].Selected)
                {
                    this.chkListSeries.SetItemChecked(i, true);
                }
            }

            foreach (Series removedSeries in removedSeriesList)
            {
                updateBookListBinding(CheckState.Unchecked, removedSeries);
            }
        }

        private void updateBookListBinding(CheckState checkedState, Series selectedSeries)
        {
            // On each item check/un-check fill series
            if (checkedState == CheckState.Checked)
            {
                // add series
                string[] bookFolderList = Directory.GetDirectories(selectedSeries.SeriesId); // Directory.GetDirectories(Path.Combine(_sourceFolderPath, Path.Combine(selectedSeries.ClassName, selectedSeries.SeriesName)));
                for (int i = 0; i < bookFolderList.Length; i++)
                {
                    //chkListSeries.Items.Add(seriesList[i]);
                    Book book = new Book();
                    book.BookId = bookFolderList[i];
                    book.BookName = Path.GetFileName(bookFolderList[i]);
                    book.ClassName = selectedSeries.ClassName;
                    book.SeriesName = selectedSeries.SeriesName;
                    bookList.Add(book);
                }
                selectedSeries.Selected = true;

            }
            else if (checkedState == CheckState.Unchecked)
            {
                selectedSeries.Selected = false;

                // remove series
                string[] bookFolderList = Directory.GetDirectories(Path.Combine(_sourceFolderPath, Path.Combine(selectedSeries.ClassName, selectedSeries.SeriesName)));
                bookList = bookList.Where(b =>
                {
                    if (b.SeriesName != selectedSeries.SeriesName)
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
            ((ListBox)this.chkListBooks).DataSource = bookList;
            ((ListBox)this.chkListBooks).DisplayMember = "BookName";
            ((ListBox)this.chkListBooks).ValueMember = "Selected";


            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Selected)
                {
                    this.chkListBooks.SetItemChecked(i, true);
                }
            }
        }


    }
}
