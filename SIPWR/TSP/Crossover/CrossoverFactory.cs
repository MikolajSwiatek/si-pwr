using System;

namespace SIPWR.TSP.Crossover
{
    public static class CrossoverFactory
    {
        public static ICrossover Get(CrossoverType type)
        {
            switch (type)
            {
                case CrossoverType.Point:
                    return (ICrossover)new Point();
                case CrossoverType.TwoPoint:
                    return (ICrossover)new TwoPoint();
                case CrossoverType.Uniform:
                    return (ICrossover)new Uniform();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}