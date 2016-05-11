using System;
using System.Collections.Generic;
using Bestcode.MathParser;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.FuncCalculator
{
    public class FuncCalculatorBasic : IFuncCalculator
    {
        #region Properties

        public string FuncExpression { get; set; }
        public List<IDesignPoint> AllPoints { get; set; }

        #endregion

        #region Constructors

        public FuncCalculatorBasic()
        {

        }

        public FuncCalculatorBasic(string expression)
        {
            FuncExpression = expression;
        }

        #endregion

        #region Public methods

        public double CalculateFunc(params IChromosome[] x)
        {
            MathParser parser = new MathParser();
            foreach (IChromosome item in x)
            {
                parser.SetVariable(item.Name, item.Value, null);
            }
            parser.Expression = FuncExpression;
            return parser.ValueAsDouble;
        }

        public bool Equals(IFuncCalculator other)
        {
            if (other == null) return false;

            return this.FuncExpression == other.FuncExpression;
        }

        #endregion
    }
}