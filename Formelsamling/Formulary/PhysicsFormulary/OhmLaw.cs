using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formelsamling.CustomDelegates;

namespace Formelsamling.Formulary.PhysicsFormulary
{
    class OhmsLaw : IBaseFormula
    {

     
        public string FormulaName { get { return "Ohms lov"; } }
        public List<string> VariableNames { get { return new List<string> { "Spændingsforskel", "Modstand", "strømstyrke" }; } }
        ///<summary>
        ///    Ohms law
        ///</summary>
        ///<param name="Params">
        ///     spændningsforskel
        ///     modstand
        ///     strømstyrke
        ///</param>
        ///<returns>
        ///     spændningsforskel
        ///</returns>
        public double Spændning(double[] Params)
        {
            
            return Params[0]= Params[1] * Params[2];
        }
        ///<param name="Params">
        ///     spændningsforskel
        ///     modstand
        ///     strømstyrke
        ///</param>
       
        public double Strømstyrke(double[] Params)
        {
            return Params[2] = Params[0] / Params[1];
        }
        ///<param name="Params">
        ///     spændningsforskel
        ///     modstand
        ///     strømstyrke
        ///</param>
        public double Modstand(double[] Params)
        {
            return Params[2]= Params[0]/ Params[1];
            
        }
        


        public List<EquationAction> Equations
        {
            get
            {
                return new List<EquationAction>() {
                    Spændning,
                    Strømstyrke,
                    Modstand,
                };
            }
        }
    }
}
