using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formelsamling.CustomDelegates;

namespace Formelsamling.Formulary
{
    public interface IBaseFormula
    {
        // name of the formula
        string FormulaName { get; }

        // names of the variables
        List<string> VariableNames { get; }

        // delegate list of all the equation methods, length should be equal to VariableNames !!(can this be forced)?
        List<EquationAction> Equations { get; }
    }
}
