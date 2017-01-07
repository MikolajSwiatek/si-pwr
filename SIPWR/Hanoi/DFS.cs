using SIPWR.Hanoi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPWR.Hanoi
{
    public class DFS : IAlgorithm
    {
        private List<Tower> towers;
        private HanoiState hanoiState;
        private List<string> result;
        private int counter;
        private IDictionary<string, int> distance;
        private IDictionary<string, string> parents;

        public DFS(int t, int d)
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
                return;
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
            return new History(result, counter);
        }
    }
}
