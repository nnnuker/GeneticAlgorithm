using Bestcode.MathParser;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.FuncCalculator
{
    public class FuncCalculatorBasic : IFuncCalculator
    {
        public string FuncExpression { get; set; }

        public FuncCalculatorBasic()
        {

        }

        public FuncCalculatorBasic(string expression)
        {
            FuncExpression = expression;
        }

        public double CalculateFunc(params IChromosome[] x)
        {
            try
            {
                MathParser parser = new MathParser();
                foreach (IChromosome item in x)
                {
                    parser.SetVariable(item.Name, item.Value, null);
                }
                parser.Expression = FuncExpression;
                return parser.ValueAsDouble;
            }
            catch (ParserException)
            {
                return 0;
            }
        }
    }
}