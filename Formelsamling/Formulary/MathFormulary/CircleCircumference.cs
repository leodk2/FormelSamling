using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formelsamling.CustomDelegates;
using Formelsamling.Formulary;

using Formelsamling.Formulary.Properties;

namespace Formelsamling.Formulary.MathFormulary
{
    class CircleCircumference : IBaseFormula
    {
        public string FormulaName { get { return "Omkreds Cirkel"; } }
        public List<string> VariableNames { get { return new List<string>() { "Omkreds", "Radius" }; } }
        
        // finds circumference
        public double FindCirc(double[] Params)
        {
            return Params[1] * 2 * Constants.Pi; 
        }

        // finds radius
        public double FindRad(double[] Params)
        {
            return Params[0] / (Constants.Pi * 2);
        }

        public List<EquationAction> Equations
        {
            get
            {
                return new List<EquationAction>() {
                    FindCirc,
                    FindRad,
                };
            }
        }


    }
    
}
