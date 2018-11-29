using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Security.Cryptography;


namespace Formelsamling.Authentication
{
    class GetMacAddress
    {
        public static PhysicalAddress GetPhysicalAddress()
        {
           
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
         
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return null;
            }
            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            foreach (NetworkInterface adapter in nics)
            {
                Console.WriteLine();
               
                Console.Write("  Physical address ........................ : ");
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Display the physical address in hexadecimal.
                    Console.Write("{0}", bytes[i].ToString("X2"));
                    // Insert a hyphen after each byte, unless we are at the end of the 
                    // address.
                    if (i != bytes.Length - 1)
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
                return address;
            }
            Console.WriteLine(nics.Length);
            return null;
        }
        public static int GetNumberOfMacs()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return 0;
            }
            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            return nics.Length;
           
        }

    }
}
