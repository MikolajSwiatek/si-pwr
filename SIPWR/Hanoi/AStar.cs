using SIPWR.Hanoi.Model;
using System.Collections.Generic;
using System.Linq;

namespace SIPWR.Hanoi
{
    public class AStar : Algorithm
    {
        public AStar(int t, int d)
            : base(t, d)
        { }

        public override void Execute(string endstate)
        {
            var closetSet = new Dictionary<string, HanoiState>();
            var openSet = new Dictionary<string, HanoiState>();
            var fScore = new Dictionary<string, int>();
            var gScore = new Dictionary<string, int>();
            var cameFrom = new Dictionary<string, string>();
            var idToState = new Dictionary<string, HanoiState>();

            hanoiState = new HanoiState(this.towers);
            var id = hanoiState.Id;
            openSet[id] = new HanoiState(hanoiState);
            idToState[id] = openSet[id];
            fScore[id] = 0;
            gScore[id] = 0;

            while (openSet.Count() > 0)
            {
                var current = GetLeastCost(openSet, fScore);

                if (current == endstate)
                {
                    result = ReconstructPath(current, cameFrom);
                    return;
                }

                openSet.Remove(current);
                closetSet[current] = idToState[current];
                hanoiState = idToState[current];

                var neighbors = hanoiState.GetNeighbor();

                foreach (var neighbor in neighbors)
                {
                    var neighborId = neighbor.Id;

                    if (closetSet.ContainsKey(neighborId))
                    {
                        continue;
                    }

                    var tentativeGScore = gScore[current] + 1;
                    var tentativeIsBetter = false;
                    if (!openSet.ContainsKey(neighborId))
                    {
                        openSet[neighborId] = neighbor;
                        idToState[neighborId] = neighbor;
                        counter++;
                        tentativeIsBetter = true;
                    }
                    else if (tentativeGScore < gScore[neighborId])
                    {
                        tentativeIsBetter = true;
                    }

                    if (tentativeIsBetter)
                    {
                        cameFrom[neighborId] = current;
                        gScore[neighborId] = tentativeGScore;
                        fScore[neighborId] = tentativeGScore;
                    }
                }
            }
        }

        private string GetLeastCost(
            Dictionary<string, HanoiState> openSet,
            Dictionary<string, int> fscore)
        {
            var minValue = 10000;
            var openSetKey = string.Empty;

            foreach (var os in openSet)
            {
                var value = fscore[os.Key];
                if (value < minValue)
                {
                    minValue = value;
                    openSetKey = os.Key;
                }
            }

            return openSetKey;
        }

        private List<string> ReconstructPath(
            string current,
            Dictionary<string, string> cameFrom)
        {
            var totalPath = new List<string>();
            totalPath.Add(current);

            var node = current;

            while (true)
            {
                if (cameFrom.ContainsKey(node))
                {
                    node = cameFrom[node];
                    totalPath.Add(node);
                }
                else
                {
                    return totalPath;
                }
            }
        }
    }
}