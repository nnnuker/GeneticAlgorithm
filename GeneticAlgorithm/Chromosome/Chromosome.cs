using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Chromosome
{
    public class Chromosome : IChromosome
    {
        #region Properties
        public double Accuracy { get; set; }
        public string Binary { get; }
        public double Value { get; set; }
        public int Length { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructors
        public Chromosome()
        {

        }

        public Chromosome(double accuracy, double left, double right, string name)
        {
            if (accuracy < 0 || left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Binary = GetBinary();
        }

        public Chromosome(double accuracy, double left, double right, double value, string name)
        {
            if (accuracy < 0 || left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Value = value;
            this.Binary = GetBinary();
        }
        #endregion

        #region Private methods
        private string GetBinary()
        {
            return "";
            GetLength();

            string[] sub = (this.Value).ToString(CultureInfo.InvariantCulture).Split('.');

            string result = null;

            result += GetFirstPart(sub[0]);
            //result += GetSecondPart(sub[1]);

            return result;
        }

        private double GetValue()
        {
            //throw new NotImplementedException();
            return BitConverter.Int64BitsToDouble(Convert.ToInt64(this.Binary, 2));
        }

        private void GetLength()
        {
            var bigger = Math.Abs(Left) > Math.Abs(Right) ? Math.Abs(Left) : Math.Abs(Right);

            bigger = Math.Truncate(bigger);

            var subStr = Convert.ToString(Convert.ToInt32(bigger.ToString(), 10), 2);


            Length = subStr.Length < 4 ? 4 : subStr.Length;
        }

        private string GetFirstPart(string sub)
        {
            var binaryStr = Convert.ToString(Convert.ToInt32(sub, 10), 2);
            if (binaryStr.Length < Length)
            {
                binaryStr.PadLeft(Length - binaryStr.Length, '0');
            }
            var add = Value < 0 ? "0" : "1";
            binaryStr.Insert(0, add);
            return binaryStr;
        }

        private string GetSecondPart(string sub)
        {
            //throw new NotImplementedException();
            var binaryStr = Convert.ToString(Convert.ToInt32(sub, 10), 2);

            if (binaryStr.Length < 4)
            {
                binaryStr.PadLeft(Length - binaryStr.Length, '0');
            }
            return binaryStr;
        }
        #endregion
    }
}
