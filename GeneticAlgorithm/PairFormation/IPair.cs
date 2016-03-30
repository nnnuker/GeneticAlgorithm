using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public interface IPair
    {
        IDesignPoint First { get; set; }
        IDesignPoint Second { get; set; }
    }
}
