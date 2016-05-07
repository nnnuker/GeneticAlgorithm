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
        private readonly double maxX;
        private readonly double minX;
        private readonly double maxY;
        private readonly double minY;
        private readonly double s;
        private readonly double sDir;
        private readonly double searchMethodAccuracy;
        private readonly double funcCalculatorTruncationAccuracy;


        private Dictionary<int, string> populationDictionary = new Dictionary<int, string>()
        {
            {1, "GeneticAlgorithm.Population.RandomPopulation"}
        };
        private IPopulation population;
        private ISelectPoints selectStartPoints;
        private ISelectPoints selectOtherPoints;
        private ISearchMethod searchMethod;
        private Search search;

        public List<IDesignPoint> allPoints { get; set; }

        private delegate int Search(IDesignPoint startPoint, out IDesignPoint newPoint);

        public string FuncExpression { get; set; }

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
            allPoints = new List<IDesignPoint>();
        }

        public double CalculateFunc(params IChromosome[] x)
        {
            InitializeMethods(x);

            var startPoints = population.GetPopulation();

            var sunNPrevAndNNext = new List<IDesignPoint>();

            foreach (var designPoint in startPoints)
            {
                allPoints.Add(designPoint);
                sunNPrevAndNNext.Add(designPoint);
            }

            double result = 0;
            IDesignPoint bestNPprev, bestNNext;
            double k;
            do
            { 
                var nPrev = result == 0 ? selectStartPoints.SelectPoints((int) x[1].Value, sunNPrevAndNNext) : 
                    selectOtherPoints.SelectPoints((int)x[1].Value, sunNPrevAndNNext);

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
                    allPoints.Add(newPoint);
                    sunNPrevAndNNext.Add(newPoint);
                }

                bestNNext = SelectMinFunctionValue(nNext);
            } while (Math.Abs(Math.Abs(bestNNext.FunctionValue - bestNPprev.FunctionValue) / bestNPprev.FunctionValue) 
            > funcCalculatorTruncationAccuracy);
            return result;

        }
        
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
                    var t = Type.GetType(item.Value);

                    object[] args = { };
                    population = (IPopulation)Activator.CreateInstance(Type.GetType(item.Value), new CreatePoint(new FuncCalculatorBasic(FuncExpression)),
                        (int)x[0].Value, 1, chromoX, chromoY); // new NetPopulation() ---
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            //switch ((int)x[2].Value)
            //{
            //    case 1:
            //        population = new RandomPopulation(new CreatePoint(new FuncCalculatorBasic(FuncExpression)),
            //            (int) x[0].Value, 1, chromoX, chromoY);
            //        break;
            //    case 2:
            //        population = new NetPopulation(); // - 
            //        break;
            //    default:
            //        throw new ArgumentException();
            //}

            switch ((int)x[3].Value)
            {
                case 1:
                    selectStartPoints = new ClassicRouletteSelectPoints();
                    break;
                case 2:
                    selectStartPoints = new RouletteSelectPoints();
                    break;
                case 3:
                    selectStartPoints = new RangSelectPoints(); // - 
                    break;
                case 4:
                    selectStartPoints = new TourSelectPoints(); // - 
                    break;
                default:
                    throw new ArgumentException();
            }
            switch ((int)x[4].Value)
            {
                case 1:
                    searchMethod = new BestProbe(s, sDir, searchMethodAccuracy);
                    break;
                case 2:
                    searchMethod = new HukJivs(); // - 
                    break;
                default:
                    throw new ArgumentException();
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
            switch ((int)x[6].Value)
            {
                case 1:
                    selectOtherPoints = new ClassicRouletteSelectPoints();
                    break;
                case 2:
                    selectOtherPoints = new RouletteSelectPoints();
                    break;
                case 3:
                    selectOtherPoints = new RangSelectPoints();
                    break;
                case 4:
                    selectOtherPoints = new TourSelectPoints();
                    break;
                default:
                    throw new ArgumentException();
            }

        }
    }
}
