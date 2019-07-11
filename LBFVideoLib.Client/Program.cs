using LBFVideoLib.Common;
using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LBFVideoLib.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            Application.Run(new frmLogin());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                if (CommonAppStateDataHelper.ClientInfoObject.SessionList.Count > 0)
                {
                    int count = CommonAppStateDataHelper.ClientInfoObject.SessionList.Count;
                    CommonAppStateDataHelper.ClientInfoObject.SessionList[count - 1].EndTime = DateTime.Now;
                    CommonAppStateDataHelper.ClientInfoObject.LastAccessEndTime = DateTime.Now;
                    // update it in firebase database.
                    for (int i = 0; i < count; i++)
                    {
                        SaveSessionOnFireBase(CommonAppStateDataHelper.ClientInfoObject.SchoolId,
                            CommonAppStateDataHelper.ClientInfoObject.SessionList[i].StartTime,
                            CommonAppStateDataHelper.ClientInfoObject.SessionList[i].EndTime);
                    }

                    CommonAppStateDataHelper.ClientInfoObject.SessionList.Clear();
                    //}
                }
            }
            catch
            {
            }
            finally
            {
                CommonAppStateDataHelper.LoggedIn = false;
                if (CommonAppStateDataHelper.ClientInfoObject != null && CommonAppStateDataHelper.LoggedIn == true && CommonAppStateDataHelper.LicenseError == false)
                {
                    CommonAppStateDataHelper.ClientInfoObject.LastAccessEndTime = DateTime.Now;
                }

                #region BkupFileCode-AddIfCondition
                if (CommonAppStateDataHelper.ClientInfoObject != null)
                {
                    FileInfo clientInfoFileInfo = new FileInfo(ClientHelper.GetClientInfoFilePath());
                    clientInfoFileInfo.Attributes &= ~FileAttributes.Hidden;
                    Cryptograph.EncryptObject(CommonAppStateDataHelper.ClientInfoObject, ClientHelper.GetClientInfoFilePath());
                    clientInfoFileInfo.Attributes |= FileAttributes.Hidden;
                }
                #endregion
            }
        }

        private static void SaveSessionOnFireBase(string schoolCode, DateTime sessionStartTime, DateTime sessionEndTime)
        {
            try
            {
                string machineName = MacAddressHelper.GetMacAddress();// Environment.MachineName;
                SessionInfoFB info = new SessionInfoFB();
                //info.machineName = Environment.MachineName;
                info.sessionstarttime = sessionStartTime;
                info.sessionendtime = sessionEndTime;

                string jsonString = JsonHelper.ParseObjectToJSON<SessionInfoFB>(info);

                string url = string.Format("clientanalytic-data/{0}/{1}/sessions/", schoolCode, machineName);

                //string url = string.Format("clientanalytic-data/{0}/session", schoolCode);
                FirebaseHelper.PostData(jsonString, url);
            }

            catch (Exception e)
            {
                if (e.Message.Contains("A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond"))
                {
                    throw e;
                }
                else
                {
                    Console.Out.WriteLine("-----------------");
                    Console.Out.WriteLine(e.Message);
                }
            }
        }
  
    }
}
