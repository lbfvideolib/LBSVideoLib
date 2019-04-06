using LBFVideoLib.Common;
using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LBFVideoLib.Admin
{
    public class AdminHelper
    {

        public static string GenerateNewMemoNumber()
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

     
    }
}
