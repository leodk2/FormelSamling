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

        public static void SqlWrite(string email, string column)
        {
            sqlConnection.Open(); ;
            cmd = new SqlCommand("insert into dbo.user_Codes ("+column+") values ("+email+")", sqlConnection);
            // cmd = new SqlCommand("INSERT INTO ")
            //cmd = new SqlCommand("insert into dbo.user_Codes (UID), values(" + email + ")", sqlConnection);
            cmd.ExecuteNonQuery();
            Print(email);
            //cmd = new SqlCommand("insert intodbo.user_Codes("++")")
            sqlConnection.Close();
            
        }
        //this method is run whenever we need to read something from the SQL database
        public static bool SqlReader(string columnHeader, string userToLookFor, string ItemToLookFor, SqlConnection sqlConnection)
        {
            SqlConnect();
            try
            {
                //!! creates new cmd and reader. Problem is if it's called in different instances, it'll create a new for each
                if (cmd == null)
                {
                    cmd = new SqlCommand("select * from dbo.user_Codes", sqlConnection);
                    Console.WriteLine("new read");
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
                        sqlConnection.Close();
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
                sqlConnection.Close();
                return false;
            }
            
        }
        public SqlParameter SqlAddMac()
        {
            sqlConnection.Open();
            cmd = new SqlCommand ("INSERT INTO user_Codes(Mac) VALUES(@Mac)", sqlConnection);
            var add = cmd.Parameters.AddWithValue("@Mac", GetMacAddress.ShowNetworkInterfaces());
            cmd.ExecuteNonQuery();
            return add;
            
        }

    }

}
