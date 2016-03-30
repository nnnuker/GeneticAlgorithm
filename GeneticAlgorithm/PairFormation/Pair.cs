using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public class Pair : IPair
    {
        #region Property
        public IDesignPoint First { get; set; }
        public IDesignPoint Second { get; set; }
        #endregion  
    }
}
