using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using static System.Net.Mime.MediaTypeNames;

namespace NetworkScanner
{
    public class MyIPClass
    {
        internal void getMyIP()
        {
            //foreach (NetworkInterface netif in NetworkInterface.GetAllNetworkInterfaces())
            //{
            //    Console.WriteLine("Network Interface: {0}", netif.Name);
            //    IPInterfaceProperties properties = netif.GetIPProperties();
            //    foreach (IPAddress dns in properties.DnsAddresses)
            //        Console.WriteLine("\tDNS: {0}", dns);
            //    foreach (IPAddressInformation anycast in properties.AnycastAddresses)
            //        Console.WriteLine("\tAnyCast: {0}", anycast.Address);
            //    foreach (IPAddressInformation multicast in properties.MulticastAddresses)
            //        Console.WriteLine("\tMultiCast: {0}", multicast.Address);
            //    foreach (IPAddressInformation unicast in properties.UnicastAddresses)
            //        Console.WriteLine("\tUniCast: {0}", unicast.Address);
            //}
            


            
            //---------------------------------------------------


            String hostName = Dns.GetHostName();
            IPHostEntry host = Dns.GetHostEntry(hostName);
            Console.WriteLine("\n\n");
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("Host Name: {0}", hostName);
                    Console.WriteLine("My IP address is: {0}", ip.ToString());
                    Console.WriteLine("\n\nIn printIPinfo!\n");
                    printIPinfo(ip.ToString());
                    return ;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");

        }


        internal void printIPinfo(String ipAddr)
        {
            IPAddress test1 = IPAddress.Parse(ipAddr);
            IPAddress test2 = IPAddress.Loopback;
            IPAddress test3 = IPAddress.Broadcast;
            IPAddress test4 = IPAddress.Any;
            IPAddress test5 = IPAddress.None;

            IPHostEntry ihe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress myself = ihe.AddressList[0];
            if (IPAddress.IsLoopback(test2))
                Console.WriteLine("The Loopback address is: {0}",
                test2.ToString());
            else
                Console.WriteLine("Error obtaining the loopback address");
            Console.WriteLine("The Local IP address is: {0}\n",
            myself.ToString());
            if (myself == test2)
                Console.WriteLine("The loopback address is the same as local address.\n");
            else
                Console.WriteLine("The loopback address is not the local address.\n");
            Console.WriteLine("The test address is: {0}",
            test1.ToString());
            Console.WriteLine("Broadcast address: {0}",
            test3.ToString());
            Console.WriteLine("The ANY address is: {0}",
            test4.ToString());
            Console.WriteLine("The NONE address is: {0}",
            test5.ToString());
        }


        //internal class MyIPClass : NetworkScanner.MyIPClass
        //{
        //}
    }
}
