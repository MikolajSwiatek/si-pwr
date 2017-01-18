using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.TSP.Mutator
{
    public static class MutatorFactory
    {
        public static IMutator Get(MutatorType type)
        {
            switch (type)
            {
                case MutatorType.FlipGene:
                    return new FlipGene();
                case MutatorType.Random:
                    return new RandomMutator(); ;
                case MutatorType.Uniform:
                    return new Uniform();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}