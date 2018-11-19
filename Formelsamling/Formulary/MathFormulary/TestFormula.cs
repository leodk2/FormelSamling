using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formelsamling.CustomDelegates;
using Formelsamling.Formulary;

namespace Formelsamling.Formulary.MathFormulary
{
    class TestFormula : IBaseFormula
    {
        public string FormulaName { get { return "Test"; } }
        public List<string> VariableNames { get { return new List<string>() { "1","2","3","4","5","6","7","8","9","10","11" }; } }
        
        // finds circumference
        public double Equation1(double[] sideLength)
        {
            return sideLength[0]; // just a test
        }

        // finds radius
        public double Equation2(double[] circumference)
        {
            return circumference[0]; // just a test
        }
        public double E3(double[] p) { return 0; }
        public double E4(double[] p) { return 0; }
        public double E5(double[] p) { return 0; }
        public double E6(double[] p) { return 0; }
        public double E7(double[] p) { return 0; }
        public double E8(double[] p) { return 0; }
        public double E9(double[] p) { return 0; }
        public double E10(double[] p) { return 0; }
        public double E11(double[] p) { return 0; }

        public List<EquationAction> Equations
        {
            get
            {
                return new List<EquationAction>() {
                    Equation1,
                    Equation2,
                    E3,
                    E4,
                    E5,
                    E6,
                    E7,
                    E8,
                    E9,
                    E10,
                    E11
                };
            }
        }
    }
}
