using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;

namespace PresentationFormsPart2
{
    public class DesignPointViewModel
    {
        private readonly IDesignPoint designPoint;

        public int Id
        {
            get { return designPoint.ID; }
            set { Id = value; }
        }

        public int PopulationNumber
        {
            get { return designPoint.PopulationNumber; }
            set { PopulationNumber = value; }
        }

        public double N
        {
            get { return designPoint.X.ToList().First(x => x.Name == "N").Value; }
            set { N = value; }
        }

        public double n
        {
            get { return designPoint.X.ToList().First(x => x.Name == "n").Value; }
            set { n = value; }
        }

        public double Population
        {
            get { return designPoint.X.ToList().First(x => x.Name == "population").Value; }
            set { Population = value; }
        }

        public double SelectStartPoints
        {
            get { return designPoint.X.ToList().First(x => x.Name == "selectStartPoints").Value; }
            set { SelectStartPoints = value; }
        }

        public double SearchMethod
        {
            get { return designPoint.X.ToList().First(x => x.Name == "searchMethod").Value; }
            set { SearchMethod = value; }
        }

        public double Search
        {
            get { return designPoint.X.ToList().First(x => x.Name == "search").Value; }
            set { Search = value; }
        }

        public double SelectOtherPoints
        {
            get { return designPoint.X.ToList().First(x => x.Name == "selectOtherPoints").Value; }
            set { SelectOtherPoints = value; }
        }

        public string Binary
        {
            get { return string.Join(",", designPoint.X1X2.ToArray()); }
            set { Binary = value; }
        }

        public bool IsMutate
        {
            get { return designPoint.IsMutate; }
            set { IsMutate = value; }
        }

        public double Value
        {
            get { return designPoint.FunctionValue; }
            set { Value = value; }
        }

        public List<IDesignPoint> AllPoints
        {
            get { return designPoint.AllPoints.ToList(); }
            set { AllPoints = value; }
        }

        public DesignPointViewModel(List<IDesignPoint> allPoints )
        {
            AllPoints = allPoints;
        }

        public DesignPointViewModel(IDesignPoint designPoint)
        {
            this.designPoint = designPoint;
        }
    }
}