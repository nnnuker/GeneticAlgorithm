using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public class Pair : IPair
    {
        #region Property
        public IDesignPoint First { get; set; }
        public IDesignPoint Second { get; set; }
        #endregion

        public bool Equals(IPair other)
        {
            if (other == null)
                return false;

            var flag = this.First?.Equals(other.First) ?? other.First == null;
            var flag1 = this.Second?.Equals(other.Second) ?? other.Second == null;

            return flag && flag1;
        }
    }
}
