﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Formelsamling.Authentication;

namespace Formelsamling
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("skreven linje");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // authenticate
            FormelSamling form = new FormelSamling();
            Login login = new Login();
            //SQL.SqlConnect();
            GetMacAddress.GetPhysicalAddress();

            // run program
            Application.Run(login);
        }
    }
}
