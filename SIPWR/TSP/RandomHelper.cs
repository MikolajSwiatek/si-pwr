using System;

namespace SIPWR.TSP
{
    public static class RandomHelper
    {
        public static readonly Random Random = new Random();

        public static double Get()
        {
            return Random.NextDouble() * 100;
        }
    }
}