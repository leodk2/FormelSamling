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
        public List<string> VariableNames { get { return new List<string>() { "Omkreds", "Sidelængde" }; } }
        
        // finds circumference
        public double FindCirc(double[] Params)
        {
            return 4 * Params[1];
        }

        // finds radius
        public double FindSide(double[] Params)
        {
            return Params[0] / 4;
        }

        public List<EquationAction> Equations
        {
            get
            {
                return new List<EquationAction>() {
                    FindCirc,
                    FindSide
                };
            }
        }
    }
}
