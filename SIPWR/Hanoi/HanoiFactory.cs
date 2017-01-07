using System;

namespace SIPWR.Hanoi
{
    public static class HanoiFactory
    {

        public static Algorithm Get(
            HanoiAlgorithm algorithm,
            int t,
            int d)
        {
            switch (algorithm)
            {
                case HanoiAlgorithm.AStar:
                    return new AStar(t, d);
                case HanoiAlgorithm.BFS:
                    return new BFS(t, d);
                case HanoiAlgorithm.DFS:
                    return new DFS(t, d);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}