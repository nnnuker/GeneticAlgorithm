using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;

namespace GeneticAlgorithm.Crossover
{
    public interface ICrossover
    {
        IDesignPoint Crossover(IPair pair);
    }
}
