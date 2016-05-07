using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.FuncCalculator.SearchMethods
{
    public class HukJivs: ISearchMethod
    {
        public double GlobalS { get; set; }
        public double GlobalSDir { get; set; }
        public double Accuracy { get; set; }

        public int CalculateMethodOne(IDesignPoint startPoint, out IDesignPoint newPoint)
        {
            throw new System.NotImplementedException();
        }

        public int CalculateMethodAll(IDesignPoint startPoint, out IDesignPoint newPoint)
        {
            throw new System.NotImplementedException();
        }
    }
}