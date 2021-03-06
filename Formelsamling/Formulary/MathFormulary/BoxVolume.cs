﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formelsamling.CustomDelegates;
using Formelsamling.Formulary;

namespace Formelsamling.Formulary.MathFormulary
{
    class BoxVolume : IBaseFormula
    {
        public string FormulaName { get { return "Rumfang Kasse"; } }
        public List<string> VariableNames { get { return new List<string>() { "Rumfang", "Højde", "Længde", "Bredde" }; } }

        /// <summary>
        ///     calulated volume
        /// </summary>
        ///<param name="Params">
        ///     volume
        ///     height
        ///     length
        ///     width
        /// </param>
        /// <returns>
        ///     volume
        /// </returns>
        public double Equation1(double[] Params)
        {
            return Params[1] * Params[2] * Params[3];
        }

        // finds Height
        public double Equation2(double[] Params)
        {
            return Params[0] / (Params[2] * Params[3]);
        }

        // finds Width
        public double Equation3(double[] Params)
        {
            return Params[0] / (Params[1] * Params[3]);
        }

        // finds Length
        public double Equation4(double[] Params)
        {
            return Params[0] / (Params[1] * Params[2]);
        }

        public List<EquationAction> Equations
        {
            get
            {
                return new List<EquationAction>() {
                    Equation1,
                    Equation2,
                    Equation3,
                    Equation4
                };
            }
        }


    }
    
}
