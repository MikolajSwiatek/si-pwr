using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.KnapsackProblem
{
    public class Genetic : Heuristic, IAlgorithm
    {
        private int populationSize { get; set; }

        public Genetic(List<Item> items)
            : base(items)
        {}

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void GetResult()
        {
            throw new NotImplementedException();
        }
    }
}