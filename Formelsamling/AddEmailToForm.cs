using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Formelsamling.Authentication;
using System.Net.NetworkInformation;


namespace Formelsamling
{
    public partial class AddEmailToForm : Form
    {
        public AddEmailToForm()
        {
            InitializeComponent();
        }

        private void AddEmail_Click(object sender, EventArgs e)
        {
            var mac = GetMacAddress.ShowNetworkInterfaces();
            
            SQL.AddUser(EmailField.Text, mac);

        }
    }
}
