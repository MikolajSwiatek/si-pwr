using SIPWR.Hanoi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.Hanoi
{
    public class BFS : IAlgorithm
    {
        private List<Tower> towers;
        private HanoiState hanoiState;
        private List<string> result;
        private int counter;
        private IDictionary<string, int> distance;
        private IDictionary<string, string> parents;

        public BFS(int t, int d)
        {
            towers = HanoiHelper.Create(t, d);
        }

        public void Execute(string endstate)
        {
            var q = new Stack<HanoiState>();
            hanoiState = new HanoiState(this.towers);
            distance = new Dictionary<string, int>();
            parents = new Dictionary<string, string>();
            result = new List<string>();

            distance[hanoiState.Id] = 0;
            parents[hanoiState.Id] = string.Empty;
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

        private void GenerateResult(string endstate)
        {
            result.Add(endstate);
            var position = endstate;

            while (true)
            {
                if (parents[position] != string.Empty)
                {
                    result.Add(parents[position]);
                }
                else
                {
                    return;
                }

                position = parents[position];
            }
        }

        public Model.History GetResult()
        {
            result = result.Select((c, index) => new { c, index })
                                         .OrderByDescending(x => x.index)
                                         .Select(x => x.c)
                                         .ToList();

            return new History(result, counter);
        }
    }
}