using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.FactoryPoint
{
    public interface IFactoryPoints
    {
        IDesignPoint CreateFactoryPoint(int populationNumber, int id, IChromosome[] chromo);
    }
}
