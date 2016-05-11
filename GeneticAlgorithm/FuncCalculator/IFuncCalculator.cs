using System;
using System.Collections.Generic;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.FuncCalculator
{
    public interface IFuncCalculator : IEquatable<IFuncCalculator>
    {
        string FuncExpression { get; set; }
        List<IDesignPoint> AllPoints { get; set; }
        double CalculateFunc(params IChromosome[] x);
    }
}