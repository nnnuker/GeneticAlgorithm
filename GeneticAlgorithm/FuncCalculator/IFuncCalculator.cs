using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.FuncCalculator
{
    public interface IFuncCalculator
    {
        string FuncExpression { get; set; }
        double CalculateFunc(params IChromosome[] x);
    }
}