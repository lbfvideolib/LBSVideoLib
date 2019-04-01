using LBFVideoLib.Common;
using LBFVideoLib.Common.Entity;
using System;
using System.IO;
using System.Windows.Forms;

namespace LBFVideoLib.Client
{
    public partial class frmLogin : Form
    {
        private string _clientInfoFilePath = "";
        // Check license duraion
        private ClientInfo _clientInfo = null;
        private bool _showLoginForm = true;
        private string _currentMacAddress = "";
        private bool _addMacAddressInFirebase = false;
        private RegInfoFB _firebaseRegInfo = null;

        public frmLogin()
        {
            InitializeComponent();
        }

        #region Form Events

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {

                label11.Location = new System.Drawing.Point(panel4.Width / 2 - 150, 11);
                label2.Location = new System.Drawing.Point(panel4.Width / 2 - 75, 15);


                this.progressBar1.Visible = true;
                this.progressBar1.Enabled = true;
                this.progressBar1.Value = 10;
                //ClientHelper.GetClientThumbanailPath();

                _clientInfoFilePath = ClientHelper.GetClientInfoFilePath();

                if (!File.Exists(_clientInfoFilePath))
                {
                    MessageBox.Show("Invalid Configuration", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                this.progressBar1.Value = 30;

                CommonAppStateDataHelper.ClientInfoObject = Cryptograph.DecryptObject<ClientInfo>(_clientInfoFilePath);
                _clientInfo = CommonAppStateDataHelper.ClientInfoObject;

                this.progressBar1.Value = 70;

                if (_clientInfo != null)
                {
                    lblSessionYears.Text = ClientHelper.GetSessionString(_clientInfo.SessionString);
                    lblSchoolWelcome.Text = ClientHelper.GetWelcomeString(_clientInfo.SchoolName, _clientInfo.SchoolCity, _clientInfo.SchoolId);
                    lblExpireDate.Text = ClientHelper.GetExpiryDateString(_clientInfo.SessionEndDate);

                    _currentMacAddress = MacAddressHelper.GetMacAddress();
                    //_currentMacAddress = "B82A72A780B7";
                    _firebaseRegInfo = GetFirebaseRegistrationInformation();

                    string errorMessage = "";
                    bool deleteVideos = false;
                    bool skipLoginScreen = false;
                    // Check license session duraion
                    LicenseValidationState licenseState = ValidateLicenseNew(_firebaseRegInfo, _clientInfo, _currentMacAddress, out errorMessage, out deleteVideos, out skipLoginScreen);

                    TextFileLogger.Log("License State" + licenseState.ToString());

                    if (licenseState != LicenseValidationState.Valid)
                    {
                        OnAfterLicesseValidation(errorMessage, deleteVideos, licenseState);
                    }

                    _showLoginForm = !skipLoginScreen;

                    this.progressBar1.Value = 100;

                    //// update mac address in local client info file
                    //if (licenseState == LicenseValidationState.Valid)
                    //{
                    //    this.progressBar1.Value = 90;
                    //    //if (string.IsNullOrEmpty(CommonAppStateDataHelper.ClientInfoObject.MacAddress))
                    //    //{
                    //    //    _showLoginForm = true;
                    //    //}
                    //    //else
                    //    //{
                    //    //    _showLoginForm = false;
                    //    //}
                    //}
                    //else
                    //{
                    //    this.progressBar1.Value = 100;
                    //    Application.Exit();
                    //}
                }
                else
                {
                    throw new Exception("Invalid client info configuration.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private RegInfoFB GetFirebaseRegistrationInformation()
        {
            return GetRegInfoFromFirebase(_clientInfo.SchoolId, _clientInfo.SessionString);
        }

        private void ValidateLicense()
        {
            string message = ""; bool deleteVideos = false;
            LicenseValidationState licenseState = LicenseValidationState.None;
            if (CommonAppStateDataHelper.ClientInfoObject.Expired)
            {
                deleteVideos = true;
                message = LicenseHelper.licenseExpiredMessage;
                licenseState = LicenseValidationState.Expired;
            }
            else
            {
                licenseState = LicenseHelper.CheckLicenseState(_clientInfo, out message, out deleteVideos);
            }

            if (deleteVideos && licenseState == LicenseValidationState.Expired)
            {
                CommonAppStateDataHelper.ClientInfoObject.Expired = true;
                CommonAppStateDataHelper.LicenseError = true;

                if (Directory.Exists(ClientHelper.GetClientVideoFilePath(_clientInfo.SchoolId, _clientInfo.SchoolCity)))
                {
                    Directory.Delete(ClientHelper.GetClientVideoFilePath(_clientInfo.SchoolId, _clientInfo.SchoolCity), true);
                }

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
            }
            else if (licenseState != LicenseValidationState.Valid)
            {
                CommonAppStateDataHelper.LicenseError = true;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private LicenseValidationState ValidateLicenseNew(RegInfoFB firebaseRegistrationInfo, ClientInfo localClientInfo, string localMACAddress, out string errorMessage, out bool deleteVideos, out bool skipLoginScreen)
        {
            errorMessage = ""; deleteVideos = false; skipLoginScreen = false;
            LicenseValidationState licenseState = LicenseValidationState.None;
            // Licese already expired
            if (CommonAppStateDataHelper.ClientInfoObject.Expired)
            {
                deleteVideos = true;
                errorMessage = LicenseHelper.licenseExpiredMessage;
                licenseState = LicenseValidationState.Expired;
            }
            else if (firebaseRegistrationInfo == null && string.IsNullOrEmpty(localClientInfo.MacAddress) == true)
            {
                errorMessage = LicenseHelper.onlineConnectivityIsMust;
                licenseState = LicenseValidationState.ConnectivityRequiredForValidation;
            }
            else if (string.IsNullOrEmpty(localMACAddress) == true)
            {
                errorMessage = LicenseHelper.invalidLicenseMessage;
                licenseState = LicenseValidationState.EmptyMacAddress;
            }
            else
            {
                DateTime sessionEndDate = localClientInfo.SessionEndDate;

                if (firebaseRegistrationInfo != null)
                {
                    sessionEndDate = firebaseRegistrationInfo.ExpiryDate;
                }

                licenseState = LicenseHelper.CheckLicenseStateNew(localClientInfo.RegistrationDate, localClientInfo.SessionStartDate, sessionEndDate, out errorMessage, out deleteVideos);

                // Validate Firebase MacAddress Check
                if (licenseState == LicenseValidationState.Valid)
                {
                    licenseState = LicenseHelper.ValidateMacAddress(firebaseRegistrationInfo, localClientInfo, localMACAddress, out errorMessage, out deleteVideos, out skipLoginScreen);
                }
            }
            return licenseState;

        }

        private void OnAfterLicesseValidation(string message, bool deleteVideos, LicenseValidationState licenseState)
        {
            if (deleteVideos && licenseState == LicenseValidationState.Expired)
            {
                CommonAppStateDataHelper.ClientInfoObject.Expired = true;
                CommonAppStateDataHelper.LicenseError = true;

                if (Directory.Exists(ClientHelper.GetClientVideoFilePath(_clientInfo.SchoolId, _clientInfo.SchoolCity)))
                {
                    Directory.Delete(ClientHelper.GetClientVideoFilePath(_clientInfo.SchoolId, _clientInfo.SchoolCity), true);
                }

                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
            }
            else if (licenseState != LicenseValidationState.Valid)
            {
                CommonAppStateDataHelper.LicenseError = true;
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        #endregion

        #region Control Events

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool authenticated = Authentication.AuthenticateClient(txtEmailId.Text.Trim(), txtPwd.Text.Trim());

                if (authenticated)
                {
                    OnAfterAuthentication();
                }
                else
                {
                    //lblStatus.Text = "Invalid Email Id or Password!!";
                    MessageBox.Show("Invalid Email Id or Password!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }

        private void OnAfterAuthentication()
        {
            // Add mac address in firebase database.
            if (_firebaseRegInfo != null && _firebaseRegInfo.MacAddresses.Contains(_currentMacAddress) == false)
            {
                _firebaseRegInfo.MacAddresses.Add(_currentMacAddress);
                UpdateRegInfo(_firebaseRegInfo);
            }

            SessionInfo sessionInfo = new SessionInfo();
            sessionInfo.StartTime = DateTime.Now;
            _clientInfo.LastAccessStartTime = DateTime.Now;
            _clientInfo.LastAccessEndTime = DateTime.Now;
            _clientInfo.SessionList.Add(sessionInfo);

            if (string.IsNullOrEmpty(_clientInfo.MacAddress))
            {
                _clientInfo.MacAddress = _currentMacAddress;
            }

            for (int i = 0; i < _clientInfo.VideoInfoList.Count; i++)
            {
                if (Path.Combine(ClientHelper.GetClientRootPath(), _clientInfo.VideoInfoList[i].VideoRelativeUrl).Equals(_clientInfo.VideoInfoList[i].VideoFullUrl) == false)
                {
                    _clientInfo.VideoInfoList[i].VideoFullUrl = Path.Combine(ClientHelper.GetClientRootPath(), _clientInfo.VideoInfoList[i].VideoRelativeUrl);
                    // Nitin Start
                    _clientInfo.VideoInfoList[i].ThumbnailFilePath = ThumbnailHelper.GetThumbnailFilePathByVideoPath(_clientInfo.VideoInfoList[i].VideoFullUrl);
                    // Nitin End
                }
            }

            FileInfo clientInfoFileInfo = new FileInfo(ClientHelper.GetClientInfoFilePath());
            try
            {
                clientInfoFileInfo.Attributes &= ~FileAttributes.Hidden;
                // this.ClientInfoObject.LastAccessStartTime = DateTime.UtcNow;
                Cryptograph.EncryptObject(_clientInfo, ClientHelper.GetClientInfoFilePath());
                clientInfoFileInfo.Attributes |= FileAttributes.Hidden;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                throw;
            }
            finally
            {
                clientInfoFileInfo.Attributes |= FileAttributes.Hidden;
            }

            frmDashboard frm = new frmDashboard();
            // frm.MdiParent = this.MdiParent;
            frm.ParentFormControl = this;
            frm.ClientInfoObject = CommonAppStateDataHelper.ClientInfoObject;
            CommonAppStateDataHelper.AddForm(this);
            frm.Show();
            this.Hide();
            CommonAppStateDataHelper.LoggedIn = true;
        }

        private void lblShowPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPwd.PasswordChar == '*')
                {
                    txtPwd.PasswordChar = '\0';
                    lblShowPwd.Text = "Hide";
                }
                else
                {
                    lblShowPwd.Text = "Show";
                    txtPwd.PasswordChar = '*';
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }

        private void lblContact_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(ClientHelper.GetContactMessageString(), "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }

        private void lblForgotPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_clientInfo != null)
                {
                    System.Diagnostics.Process.Start(string.Format("mailto:info@lbf.in?subject={0}-{1}", _clientInfo.SchoolName, _clientInfo.SchoolId));
                }
                else
                {
                    MessageBox.Show("Invalid client configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }
        #endregion

        private void lblPrivacyPolicy_Click(object sender, EventArgs e)
        {
            try
            {
                frmPrivacyPolicy frm = new frmPrivacyPolicy();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }


        private static RegInfoFB GetRegInfoFromFirebase(string schoolCode, string sessionYear)
        {
            string url = string.Format("registrations-data/{0}-{1}", schoolCode, sessionYear);
            string jsonString = FirebaseHelper.GetData(url);
            return JsonHelper.ParseJsonToObject<RegInfoFB>(jsonString) as RegInfoFB;
        }


        private void UpdateRegInfo(RegInfoFB info)
        {
            string jsonString1 = JsonHelper.ParseObjectToJSON<RegInfoFB>(info);
            string url = string.Format("registrations-data/{0}-{1}", _clientInfo.SchoolId, _clientInfo.SessionString);
            FirebaseHelper.PatchData(jsonString1, url);
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            try
            {
                this.progressBar1.Value = 100;

                if (_showLoginForm == false)
                {
                    OnAfterAuthentication();
                }
                else
                {
                    btnLogin.Visible = true;
                    lblEmail.Visible = true;
                    txtEmailId.Visible = true;
                    lblPassword.Visible = true;
                    lblShowPwd.Visible = true;
                    txtPwd.Visible = true;
                    linklblForgotPwd.Visible = true;
                    lblShowContact.Visible = true;
                    progressBar1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}

//private bool ValidateNoOfLicense(string currentMacAddress)
//{

//    //RegInfoFB regInfo = GetRegInfoFromFirebase(_clientInfo.SchoolId, _clientInfo.SessionString);

//    //if (!regInfo.MacAddresses.Contains(currentMacAddress)){

//    //    if (regInfo.MacAddresses.Count >= regInfo.NoOfPcs)
//    //    {

//    //        MessageBox.Show("Number of licenses exceeded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//    //        return;
//    //    }
//    //    else
//    //    {
//    //        regInfo.MacAddresses.Add(currentMacAddress);
//    //        UpdateRegInfo(regInfo);
//    //    }
//    //}

//    bool validLicense = false;
//    RegInfoFB regInfo = GetFirebaseRegistrationInformation();

//    // If device is offline
//    // 1)     And local mac address is empty
//    //          doesn not allow to login
//    // 2)     And local mac address is not empty
//    //          Allow to login
//    // If device is online
//    //      Get totoal mac address count registerd on firebase 
//    //      Get all registered mac address registered on firebase
//    //      Get local client info mac address

//    // 1) If firebase registered mac address count > max allowed registration
//    //        Raise Error and exit application
//    //
//    // 2) If firebase registered mac address count == max allowed registration And local client info mac address is not in registered mac address list
//    //        Raise Error and exit application
//    //
//    // 3) If firebase registered mac address count == max allowed registration And local client info mac address is in registered mac address list
//    //        Allow to login
//    // 4) If loca client info 

//    if (!regInfo.MacAddresses.Contains(currentMacAddress))
//    {

//        if (regInfo.MacAddresses.Count >= regInfo.NoOfPcs)
//        {
//            validLicense = false;
//            MessageBox.Show("Number of licenses exceeded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//        }
//        else
//        {
//            regInfo.MacAddresses.Add(currentMacAddress);
//            UpdateRegInfo(regInfo);
//            validLicense = true;
//        }
//    }
//    else
//    {
//        if (regInfo.MacAddresses.Count >= regInfo.NoOfPcs)
//        {
//            validLicense = false;
//            MessageBox.Show("Number of licenses exceeded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//        }
//        else
//        {
//            validLicense = true;
//        }

//    }
//    return validLicense;
//}

