using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formelsamling.CustomDelegates;
using Formelsamling.Formulary;

namespace Formelsamling.Formulary.MathFormulary
{
    class CircleCircumference : IBaseFormula
    {
        public string FormulaName { get { return "Omkreds Cirkel"; } }
        public List<string> VariableNames { get { return new List<string>() { "Radius", "Omkreds" }; } }
        
        // finds circumference
        public double Equation1(double[] radius)
        {
            return radius[0]; // just a test
        }

        // finds radius
        public double Equation2(double[] circumference)
        {
            return circumference[0]; // just a test
        }

        public List<EquationAction> Equations
        {
            get
            {
                return new List<EquationAction>() {
                    Equation1,
                    Equation2,
                };
            }
        }


    }
    
}
