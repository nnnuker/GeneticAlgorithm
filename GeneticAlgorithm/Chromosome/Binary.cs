using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GeneticAlgorithm.Chromosome
{
    public class Binary : IBinary
    {
        #region Fields

        private int firstPartLength;
        private int secondPartLength;
        private double value;
        private readonly int accuracy;
        private readonly double left;
        private readonly double right;
        private List<byte> binaryValue = new List<byte>();

        #endregion

        #region Properties

        public double Value => value;
        public IEnumerable<byte> BinaryValue => binaryValue;
        public int Length => binaryValue.Count();

        #endregion

        #region Constructors

        public Binary()
        {
        }

        public Binary(double value, double left, double right) : this(value, 0, left, right)
        {
        }

        public Binary(double value, int accuracy, double left, double right)
        {
            this.value = value;
            this.accuracy = accuracy;
            this.left = left;
            this.right = right;
            GetBinaryValue();
        }

        #endregion

        #region Public method

        public override string ToString()
        {
            return string.Join(string.Empty, BinaryValue);
        }

        public double Update(IEnumerable<byte> binaryValue)
        {
            if (firstPartLength + secondPartLength + 1 != binaryValue.Count())
                throw new ArgumentException();

            var list = binaryValue.ToList();

            var firstPart = list.GetRange(1, firstPartLength);

            var first = Convert.ToInt32(string.Join(string.Empty, firstPart), 2);

            var secondPart = list.GetRange(firstPartLength + 1, secondPartLength);

            var join = string.Join(string.Empty, secondPart);

            string sec = string.Empty;

            if (join != string.Empty)
            {
                int second = Convert.ToInt32(join, 2);

                sec = "." + second.ToString();
            }

            string sign = list[0] == 1 ? "" : "-";

            var result = Convert.ToDouble($"{sign}{first.ToString()}{sec}", CultureInfo.InvariantCulture);

            this.binaryValue = list;
            this.value = result;

            return result;
        }

        #endregion

        #region Private methods

        private void GetBinaryValue()
        {
            var absValue = Math.Abs(value);
            binaryValue.Add(value >= 0 ? (byte)1 : (byte)0);

            var floor = (int)Math.Floor(absValue);

            var bigger = Math.Abs(left) > Math.Abs(right) ? Math.Abs(left) : Math.Abs(right);

            binaryValue.AddRange(GetFirstPart(floor, Convert.ToInt32(Math.Truncate(bigger))));

            var minus = absValue - floor;
            if (minus > 0)
            {
                var str = minus.ToString(CultureInfo.InvariantCulture);
                var intFraction = int.Parse(str.Substring(str.IndexOf('.') + 1));
                binaryValue.AddRange(GetSecondPart(intFraction, accuracy));
            }
            else
            {
                binaryValue.AddRange(GetSecondPart(0, accuracy));
            }
        }

        private int GetLength(int acc)
        {
            var subStr = Convert.ToString(acc, 2);

            return subStr.Length < 4 ? 4 : subStr.Length;
        }

        private IEnumerable<byte> GetFirstPart(int val, int acc)
        {
            var max = GetLength(acc);
            string binaryStr = Convert.ToString(val, 2);

            while (binaryStr.Length < max)
            {
                binaryStr = binaryStr.Insert(0, "0");
            }

            firstPartLength = binaryStr.Length;

            return binaryStr.ToCharArray().Select(y => (byte)char.GetNumericValue(y));
        }

        private IEnumerable<byte> GetSecondPart(int val, int accuracy)
        {
            if (accuracy == 0)
            {
                return new List<byte> { };
            }

            var binaryStr = Convert.ToString(val, 2);

            int j = 1;
            for (var i = 0; i < accuracy; i++)
            {
                j *= 10;
            }

            j = j - 1;

            int len = GetLength(j);

            while (binaryStr.Length < len)
            {
                binaryStr = binaryStr.Insert(0, "0");
            }

            secondPartLength = binaryStr.Length;

            return binaryStr.ToCharArray().Select(y => (byte)char.GetNumericValue(y));
        }
        #endregion
    }
}