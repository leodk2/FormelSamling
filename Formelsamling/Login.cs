using Formelsamling.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formelsamling
{
    public partial class Login : Form
    {
        static void Print(string a)
        {
            Console.WriteLine(a);
        }
        public Login()
        {
            InitializeComponent();
            NyBruger.AutoSize = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SQL.SqlReader("Email", EmailField.Text,  "Mac", SQL.sqlConnection))
            {
                this.Hide();
                FormelSamling formelsamling = new FormelSamling();
                formelsamling.Show();
                Print("did this");
                //this.Close();
                //this.Dispose();
                Print("Form Lukket");


            }
      }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NyBruger_Click(object sender, EventArgs e)
        {
            AddEmailToForm addEmailToForm = new AddEmailToForm();
            addEmailToForm.Location = this.Location;
            Point point = new Point();
            point = this.Location;
            addEmailToForm.Location = point;

            addEmailToForm.Show();
            this.Hide();
            Print("Form lukket");
        }
    }
}
