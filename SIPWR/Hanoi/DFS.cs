using SIPWR.Hanoi.Model;
using System.Collections.Generic;
using System.Linq;

namespace SIPWR.Hanoi
{
    public class DFS : Algorithm
    {
        public DFS(int t, int d)
            : base(t, d)
        { }

        public override void Execute(string endstate)
        {
            var q = new List<HanoiState>();

            SetDataForFS();
            q.Add(hanoiState);

            string neighborId = string.Empty;

            while (endstate != neighborId)
            {
                var current = q.First();
                q.Remove(current);

                var currentId = current.Id;

                var neighbors = current.GetNeighbor();

                foreach (var neighbor in neighbors)
                {
                    neighborId = neighbor.Id;

                    if (!distance.ContainsKey(neighborId))
                    {
                        distance[neighborId] = distance[currentId] + 1;
                        parents[neighborId] = currentId;
                        q.Add(neighbor);
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
