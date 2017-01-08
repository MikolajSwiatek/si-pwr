using System;

namespace SIPWR.TSP
{
    public static class RandomHelper
    {
        private static Random random = new Random();

        public static double Get()
        {
            return random.NextDouble() * 100;
        }
    }
}