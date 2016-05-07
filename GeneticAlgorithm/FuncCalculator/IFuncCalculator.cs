using System;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.FuncCalculator
{
    public interface IFuncCalculator : IEquatable<IFuncCalculator>
    {
        string FuncExpression { get; set; }
        double CalculateFunc(params IChromosome[] x);
    }
}