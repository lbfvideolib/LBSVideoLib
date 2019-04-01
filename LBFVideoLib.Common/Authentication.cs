using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Common
{
    public class Authentication
    {


        ////static string adminInfoFilePathEncrypted = Path.Combine(Directory.GetCurrentDirectory(), "adminInfo.txt");
        //static string adminInfoFilePathEncrypted = Path.Combine(ConfigHelper.SourceVideoFolderPath, "adminInfo.txt");

        //static string _clientInfoFilePathEncrypted = Path.Combine(Directory.GetCurrentDirectory(), "clientInfo.txt");
        static string _clientInfoFilePathEncrypted = ClientHelper.GetClientInfoFilePath();

     //   // Authenticate Admin
     //   public static bool AuthenticateAdmin(string email, string password)
     //   {
     //       AdminInfo adminInfo = null;
     //       if (File.Exists(adminInfoFilePathEncrypted) == false)
     //       {
     //             adminInfo = new AdminInfo();
     //           adminInfo.EmailId = "admin@admin.com";
     //           adminInfo.Password = "password";
     //           Cryptograph.EncryptObject(adminInfo, adminInfoFilePathEncrypted);

     //       }
     //       // decrypt admininfo file
     //adminInfo=    Cryptograph.DecryptObject<AdminInfo>(adminInfoFilePathEncrypted);
     //       if (adminInfo.EmailId.ToLower().Trim().Equals(email.ToLower().Trim()) && adminInfo.Password.ToLower().Trim().Equals(password.ToLower().Trim()))
     //       {
     //           return true;
     //       }
     //       else
     //       {
     //           return false;
     //       }
     //       // Authenticate admin email and pwd.
     //       // return true if authenticated.
     //       // else return false.
     //       // If online update firebase database.
     //       // Authenticate admin email and pwd.
     //       // Delete decrypted file
            
     //   }

        // Authenticate Client
        public static bool AuthenticateClient(string email, string password)
        {
            bool authenticated = false;
            //ClientInfo clientInfo = new ClientInfo();
            //clientInfo.EmailId = "admin@admin.com";
            //clientInfo.Password = "password";
            //Cryptograph.EncryptObject(clientInfo, clientInfoFilePathEncrypted);
            // decrypt admininfo file
            ClientInfo clientInfo = Cryptograph.DecryptObject<ClientInfo>(_clientInfoFilePathEncrypted);
            if (clientInfo.EmailId.ToLower().Trim().Equals(email.ToLower().Trim()) && clientInfo.Password.ToLower().Trim().Equals(password.ToLower().Trim()))
            {
                authenticated= true;
            }
            else
            {
                authenticated = false;
            }

            return authenticated;
            // decrypt clientInfo file info into object
            // Check expirty date with current date-time
            // If expired return false;
            // Else validate userid and password
            // return true if authenticated.
            // else return false.
            // Delete decrypted file

            // If online update firebase database.
            // Authenticate admin email and pwd.

            //return false;
        }

    }
}
