using System;
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

        public bool Equals(IFuncCalculator other)
        {
            throw new NotImplementedException();
        }
    }
}
