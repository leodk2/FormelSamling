﻿using System;
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

            // automatically finds all formulas in namespace
            var Types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace.StartsWith("Formelsamling.Formulary.MathFormulary"));
            foreach (var t in Types)
            {
                mathFormulas.Add((IBaseFormula)Activator.CreateInstance(t));
            }

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

            fVariables.Items.Clear();


            // clears lists
            VariableInputs.Clear();
            VariableLabels.Clear();
            
            // loop through each variable and create textboxes, labels and populate the checkboxlist
            for (int i = 0; i < varCount; i++)
            {
                /// labels
                Label label = new Label
                {
                    Text = currentFormula.VariableNames[i],
                    Size = new Size(100, 20),
                    Location = new Point(200 + i * 120, 80)
                };
                Controls.Add(label);
                VariableLabels.Add(label);

                // inputboxes
                TextBox textBox = new TextBox
                {
                    Size = new Size(100, 20),
                    Location = new Point(200 + i * 120, 100)
                };
                // if first, disable
                if (i == 0)
                {
                    textBox.Enabled = false;
                }
                Controls.Add(textBox);
                VariableInputs.Add(textBox);

                /// checkboxlist
                // check box if first index
                if (i == 0)
                {
                    fVariables.Items.Add(currentFormula.VariableNames[i], true);
                }
                else
                {
                    fVariables.Items.Add(currentFormula.VariableNames[i]);
                }

            }
        }

        void ChangeEquation()
        {
            for (int i = 0; i < VariableInputs.Count; i++)
            {
                if (i == currentEquationIndex)
                {
                    VariableInputs[i].Enabled = false;
                }
                else
                {
                    VariableInputs[i].Enabled = true;
                }
            }
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

        // on calculation button pressed
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (currentFormula != null)
            {
                List<double> parameters = new List<double>();
                foreach (TextBox tb in VariableInputs)
                {
                    if (Double.TryParse(tb.Text, out double num))
                    {
                        parameters.Add(num);
                    }
                    else
                    {
                        parameters.Add(0);
                    }
                }

                result = currentFormula.Equations[currentEquationIndex](parameters.ToArray());
                Console.WriteLine(result);
            }
        }

        private void fVariables_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // uncheck checked previously checked item so only 1 item is checked
            if (e.NewValue == CheckState.Checked)
            {
                for (int ix = 0; ix < fVariables.Items.Count; ++ix)
                {
                    if (e.Index != ix) fVariables.SetItemChecked(ix, false);
                }
                currentEquationIndex = e.Index;
                ChangeEquation();
            }
            
        }
    }
}
