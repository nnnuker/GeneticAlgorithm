using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FactoryPoint;
using GeneticAlgorithm.FuncCalculator.SearchMethods;
using GeneticAlgorithm.Population;
using GeneticAlgorithm.SelectPoints;

namespace GeneticAlgorithm.FuncCalculator
{
    public class FuncCalculatorTruncation : IFuncCalculator
    {
        #region Fields

        private readonly Dictionary<int, string> populationDictionary = new Dictionary<int, string>()
        {
            {1, "GeneticAlgorithm.Population.RandomPopulation"},
            {2, "GeneticAlgorithm.Population.NetPopulation"}
        };

        private readonly Dictionary<int, string> selectDictionary = new Dictionary<int, string>()
        {
            {1, "GeneticAlgorithm.SelectPoints.ClassicRouletteSelectPoints"},
            {2, "GeneticAlgorithm.SelectPoints.RouletteSelectPoints"},
            {3, "GeneticAlgorithm.SelectPoints.TourSelectPoints"},
            {4, "GeneticAlgorithm.SelectPoints.RangSelectPoints"},
        };

        private readonly Dictionary<int, string> searchMethodDictionary = new Dictionary<int, string>()
        {
            {1, "GeneticAlgorithm.FuncCalculator.SearchMethods.BestProbe"},
            {2, "GeneticAlgorithm.FuncCalculator.SearchMethods.HukJivs"},
        };

        private readonly double maxX;
        private readonly double minX;
        private readonly double maxY;
        private readonly double minY;
        private readonly double s;
        private readonly double sDir;
        private readonly double searchMethodAccuracy;
        private readonly double funcCalculatorTruncationAccuracy;
        private IPopulation population;
        private ISelectPoints selectStartPoints;
        private ISelectPoints selectOtherPoints;
        private ISearchMethod searchMethod;
        private delegate int Search(IDesignPoint startPoint, out IDesignPoint newPoint);
        private Search search;

        #endregion

        #region Properties
        public List<IDesignPoint> AllPoints { get; set; }
        public string FuncExpression { get; set; }

        #endregion

        #region Constructors

        public FuncCalculatorTruncation()
        {

        }

        public FuncCalculatorTruncation(string expression, double minX, double  maxX, double minY, double maxY, 
            double s, double sDir, double searchMethodAccuracy, double funcCalculatorTruncationAccuracy)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            this.s = s;
            this.sDir = sDir;
            this.searchMethodAccuracy = searchMethodAccuracy;
            this.funcCalculatorTruncationAccuracy = funcCalculatorTruncationAccuracy;
            FuncExpression = expression;
            AllPoints = new List<IDesignPoint>();
        }

        #endregion

        #region Public methods

        public double CalculateFunc(params IChromosome[] x)
        {
            InitializeMethods(x);

            AllPoints.Clear();

            var startPoints = population.GetPopulation();

            var sunNPrevAndNNext = new List<IDesignPoint>();

            foreach (var designPoint in startPoints)
            {
                AllPoints.Add(designPoint);
                sunNPrevAndNNext.Add(designPoint);
            }

            double result = 0;
            IDesignPoint bestNPprev, bestNNext;
            double xx;
            do
            {
                IEnumerable<IDesignPoint> nPrev;
                if (result == 0)
                {
                    nPrev = selectStartPoints.SelectPoints((int) x[1].Value, sunNPrevAndNNext);
                }
                else
                {
                    nPrev = selectOtherPoints.SelectPoints((int)x[1].Value, sunNPrevAndNNext);
                }
                //var nPrev = result == 0 ? selectStartPoints.SelectPoints((int) x[1].Value, sunNPrevAndNNext) : 
                //    selectOtherPoints.SelectPoints((int)x[1].Value, sunNPrevAndNNext);

                sunNPrevAndNNext.Clear();

                bestNPprev = SelectMinFunctionValue(nPrev);

                foreach (var designPoint in nPrev)
                {
                    sunNPrevAndNNext.Add(designPoint);
                }

                var nNext = new List<IDesignPoint>();

                foreach (var itemPrev in nPrev)
                {
                    IDesignPoint newPoint;
                    result += search(itemPrev, out newPoint);

                    nNext.Add(newPoint);
                    AllPoints.Add(newPoint);
                    sunNPrevAndNNext.Add(newPoint);
                }

                bestNNext = SelectMinFunctionValue(nNext);

                xx = Math.Abs(Math.Abs(bestNNext.FunctionValue - bestNPprev.FunctionValue)/bestNPprev.FunctionValue);
            } while (xx >  funcCalculatorTruncationAccuracy);
            return result;

        }

        public bool Equals(IFuncCalculator other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return this.FuncExpression == other.FuncExpression;
        }

        #endregion

        #region Private methods

        private IDesignPoint SelectMinFunctionValue(IEnumerable<IDesignPoint> points)
        {
            var minValue = double.PositiveInfinity;
            IDesignPoint result = null;
            foreach (var designPoint in points)
            {
                if (designPoint.FunctionValue < minValue)
                {
                    minValue = designPoint.FunctionValue;
                    result = designPoint;
                }
            }
            return result;
        }

        private void InitializeMethods(params IChromosome[] x)
        {
            IChromosome chromoX = new Axis(0, minX, maxX, 0, "X");
            IChromosome chromoY = new Axis(0, minY, maxY, 0, "Y");

            foreach (var item in populationDictionary)
            {
                if (item.Key == (int) x[2].Value)
                {
                    population =(IPopulation)Activator.CreateInstance(Type.GetType(item.Value),
                        new CreatePoint(new FuncCalculatorBasic(FuncExpression)), (int) x[0].Value, 1, chromoX, chromoY); // new NetPopulation() ---
                    break;
                }
            }

            foreach (var item in selectDictionary)
            {
                if (item.Key == (int)x[3].Value)
                {
                    selectStartPoints = (ISelectPoints)Activator.CreateInstance(Type.GetType(item.Value)); // new RangSelectPoints() new TourSelectPoints() ---
                }
                if (item.Key == (int)x[6].Value)
                {
                    selectOtherPoints = (ISelectPoints)Activator.CreateInstance(Type.GetType(item.Value)); // new RangSelectPoints() new TourSelectPoints() ---
                }
            }

            foreach (var item in searchMethodDictionary)
            {
                if (item.Key == (int) x[4].Value)
                {
                    searchMethod = (ISearchMethod) Activator.CreateInstance(Type.GetType(item.Value), s, sDir, searchMethodAccuracy);//new Huk() ---
                    break;
                }
            }

            switch ((int)x[5].Value)
            {
                case 1:
                    search = searchMethod.CalculateMethodAll;
                    break;
                case 2:
                    search = searchMethod.CalculateMethodOne;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        #endregion
    }
}
