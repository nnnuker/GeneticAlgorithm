using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GeneticAlgorithm.DesignPoints;
using Newtonsoft.Json;

namespace PresentationFormsPart2
{


    public class ParseDesignPointViewModel: ISerializable
    {
        public double N;
        public double n;
        public double Population;
        public double SelectStartPoints;
        public double SearchMethod;
        public double Search;
        public double SelectOtherPoints;

        public ParseDesignPointViewModel()
        {
            
        }
        public ParseDesignPointViewModel(SerializationInfo sInfo, StreamingContext contextArg)
        {
            this.N = (double)sInfo.GetValue("N", typeof(double));
            this.n = (double)sInfo.GetValue("n", typeof(double));
            this.Population = (double)sInfo.GetValue("Population", typeof(double));
            this.SelectStartPoints = (double)sInfo.GetValue("SelectStartPoints", typeof(double));
            this.SearchMethod = (double)sInfo.GetValue("SearchMethod", typeof(double));
            this.Search = (double)sInfo.GetValue("Search", typeof(double));
            this.SelectOtherPoints = (double)sInfo.GetValue("SelectOtherPoints", typeof(double));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("N", this.N);
            info.AddValue("n", this.n);
            info.AddValue("Population", this.Population);
            info.AddValue("SelectStartPoints", this.SelectStartPoints);
            info.AddValue("SearchMethod", this.SearchMethod);
            info.AddValue("Search", this.Search);
            info.AddValue("SelectOtherPoints", this.SelectOtherPoints);
        }
    }
}