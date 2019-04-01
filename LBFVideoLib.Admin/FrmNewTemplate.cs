using LBFVideoLib.Common;
using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LBFVideoLib.Admin
{
    public partial class FrmNewTemplate : Form
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

        public FrmNewTemplate()
        {
            InitializeComponent();
        }

        private void FrmNewTemplate_Load(object sender, EventArgs e)
        {
            try
            {
                // read configuration information
                _sourceVideoFolderPath = ConfigHelper.SourceVideoFolderPath;
                _clientDistributionRootPath = ConfigHelper.ClientDistributionTargetRootPath;
                _clientInfoFileName = ConfigHelper.ClientInfoFileName;

                // InitializeRegistrationForm();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

        }
    }
}
