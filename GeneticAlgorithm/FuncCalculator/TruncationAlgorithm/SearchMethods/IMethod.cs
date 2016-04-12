using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SearchMethods
{
    public interface IMethod
    {
        double acaccuracy { get; set; }
        IDesignPoint startPoint { get; set; }
        double CalculateMethod(IDesignPoint startPoint, double acaccuracy, out IDesignPoint newPoint, out int countCalc);
    }
}
