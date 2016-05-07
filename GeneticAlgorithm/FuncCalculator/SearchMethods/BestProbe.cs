using System;
using System.Collections.Generic;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.FuncCalculator.SearchMethods
{
    public class BestProbe : ISearchMethod
    {
        public double GlobalS { get; set; }
        public double GlobalSDir { get; set; }
        public double Accuracy { get; set; }
        private readonly Random rnd;

        public BestProbe()
        {
            rnd = new Random((int)(DateTime.Now.Ticks));
        }

        public BestProbe(double s, double sDir, double acaccuracy) : this()
        {
            this.GlobalS = s;
            this.GlobalSDir = sDir;
            this.Accuracy = acaccuracy;
        }

        public int CalculateMethodOne(IDesignPoint startPoint, out IDesignPoint newPoint)
        {
            var SDir = GlobalSDir;
            var S = GlobalS;
            var countCalculate = 0;

            var currentValue = startPoint.FunctionValue;
            var pointCurrent = new List<double> { startPoint.X[0].Value, startPoint.X[1].Value };

            var arrayAngles = new List<int>();

            var m = rnd.Next(5, 11);
            while (m > 0)
            {
                var exit = false;
                do
                {
                    var newDegreese = rnd.Next(0, 361);
                    if (!arrayAngles.Contains(newDegreese))
                    {
                        exit = true;
                        arrayAngles.Add(newDegreese);
                    }

                } while (exit != true);
                m--;
            }


            var valueAngles = new List<double>();

            for (var i = 0; i < arrayAngles.Count; i++)
            {
                var xx = pointCurrent[0] + Math.Cos(arrayAngles[i] * Math.PI / 180) * S;
                var X = new Axis(0, 0, 0, xx, "X");
                var yy = pointCurrent[1] + Math.Sin(arrayAngles[i] * Math.PI / 180) * S;
                var Y = new Axis(0, 0, 0, yy, "Y");
                valueAngles.Add(new FuncCalculatorBasic(startPoint.FuncCalculator.FuncExpression).CalculateFunc(X, Y));
                countCalculate++;
            }

            var minFunc = currentValue;
            var minI = 0;

            for (var i = 0; i < valueAngles.Count; i++)
            {
                if (valueAngles[i] < minFunc)
                {
                    minFunc = valueAngles[i];
                    minI = i;
                }
            }

            pointCurrent[0] = pointCurrent[0] + Math.Cos(arrayAngles[minI] * Math.PI / 180) * SDir;
            pointCurrent[1] = pointCurrent[1] + Math.Sin(arrayAngles[minI] * Math.PI / 180) * SDir;
            countCalculate++;


            var funcCalculator = new FuncCalculatorBasic(startPoint.FuncCalculator.FuncExpression);
            var x = new Axis(startPoint.X[0].Accuracy, startPoint.X[0].Left, startPoint.X[0].Right, pointCurrent[0],
                startPoint.X[0].Name);
            var y = new Axis(startPoint.X[1].Accuracy, startPoint.X[1].Left, startPoint.X[1].Right, pointCurrent[1],
                startPoint.X[1].Name);
            newPoint = new Point(startPoint.PopulationNumber, ++startPoint.ID, funcCalculator, x,
                y);
            return countCalculate;

        }

        public int CalculateMethodAll(IDesignPoint startPoint, out IDesignPoint newPoint)
        {
            var SDir = GlobalSDir;
            var S = GlobalS;

            var countCalculate = 0;

            var currentValue = startPoint.FunctionValue;
            var pointCurrent = new List<double> { startPoint.X[0].Value, startPoint.X[1].Value };

            while (true)
            {
                var arrayAngles = new List<int>();

                var m = rnd.Next(5, 11);
                while (m > 0)
                {
                    var exit = false;
                    do
                    {
                        var newDegreese = rnd.Next(0, 361);
                        if (!arrayAngles.Contains(newDegreese))
                        {
                            exit = true;
                            arrayAngles.Add(newDegreese);
                        }

                    } while (exit != true);
                    m--;
                }

                //arrayAngles.Add(100); arrayAngles.Add(200); arrayAngles.Add(150);
                //arrayAngles.Add(300); arrayAngles.Add(70); arrayAngles.Add(85);

                var valueAngles = new List<double>();

                for (var i = 0; i < arrayAngles.Count; i++)
                {
                    var x = pointCurrent[0] + Math.Cos(arrayAngles[i] * Math.PI / 180) * S;
                    var X = new Axis(0, 0, 0, x, "X");
                    var y = pointCurrent[1] + Math.Sin(arrayAngles[i] * Math.PI / 180) * S;
                    var Y = new Axis(0, 0, 0, y, "Y");
                    valueAngles.Add(new FuncCalculatorBasic(startPoint.FuncCalculator.FuncExpression).CalculateFunc(X, Y));
                    countCalculate++;
                }

                var minFunc = currentValue;
                var minI = 0;

                for (var i = 0; i < valueAngles.Count; i++)
                {
                    if (valueAngles[i] < minFunc)
                    {
                        minFunc = valueAngles[i];
                        minI = i;
                    }
                }

                if (minI == 0)
                {
                    S = S / 1.5;
                    SDir = SDir / 1.5;
                }
                else
                {
                    pointCurrent[0] = pointCurrent[0] + Math.Cos(arrayAngles[minI] * Math.PI / 180) * SDir;
                    var X = new Axis(0, 0, 0, pointCurrent[0], "X");
                    pointCurrent[1] = pointCurrent[1] + Math.Sin(arrayAngles[minI] * Math.PI / 180) * SDir;
                    var Y = new Axis(0, 0, 0, pointCurrent[1], "Y");
                    currentValue = new FuncCalculatorBasic(startPoint.FuncCalculator.FuncExpression).CalculateFunc(X, Y);
                    countCalculate++;
                }

                if (S < Accuracy)
                {
                    var funcCalculator = new FuncCalculatorBasic(startPoint.FuncCalculator.FuncExpression);
                    var x = new Axis(startPoint.X[0].Accuracy, startPoint.X[0].Left, startPoint.X[0].Right, pointCurrent[0],
                        startPoint.X[0].Name);
                    var y = new Axis(startPoint.X[1].Accuracy, startPoint.X[1].Left, startPoint.X[1].Right, pointCurrent[1],
                        startPoint.X[1].Name);
                    newPoint = new Point(startPoint.PopulationNumber, startPoint.ID, funcCalculator, x,
                        y);
                    return countCalculate;
                }
            }
        }
    }
}