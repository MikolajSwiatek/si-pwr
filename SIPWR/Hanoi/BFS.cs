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
            var q = new Stack<HanoiState>();

            SetDataForFS();
            q.Push(hanoiState);

            while (q.Count > 0)
            {
                var current = q.Pop();
                var currentId = current.Id;

                var neighbors = current.GetNeighbor();

                foreach (var neighbor in neighbors)
                {
                    var neighborId = neighbor.Id;

                    if (!distance.ContainsKey(neighborId))
                    {
                        distance[neighborId] = distance[currentId] + 1;
                        parents[neighborId] = currentId;
                        q.Push(neighbor);
                        counter++;
                    }

                    if (endstate == neighborId)
                    {
                        GenerateResult(endstate);
                        return;
                    }
                }
            }
        }

        public override Model.History GetResult()
        {
            result = result.Select((c, index) => new { c, index })
                                         .OrderByDescending(x => x.index)
                                         .Select(x => x.c)
                                         .ToList();

            return new History(result, counter);
        }
    }
}