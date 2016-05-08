using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SelectPoints
{
    public class RangSelectPoints : ISelectPoints
    {
        #region Fields

        private readonly List<int> arrayCoefficients;

        #endregion

        #region Constructors

        public RangSelectPoints() : this(null)
        {

        }

        public RangSelectPoints(params int[] arrayCoefficients)
        {
            if (arrayCoefficients == null)
                arrayCoefficients = new [] {2, 2};

            this.arrayCoefficients = new List<int>(arrayCoefficients);
        }

        #endregion

        #region Public method

        public IEnumerable<IDesignPoint> SelectPoints(int n, IEnumerable<IDesignPoint> designPoints)
        {
            if (designPoints == null) throw new ArgumentNullException(nameof(designPoints));

            if (n > designPoints.Count())
                throw new ArgumentException();

            var rangedList = GetRangedList(designPoints);

            var result = new List<IDesignPoint>();

            for (int i = 0; i < n; i++)
            {
                result.Add(rangedList[i]);
            }

            return result;
        }

        #endregion

        #region Private methods

        private List<int> GetCoefficients(int designPointsCount)
        {
            var result = arrayCoefficients;

            for (int i = arrayCoefficients.Count; i < designPointsCount; i++)
            {
                result.Add(1);
            }

            return result;
        }

        private List<IDesignPoint> GetRangedList(IEnumerable<IDesignPoint> designPoints)
        {
            var count = designPoints.Count();

            var coeffs = GetCoefficients(count);
            var rangedList = new List<IDesignPoint>();
            var sorted = designPoints.OrderBy(x => x.FunctionValue);

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < coeffs[i]; j++)
                {
                    rangedList.Add(sorted.ElementAt(i));
                }
            }

            return rangedList;
        }

        #endregion
    }
}
