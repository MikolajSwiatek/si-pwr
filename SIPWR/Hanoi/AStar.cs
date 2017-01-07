using SIPWR.Hanoi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.Hanoi
{
    public class AStar : IAlgorithm
    {
        private List<Tower> towers;
        private HanoiState hanoiState;
        private List<string> result;
        private int counter;

        public AStar(int t, int d)
        {
            towers = HanoiHelper.Create(t, d);
        }

        public void Execute(string endstate)
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

                    if (!openSet.ContainsKey(neighborId))
                    {
                        openSet[neighborId] = neighbor;
                        idToState[neighborId] = neighbor;
                        counter++;
                    }
                    else if (tentativeGScore >= gScore[neighborId])
                    {
                        continue;
                    }

                    cameFrom[current] = neighborId;
                    gScore[neighborId] = tentativeGScore;
                    fScore[neighborId] = tentativeGScore;
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
                    value = fscore[os.Key];
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

            foreach (var cf in cameFrom)
            {
                totalPath.Add(cf.Value);
            }

            return totalPath;
        }

        public History GetResult()
        {
            return new History(result, counter);
        }
    }
}