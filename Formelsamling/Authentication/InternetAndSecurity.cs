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
using System.IO;

namespace Formelsamling.Authentication
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
        #region SqlWrite
        public static void SqlWrite(string email, string column)
        {
            sqlConnection.Open();
            cmd = new SqlCommand("insert into dbo.user_Codes (" + column + ") values (" + email + ")", sqlConnection);
            cmd.ExecuteNonQuery();
            Print(email);
            sqlConnection.Close();

        }
        public string AddGnyph(string str)
        {
            return str.Insert(0, "'") + "'";
        }
        public string AddGnyph(NetworkInterface[] interfaces)
        {
            int arrayLength = interfaces.Length;
            string str = arrayLength.ToString();
            string rtnStr = str.Insert(0, "'") + "'";
            return rtnStr;
        }
        public static void AddUser(string email, PhysicalAddress interfaces)
        {
            sqlConnection.Open();
            Print(interfaces);
            try
            {
                SQL sql = new SQL();
                email = sql.AddGnyph(email);
                //string interfacesStr = sql.AddGnyph(interfaces);
                Console.WriteLine("|-|-|-|-|-|-|-|-|-|-|-|-| " + sql.AddGnyph(interfaces.ToString()));
                string macString =
                    (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                    ).FirstOrDefault();
                //macString = sql.AddGnyph(macString);
                //Console.WriteLine("|+|+|+|+|+|+|+|+|+|+|+|+| " + macString); 

                var arrayIndexStr = sql.AddGnyph(interfaces.ToString());
                //string finalString = email + "," + interfacesStr;
                string interfacer = sql.AddGnyph(interfaces.ToString());
                string finalString = email + "," + interfacer;
                cmd = new SqlCommand("insert into dbo.user_Codes(Uid, NoOfMacs) Values (" + finalString + ")", sqlConnection);
                //AddMac(interfaces, sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                //Vi kan ikke lave en kommando som tilføjer alle tre værdier på en gang, vi får en fejl hvis vi gør
                //og vi kan heller ikke lave en ny sql command
            }
            catch (Exception e)
            {
                Print(e.ToString());
                Print("false exception");
                sqlConnection.Close();
                return;
            }


        }
        public static void AddMac(NetworkInterface[] networkInterfaces, SqlConnection sqlConnection)
        {
            SQL sql = new SQL();
            var arrayIndexStr = sql.AddGnyph(networkInterfaces[0].ToString());
            cmd = new SqlCommand("insert into dbo.user_Codes(Mac) Values(" + arrayIndexStr + ")", sqlConnection);
            cmd.ExecuteNonQuery();
        }
        #endregion
        public static SqlParameter SqlAddMac()
        {
            sqlConnection.Open();
            cmd = new SqlCommand("INSERT INTO user_Codes(Mac) VALUES(@Mac)", sqlConnection);
            var add = cmd.Parameters.AddWithValue("@Mac", GetMacAddress.ShowNetworkInterfaces());
            cmd.ExecuteNonQuery();
            return add;

        }
        //this method is run whenever we need to read something from the SQL database
        public static bool SqlReader(string columnHeader, string userToLookFor, string ItemToLookFor, SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            try
            {
                //laver kommandoen som bliver sendt til databasen
                cmd = new SqlCommand("select " + ItemToLookFor + " from dbo.UserLogin;", sqlConnection);
                //kommandoen bliver sendt
                reader = cmd.ExecuteReader();
                //readeren læser gennem databasen 
                while (reader.Read())
                {
                    //Der bliver tjekket for om det som readeren læser i databasen er ens med det som er sat in som parameter
                    if (reader[columnHeader].ToString() == userToLookFor)
                    {
                        Print(userToLookFor);
                        Print("True");
                        return true;
                    }
                    else
                    {
                        Print("False");
                        return false;
                    }

                }
            }

            catch (Exception e)
            {
                Print(e.ToString());
                Print("false exception");
                sqlConnection.Close();
                return false;

            }
            return false;
        }

    }
}
