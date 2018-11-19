using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formelsamling.CustomDelegates;
using Formelsamling.Formulary;

namespace Formelsamling.Formulary.MathFormulary
{
    class SquareCircumference : IBaseFormula
    {
        public string FormulaName { get { return "Omkreds Firkant"; } }
        public List<string> VariableNames { get { return new List<string>() { "Sidelængde", "Omkreds" }; } }
        
        // finds omkreds
        public double Equation1(double[] sideLength)
        {
            return sideLength[0]*4; // just a test
        }

        // finds areal
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
