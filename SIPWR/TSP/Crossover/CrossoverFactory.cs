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
                    return new Point();
                case CrossoverType.TwoPoint:
                    return new TwoPoint();;
                case CrossoverType.Uniform:
                    return new Uniform();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}