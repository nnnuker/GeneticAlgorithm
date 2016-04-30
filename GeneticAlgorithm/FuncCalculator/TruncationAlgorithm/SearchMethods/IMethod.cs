using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SearchMethods
{
    public interface IMethod
    {
        double acaccuracy { get; set; }
        IDesignPoint startPoint { get; set; }
        double CalculateMethod(IDesignPoint startPoint, double acaccuracy, out IDesignPoint newPoint, out int countCalc);
    }
}
