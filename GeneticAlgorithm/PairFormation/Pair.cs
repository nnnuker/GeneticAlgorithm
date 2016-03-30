using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public class Pair : IPair
    {
        public IDesignPoint First { get; set; }
        public IDesignPoint Second { get; set; }
    }
}
