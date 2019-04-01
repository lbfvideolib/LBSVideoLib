using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace LBFVideoLib.Common
{
    public class LicenseHelper
    {
        private static Dictionary<string, string> sessionList = new Dictionary<string, string>();
        public static string licenseExpiredMessage = "Your package has been expired. To renew, Please Contact info@lbf.in or call 91091 38808.";
        public static string invalidClockMessage = "Invalid Clock";
        public static string invalidLicenseMessage = "License is invalid. To create new or renew, Please Contact info@lbf.in or call 91091 38808.";        
        public static string onlineConnectivityIsMust = "Your system is offline, Please connect to the internet.";
        public static string maxLicenseOccupiedMessage = "You seem to be exceeding your machine count. To increase, Please Contact info@lbf.in or call 91091 38808.";

        static LicenseHelper()
        {
            var provider = CultureInfo.InvariantCulture;
            var format = "MM-dd-yyyy hh:mm:ss tt";

            sessionList.Add("2018-19", DateTime.ParseExact("04-30-2019 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2019-20", DateTime.ParseExact("04-30-2020 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2020-21", DateTime.ParseExact("04-30-2021 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2021-22", DateTime.ParseExact("04-30-2022 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2022-23", DateTime.ParseExact("04-30-2023 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2023-24", DateTime.ParseExact("04-30-2024 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2024-25", DateTime.ParseExact("04-30-2025 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2025-26", DateTime.ParseExact("04-30-2026 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2026-27", DateTime.ParseExact("04-30-2027 11:59:59 PM", format, provider).ToString());
            sessionList.Add("2027-28", DateTime.ParseExact("04-30-2028 11:59:59 PM", format, provider).ToString());
        }

        public static List<string> GetSessionList()
        {
            return sessionList.Keys.ToList<string>();
        }

        public static DateTime GetSessionStartDateBySessionString(string session)
        {
            return Convert.ToDateTime(sessionList[session]).AddMonths(-13).AddDays(-29).Date;
        }

        public static DateTime GetSessionEndDateBySessionString(string session)
        {
            return Convert.ToDateTime(sessionList[session]);
        }

        public static bool CheckLicenseValidity(ClientInfo clientInfo, out string message, out bool deleteVideo)
        {
            bool valid = true;
            deleteVideo = false;
            message = "";
            DateTime registrationDate = DateTime.Parse(clientInfo.RegistrationDate.AddSeconds(-clientInfo.RegistrationDate.Second).AddMinutes(-clientInfo.RegistrationDate.Minute).ToString("dd-MMM-yyyy hh:00 tt"), CultureInfo.InvariantCulture);
            DateTime lastAccessTime = DateTime.Parse(clientInfo.LastAccessEndTime.AddSeconds(-clientInfo.LastAccessEndTime.Second).AddMinutes(-clientInfo.LastAccessEndTime.Minute).ToString("dd-MMM-yyyy hh:00 tt"), CultureInfo.InvariantCulture);

            //Caes1 => RegDate < CurrentDate & CurrentDate < Exp Date & LastAccessTime > CurrentDate = Show Message
            if (registrationDate.CompareTo(DateTime.Now) <= 0 && clientInfo.SessionEndDate.CompareTo(DateTime.Now) >= 0 && lastAccessTime.CompareTo(DateTime.Now) > 0)
            {
                valid = false;
                message = invalidClockMessage;
            }
            // Clock time is behind
            //Caes2 => RegDate > CurrentDate & CurrentDate < Exp Date = Show Message
            else if (clientInfo.RegistrationDate.Date.CompareTo(DateTime.Now.Date) > 0)
            {
                valid = false;
                message = invalidClockMessage;
            }
            //Caes3 => 	RegDate < CurrentDate & CurrentDate > Exp Date = Del Video Folder
            else if (clientInfo.SessionEndDate.Date.CompareTo(DateTime.Now.Date) < 0)
            {
                valid = false;
                // message = "Your subscription has expired. To renew please\nContact:info@lbf.in or Call on +91 0 9109138808";
                message = licenseExpiredMessage;
                deleteVideo = true;
            }
            //if (DateTime.Now < clientInfo.LastAccessStartTime || DateTime.Now < clientInfo.LastAccessEndTime)
            //{
            //    valid = false;
            //    message = "Your subscription has expired. To renew please\nContact:info@lbf.in or Call on +91 0 9109138808";
            //}
            //else if (DateTime.Now > clientInfo.ExpiryDate)
            //{
            //    valid = false;
            //    message = "Your subscription has expired. To renew please\nContact:info@lbf.in or Call on +91 0 9109138808";
            //}
            return valid;
        }

        public static LicenseValidationState CheckLicenseState(ClientInfo clientInfo, out string message, out bool deleteVideo)
        {
            LicenseValidationState currentState = LicenseValidationState.Valid;
            deleteVideo = false;
            message = "";
            DateTime sessionStartDate = new DateTime();
            DateTime lastAccessTime = new DateTime();
            DateTime currentDateTime = DateTime.Now;

            // if registration date is between SessionStart and SessionEnd date
            if (clientInfo.SessionStartDate.CompareTo(clientInfo.RegistrationDate) < 0 && clientInfo.SessionEndDate.CompareTo(clientInfo.RegistrationDate) > 0)
            {
                sessionStartDate = DateTime.Parse(clientInfo.RegistrationDate.AddSeconds(-clientInfo.RegistrationDate.Second).AddMinutes(-clientInfo.RegistrationDate.Minute).ToString("dd-MMM-yyyy hh:00 tt"), CultureInfo.InvariantCulture);
            }
            else if (clientInfo.SessionStartDate.CompareTo(clientInfo.RegistrationDate) > 0)
            {
                sessionStartDate = clientInfo.SessionStartDate;
            }
            else if (clientInfo.SessionEndDate.CompareTo(clientInfo.RegistrationDate) < 0)
            {
                deleteVideo = true;
                currentState = LicenseValidationState.Expired;
                message = licenseExpiredMessage;
                return currentState;
            }

            lastAccessTime = sessionStartDate;

            //RegDate > CurrentDate
            if (sessionStartDate.CompareTo(currentDateTime) > 0)
            {
                currentState = LicenseValidationState.InvalidLicense;
                message = invalidLicenseMessage;
            }
            // License is expired - Delete All Videos
            else if (clientInfo.SessionEndDate < currentDateTime)
            {
                deleteVideo = true;
                currentState = LicenseValidationState.Expired;
                message = licenseExpiredMessage;
            }
            // Clock time is back from current time -> Invalid Clock
            else if (lastAccessTime > currentDateTime) // && (registrationDate < currentDateTime && currentDateTime > clientInfo.ExpiryDate))
            {
                currentState = LicenseValidationState.InvalidClock;
                message = invalidClockMessage;
            }
            //// First Time Login Case -> Valid
            //if (lastAccessTime.Equals(clientInfo.RegistrationDate) && (registrationDate < currentDateTime && currentDateTime < clientInfo.ExpiryDate))
            //{
            //    currentState = LicenseValidationState.Valid;
            //}
            //// Normal Case -> Valid
            //else if (lastAccessTime <= currentDateTime && (registrationDate < currentDateTime && currentDateTime < clientInfo.ExpiryDate))
            //{
            //    currentState = LicenseValidationState.Valid;
            //}

            return currentState;
        }


        public static LicenseValidationState CheckLicenseStateNew(DateTime registrationDate, DateTime sessionStartDate, DateTime sessionEndDate, out string message, out bool deleteVideo)
        {
            LicenseValidationState currentState = LicenseValidationState.Valid;
            deleteVideo = false;
            message = "";
            DateTime startDate = new DateTime();
            DateTime lastAccessTime = new DateTime();
            DateTime currentDateTime = DateTime.Now;

            // if registration date is between SessionStart and SessionEnd date
            if (sessionStartDate.CompareTo(registrationDate) < 0 && sessionEndDate.CompareTo(registrationDate) > 0)
            {
                startDate = DateTime.Parse(registrationDate.AddSeconds(-registrationDate.Second).AddMinutes(-registrationDate.Minute).ToString("dd-MMM-yyyy hh:00 tt"), CultureInfo.InvariantCulture);
            }
            // Future registration date
            else if (sessionStartDate.CompareTo(registrationDate) > 0)
            {
                startDate = sessionStartDate;
            }
            // Expired license
            else if (sessionEndDate.CompareTo(registrationDate) < 0)
            {
                deleteVideo = true;
                currentState = LicenseValidationState.Expired;
                message = licenseExpiredMessage;
                return currentState;
            }

            lastAccessTime = startDate;

            // RegDate > CurrentDate
            if (startDate.CompareTo(currentDateTime) > 0)
            {
                currentState = LicenseValidationState.InvalidLicense;
                message = invalidLicenseMessage;
            }
            // License is expired - Delete All Videos
            else if (sessionEndDate < currentDateTime)
            {
                deleteVideo = true;
                currentState = LicenseValidationState.Expired;
                message = licenseExpiredMessage;
            }
            // Clock time is back from current time -> Invalid Clock
            else if (lastAccessTime > currentDateTime) // && (registrationDate < currentDateTime && currentDateTime > clientInfo.ExpiryDate))
            {
                currentState = LicenseValidationState.InvalidClock;
                message = invalidClockMessage;
            }
            return currentState;
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static LicenseValidationState ValidateMacAddress(RegInfoFB firebaseRegistrationInfo, ClientInfo localClientInfo, string localMacAddress, out string message, out bool deleteVideo, out bool skipLoginScreen)
        {
            //bool firebaseLicenseValidation = false;

            LicenseValidationState licenseState = LicenseValidationState.None;
            skipLoginScreen = false;
            deleteVideo = false;
            message = "";

            // Device is online
            if (firebaseRegistrationInfo != null)
            {
                //1) 	localClientInfo.MacAddress <> '' AND localClientInfo.MacAddress is in FirebaseMacAddressList == True
                //          Allow to login without authentication
                if (string.IsNullOrEmpty(localClientInfo.MacAddress) == false)
                {
                    // If local mac address is not matching with saved mac address.
                    if (localClientInfo.MacAddress.ToLower().Equals(localMacAddress.ToLower()) == false)
                    {
                        licenseState = LicenseValidationState.SavedMacAddressMismatched;
                        skipLoginScreen = false;
                        message = invalidLicenseMessage;
                        deleteVideo = true;
                    }

                    else if (firebaseRegistrationInfo.MacAddresses.Contains(localClientInfo.MacAddress) == true)
                    {
                        // maxlicense is valid and user already authenticated
                        skipLoginScreen = true;
                        licenseState = LicenseValidationState.Valid;
                    }
                    else if (firebaseRegistrationInfo.MacAddresses.Contains(localClientInfo.MacAddress) == false)
                    {
                        // 2.1) If FirebaseMacAddressList.Count >= MaxLicenseCount
                        //        Raise Error and Exit Application
                        if (firebaseRegistrationInfo.MacAddresses.Count >= firebaseRegistrationInfo.NoOfPcs)
                        {
                            licenseState = LicenseValidationState.MaxMacAddressLimitExceed;
                            skipLoginScreen = false;
                            message = maxLicenseOccupiedMessage;
                            deleteVideo = true;
                        }

                        // 2.2) IF FirebaseMacAddressList.Count < MaxLicenseCount
                        //        Add current macaddress in FirebaseMacAddressList and allow login
                        if (firebaseRegistrationInfo.MacAddresses.Count < firebaseRegistrationInfo.NoOfPcs)
                        {
                            licenseState = LicenseValidationState.Valid;
                            // Add current macaddress in FirebaseMacAddressList 
                            //_addMacAddressInFirebase = true;
                            skipLoginScreen = false;
                        }
                    }
                }
                // 3) 	If localClientInfo.MacAddress == '' Then
                else if (string.IsNullOrEmpty(localClientInfo.MacAddress))
                {
                    //    3.1) If FirebaseMacAddressList.Count >= MaxLicenseCount
                    //        Raise Error and Exit Application
                    if (firebaseRegistrationInfo.MacAddresses.Count >= firebaseRegistrationInfo.NoOfPcs)
                    {
                        licenseState = LicenseValidationState.MaxMacAddressLimitExceed;
                        skipLoginScreen = false;
                        message = maxLicenseOccupiedMessage;
                        deleteVideo = true;
                    }
                    // 3.2) If FirebaseMacAddressList.Count < MaxLicenseCount
                    else if (firebaseRegistrationInfo.MacAddresses.Count < firebaseRegistrationInfo.NoOfPcs)
                    {
                        licenseState = LicenseValidationState.Valid;

                        //      On sucessful authentication, save local mac address to Firebase.
                        //      Save local mac address to local client info file
                        //_addMacAddressInFirebase = true;
                        //      Ask user to enter login credentials
                        skipLoginScreen = false;

                    }
                }
            }
            // Device is offline
            else
            {
                // 1) localClientInfo.MacAddress == ''
                //      Ask user for autentication
                if (string.IsNullOrEmpty(localClientInfo.MacAddress))
                {
                    skipLoginScreen = false;
                }
                //    2) localClientInfo.MacAddress <> ''
                //            Allow user to use application without authentication
                else if (string.IsNullOrEmpty(localClientInfo.MacAddress) == false)
                {
                    if (localClientInfo.MacAddress.ToLower().Equals(localMacAddress.ToLower()))
                    {
                        skipLoginScreen = true;
                        licenseState = LicenseValidationState.Valid;
                    }else
                    {
                        skipLoginScreen = false;
                        licenseState = LicenseValidationState.ConnectivityRequiredForValidation;
                        message = invalidLicenseMessage;
                    }
                   
                    // Validate license date;
                }
            }

            return licenseState;
        }

    }
}
