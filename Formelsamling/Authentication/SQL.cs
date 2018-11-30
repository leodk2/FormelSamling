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
using Formelsamling.Authentication;

namespace Formelsamling.Authentication
{
    /// <summary>
    /// This is where we put all of the sql stuff
    /// </summary>
    public class SQL
    {
        //this should propably get changed at some point
        static public SqlConnection sqlConnection = new SqlConnection("Data Source = lommeregner.database.windows.net; " +
            "Initial Catalog = LommeregnerInLogs; Integrated Security = False; User ID = Leo; " +
            "Password = Bionicle2018; Connect Timeout = 60; Encrypt = True; " +
            "TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");


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
        
        
#region SQL
        static SqlCommand cmd;
        static SqlDataReader reader;
        public static string AddGnyph(string str)
        {
            return str.Insert(0, "'") + "'";
        }
     
        public static void AddToDB(string email, string macAddress, string numOfMacs, SqlConnection sqlConnection)
        {
            AddGnyph(email); AddGnyph(macAddress); AddGnyph(numOfMacs);
            string cmdStr = "insert into dbo.userLogin (Email, Mac,  NoOfMacs) values(" + AddGnyph(email) + ", "+AddGnyph(macAddress)+"," + numOfMacs + ")";
            Print(cmdStr);
            sqlConnection.Open();
            cmd = new SqlCommand(cmdStr, sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

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
#endregion

    }

}
