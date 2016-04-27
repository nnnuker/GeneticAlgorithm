﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;

namespace GeneticAlgorithm.DesignPoints
{ 
    public class Point : IDesignPoint
    {
        public bool IsAlive
        {
            get
            {
                return X.All(item => item.IsCorrect);
            }
        }

        public bool IsMutate { get; set; }
        public IEnumerable<byte> X1X2 { get; set; }

        public static int CountID { get; set; } = 0;
        public IFuncCalculator FuncCalculator { get; set; }

        public double FunctionValue { get; set; }
        public int ID { get; set; }
        public int PopulationNumber { get; set; }
        public List<IChromosome> X { get; set; }

        public Point()
        {
            CountID++;
        }

        public Point(int populationNumber, IFuncCalculator funcCalculator, params IChromosome[] x) : this()
        {
            if (x == null)
                throw new ArgumentNullException();

            if (populationNumber < 0)
                throw new ArgumentOutOfRangeException();

            this.PopulationNumber = populationNumber;
            this.ID = CountID;
            this.X = new List<IChromosome>(x);
            this.FuncCalculator = funcCalculator;
            this.FunctionValue = funcCalculator.CalculateFunc(x);
            
        }

        public IDesignPoint Clone()
        {
            return new Point
            {
                FunctionValue = this.FunctionValue,
                FuncCalculator = this.FuncCalculator,
                X = this.X,
                PopulationNumber = this.PopulationNumber,
                X1X2 = this.X1X2,
                ID = CountID
            };
        }

        public void Update(IEnumerable<byte> s)
        {
            
        }
    }
}
