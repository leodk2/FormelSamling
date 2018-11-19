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
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* if (SQL.SqlReader("Uid", EmailField.Text,  "Mac", SQL.sqlConnection))
            {
                this.Hide();
                Formelsamling formelsamling = new Formelsamling();
                TreeNode[] treeNodes = new TreeNode[] { new MathFormulary().treeNode, new PhysicsFormulary().treeNode, };
                formelsamling.funcList.Nodes.AddRange(treeNodes);
                formelsamling.Show();
                Print("did this");


            }*/
      }
    }
}
