using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.FuncCalculator
{
    class FuncCalculatorTruncation : IFuncCalculator
    {
        public string FuncExpression { get; set; }

        public double CalculateFunc(params IChromosome[] x)
        {
            throw new NotImplementedException();
        }
    }
}
