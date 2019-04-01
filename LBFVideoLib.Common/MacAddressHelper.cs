using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace LBFVideoLib.Common
{
    public class MacAddressHelper
    {
       public  static string GetMacAddress()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces, thereby ignoring any
                // loopback devices etc.
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet)
                {
                    //macAddresses = System.Environment.MachineName;
                    continue;
                }
                //if (nic.OperationalStatus == OperationalStatus.Up)
                //{
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                //}
            }
            return macAddresses;

            //string mac = "";
            //foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            //{

            //    if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
            //    {
            //        if (nic.GetPhysicalAddress().ToString() != "")
            //        {
            //            mac = nic.GetPhysicalAddress().ToString();
            //        }
            //    }
            //}
            //return mac;
        }
    }
}
