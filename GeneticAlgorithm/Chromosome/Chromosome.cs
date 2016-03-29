﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Chromosome
{
    public class Chromosome : IChromosome
    {
        #region Properties
        public string Binary
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double Value
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double Accuracy { get; set; }

        public double Left
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double Right
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        public Chromosome(double accuracy, double left, double right, string name)
        {
            if (accuracy < 0)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Binary = GetBinary();
        }

        public Chromosome(double accuracy, double left, double right, double value, string name)
        {
            if (accuracy < 0)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Value = value;
            this.Binary = GetBinary();
        }

        private string GetBinary()
        {
            throw new NotImplementedException();
        }
    }
}
