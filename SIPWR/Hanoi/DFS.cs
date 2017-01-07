using SIPWR.Hanoi.Model;
using System.Collections.Generic;

namespace SIPWR.Hanoi
{
    public class DFS : Algorithm
    {
        public DFS(int t, int d)
            : base(t, d)
        { }

        public override void Execute(string endstate)
        {
            var q = new Stack<HanoiState>();

            SetDataForFS();
            q.Push(hanoiState);

            string neighborId = string.Empty;

            while (endstate == neighborId)
            {
                var current = q.Pop();
                var currentId = current.Id;

                var neighbors = current.GetNeighbor();

                foreach (var neighbor in neighbors)
                {
                    neighborId = neighbor.Id;

                    if (!distance.ContainsKey(neighborId))
                    {
                        distance[neighborId] = distance[currentId] + 1;
                        parents[neighborId] = currentId;
                        q.Push(neighbor);
                        counter++;
                    }
                }
            }

            if (endstate == neighborId)
            {
                GenerateResult(endstate);
            }
        }
    }
}
