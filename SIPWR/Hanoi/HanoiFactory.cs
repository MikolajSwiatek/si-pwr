using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.Hanoi
{
    public static class HanoiFactory
    {
        public IAlgorithm Get(HanoiAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case HanoiAlgorithm.AStar:
                    throw new NotImplementedException();
                case HanoiAlgorithm.BFS:
                    throw new NotImplementedException();
                case HanoiAlgorithm.DFS:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}