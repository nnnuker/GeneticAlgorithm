using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.FuncCalculator.SearchMethods
{
    public interface ISearchMethod
    { 
        double GlobalS { get; set; }
        double GlobalSDir { get; set; }
        double Accuracy { get; set; }
        int CalculateMethodOne(IDesignPoint startPoint, out IDesignPoint newPoint);
        int CalculateMethodAll(IDesignPoint startPoint, out IDesignPoint newPoint);
    }
}
