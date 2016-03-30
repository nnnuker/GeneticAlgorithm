﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public class Pair : IPair
    {
        public IDesignPoint First { get; set; }

        public IDesignPoint Second { get; set; }
    }
}
