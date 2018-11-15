using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using Formelsamling.Formulary;
using Formelsamling.Formulary.MathFormulary;
//using Formelsamling.Formulary.PhysicsFormulary;
// etc.

namespace Formelsamling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            generateTreeView();
        }

        // mathformulary
        List<IBaseFormula> mathFormulas = new List<IBaseFormula>();

        // keeps track of current values
        IBaseFormula currentFormula;
        int currentEquationIndex;
        List<TextBox> VariableInputs = new List<TextBox>();
        List<Label> VariableLabels = new List<Label>();
        double result = 0;
        
        

        // startup
        void generateTreeView()
        {
            #region alternative way
            // gets every class in namespace
            /*
            string nspace = "Formelsamling.Formulary.MathFormulary";
            var mathFormulass = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    select t;
            mathFormulass.ToList();

            TreeNode mathNode = FormelTree.Nodes.Add("Matematik");

            foreach (Type mathFormula in mathFormulass)
            {
                if (mathFormula.GetInterfaces().Contains(typeof(IBaseFormula)))
                {
                    mathNode.Nodes.Add(((IBaseFormula)Activator.CreateInstance(mathFormula.GetType())).FormulaName);
                }
                
            }
            */
            #endregion

            // add all types, could be made automatic but ok
            mathFormulas.Add(new CircleCircumference());
            mathFormulas.Add(new SquareCircumference());
            mathFormulas.Add(new BoxVolume());

            // generates TreeNodes
            TreeNode mathNode = FormelTree.Nodes.Add("Matematik");
            foreach (IBaseFormula formula in mathFormulas)
            {
                mathNode.Nodes.Add(formula.FormulaName);
            }
            
            
        }

        void GenerateCheckBox()
        {
            fVariables.Items.Clear();
            var variables = currentFormula.VariableNames;

            //fVariables.Items.


            for(int i = 0; i <= currentFormula.VariableNames.Count; i++)
            {
                fVariables.Items.Add(variables);
            }
            
        }


     /*   void GenerateComboBox(int varCount)
        {
            foreach(CheckBox checkBox in checkBoxes)
            {
                Controls.Remove(checkBox);
                checkBox.Dispose();
            }
            
        }
        */
        void GeneratePage(int varCount)
        {
            // clears page
            foreach (TextBox box in VariableInputs)
            {
                Controls.Remove(box);
                box.Dispose();
            }
            foreach (Label label in VariableLabels)
            {
                Controls.Remove(label);
                label.Dispose();
            }
            // clears lists
            VariableInputs.Clear();
            VariableLabels.Clear();
            
            // creates new textboxes
            for (int i = 0; i < varCount-1; i++)
            {
                // label
                Label label = new Label
                {
                    Text = currentFormula.VariableNames.ElementAt(i),
                    Size = new Size(100, 20),
                    Location = new Point(200 + i * 120, 80)
                };
                Controls.Add(label);
                VariableLabels.Add(label);

                // inputbox
                TextBox textBox = new TextBox
                {
                    Size = new Size(100, 20),
                    Location = new Point(200 + i * 120, 100)
                };
                Controls.Add(textBox);
                VariableInputs.Add(textBox);
            }
            GenerateCheckBox();
        }

        private void FormelTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (IBaseFormula formula in mathFormulas) // should be all (joined) formulas
            {
                if (e.Node.Text == formula.FormulaName) {
                    currentFormula = formula;
                    GeneratePage(formula.VariableNames.Count);
                    break;
                }
            }

        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (currentFormula != null)
            {
                List<double> parameters = new List<double>();
                foreach (TextBox tb in VariableInputs)
                {
                    parameters.Add(Convert.ToDouble(tb.Text));
                }

                result = currentFormula.Equations[0](parameters.ToArray());
                Console.WriteLine(result);
            }
        }
    }
}
