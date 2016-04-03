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
            this.Length = GetLength();
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
            this.Length = GetLength();
            this.Binary = GetBinary();
        }
        #endregion

        public double GetValue()
        {
            var sign = this.Binary.Substring(0, 1);
            var left = this.Binary.Substring(1, Length);
            left = left.TrimStart('0');
            left = left.Length == 0 ? "0" : left;
            var right = this.Binary.Substring(Length + 1);
            right = right.TrimStart('0');
            right = right.Length == 0 ? "0" : right;

            string result = string.Empty;

            if (sign == "0")
                result += "-";

            result += Convert.ToInt32(left, 2).ToString() + "." + Convert.ToInt32(right, 2).ToString();

            return Convert.ToDouble(result, CultureInfo.InvariantCulture);
        }

        #region Private methods
        private string GetBinary()
        {
            string[] sub = (Math.Abs(this.Value)).ToString(CultureInfo.InvariantCulture).Split('.');

            string result = null;

            result += GetFirstPart(sub[0]);

            if (sub.Length > 1)
                result += GetSecondPart(sub[1]);
            else
                result += GetSecondPart("0");

            return result;
        }

        private int GetLength()
        {
            var bigger = Math.Abs(Left) > Math.Abs(Right) ? Math.Abs(Left) : Math.Abs(Right);

            bigger = Math.Truncate(bigger);
            var subStr = Convert.ToString(Convert.ToInt32(bigger.ToString(), 10), 2);

            return subStr.Length < 4 ? 4 : subStr.Length;
        }

        private string GetFirstPart(string sub)
        {
            string binaryStr = Convert.ToString(Convert.ToInt32(sub, 10), 2);

            while (binaryStr.Length < Length)
            {
                binaryStr = binaryStr.Insert(0, "0");
            }

            var add = Value < 0 ? "0" : "1";
            binaryStr = binaryStr.Insert(0, add);
            return binaryStr;
        }

        private string GetSecondPart(string sub)
        {
            var binaryStr = Convert.ToString(Convert.ToInt32(sub, 10), 2);

            string[] subAcc = Accuracy.ToString(CultureInfo.InvariantCulture).Split('.');

            if (subAcc.Length <= 1)
                throw new ArgumentException();

            int j = 1;
            for (int i = 0; i < subAcc[1].Length; i++)
            {
                j *= j;
            }

            j = j - 1;

            var subStr = Convert.ToString(j, 2);

            int l = subStr.Length < 4 ? 4 : subStr.Length;

            while (binaryStr.Length < l)
            {
                binaryStr = binaryStr.Insert(0, "0");
            }
            return binaryStr;
        }
        #endregion
    }
}
