using System;
using System.Net;
using System.Net.NetworkInformation;

namespace NetworkScanner
{
    public class MyIPClass
    {
        internal void getMyIP()
        {
            foreach (NetworkInterface netif in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine("Network Interface: {0}", netif.Name);
                IPInterfaceProperties properties = netif.GetIPProperties();
                foreach (IPAddress dns in properties.DnsAddresses)
                    Console.WriteLine("\tDNS: {0}", dns);
                foreach (IPAddressInformation anycast in properties.AnycastAddresses)
                    Console.WriteLine("\tAnyCast: {0}", anycast.Address);
                foreach (IPAddressInformation multicast in properties.MulticastAddresses)
                    Console.WriteLine("\tMultiCast: {0}", multicast.Address);
                foreach (IPAddressInformation unicast in properties.UnicastAddresses)
                    Console.WriteLine("\tUniCast: {0}", unicast.Address);
            }
        }

        //internal class MyIPClass : NetworkScanner.MyIPClass
        //{
        //}
    }
}
