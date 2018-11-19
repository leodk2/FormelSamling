using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace Formelsamling
{
    /// <summary>
    /// This is where we put all of the networking, security and sql stuff
    /// </summary>
    //This class shall NOT under any circumstances be public!!!!
    //If you need this class as public then there is something wrong with your code!
    public class SQL
    {
        //this should propably get changed at some point
        static public SqlConnection sqlConnection = new SqlConnection("Data Source = lommeregner.database.windows.net; " +
            "Initial Catalog = LommeregnerInLogs; Integrated Security = False; User ID = Leo; " +
            "Password = Bionicle2018; Connect Timeout = 60; Encrypt = True; " +
            "TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

        static SqlCommand cmd;
        static SqlDataReader reader;

        static void Print(string a)
        {
            a = a.ToString();
            Console.WriteLine(a);
        }
        static void Print(object a)
        {
            a = a.ToString();
            Console.WriteLine(a);
        }
        
        public static void SqlConnect()
        {
            //initialize a new login screen to get the email.text property
            Login login = new Login();
            string SqlUserId = login.EmailField.Text;
            string SqlPass = SqlUserId;
            //create the connection to the sql server using my credentials



            //open the connection to the sql database
            sqlConnection.Open();
            Print("Åben");
            //I don't think that this method should be here in the final release of the program
            //SqlReader("Uid", "kim@strandjaegervej.dk", "Code1", sqlConnection);

        }

        //this method is run whenever we need to read something from the SQL database
        public static bool SqlReader(string columnHeader, string userToLookFor, string ItemToLookFor, SqlConnection sqlConnection)
        {
            try
            {
                //!! creates new cmd and reader. Problem is if it's called in different instances, it'll create a new for each
                if (cmd == null)
                {
                    cmd = new SqlCommand("select * from dbo.user_Codes", sqlConnection);
                    Console.WriteLine("new cmd");
                }
                if (reader != null)
                {
                    reader.Close();
                }
                reader = cmd.ExecuteReader();
                Print("new reader");

                Console.WriteLine(userToLookFor);

                // reads and stuff
                while (reader.Read())
                {
                    if (reader[columnHeader].ToString() == userToLookFor)
                    {
                        Print(reader[ItemToLookFor]);
                        Console.WriteLine("true");
                        return true;
                    }

                }
                Console.WriteLine("false");
                return false;
            }
            catch (Exception e)
            {
                Print(e.ToString());
                Print("false exception");
                return false;
            }

        }
        public SqlParameter SqlAddMac()
        {
            sqlConnection.Open();
            cmd = new SqlCommand ("INSERT INTO user_Codes(Mac) VALUES(@Mac)", sqlConnection);
            var add = cmd.Parameters.AddWithValue("@Mac", InternetAndSecurity.ShowNetworkInterfaces());
            cmd.ExecuteNonQuery();
            return add;
            
        }

    }
    public class InternetAndSecurity
    {

        


        #region Internet
        public static PhysicalAddress ShowNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            Console.WriteLine("Interface information for {0}",
                    computerProperties.HostName);
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                //return null;
            }

            Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length);
            foreach (NetworkInterface adapter in nics)
            {
                //IPInterfaceProperties properties = adapter.GetIPProperties(); //  .GetIPInterfaceProperties();
                Console.WriteLine();
                //Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
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
                        //return address;
                    }
                    
                }
                Console.WriteLine();
                address = PhysicalAddress.Parse(address.ToString());
                return  address;
            }
            return null;
        }

        #endregion

        public void Run()
        {
            ShowNetworkInterfaces();
            //SqlConnect();
        }
    }
}
