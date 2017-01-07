using SIPWR.Hanoi.Model;
using System.Collections.Generic;
using System.Linq;

namespace SIPWR.Hanoi
{
    public class BFS : Algorithm
    {
        public BFS(int t, int d)
            : base(t, d)
        { }

        public override void Execute(string endstate)
        {
            var q = new List<HanoiState>();

            SetDataForFS();
            q.Add(hanoiState);

            while (q.Count > 0)
            {
                var current = q.First();
                q.Remove(current);
                var currentId = current.Id;

                var neighbors = current.GetNeighbor();

                foreach (var neighbor in neighbors)
                {
                    var neighborId = neighbor.Id;

                    if (!distance.ContainsKey(neighborId))
                    {
                        distance[neighborId] = distance[currentId] + 1;
                        parents[neighborId] = currentId;
                        q.Add(neighbor);
                        counter++;
                    }
                }
            }

            GenerateResult(endstate);
        }
    }
}