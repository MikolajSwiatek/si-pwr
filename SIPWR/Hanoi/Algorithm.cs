using SIPWR.Hanoi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.Hanoi
{
    public abstract class Algorithm
    {
        protected List<Tower> towers;
        protected HanoiState hanoiState;
        protected List<string> result;
        protected int counter;

        protected IDictionary<string, int> distance;
        protected IDictionary<string, string> parents;

        public Algorithm(int t, int d)
        {
            towers = HanoiHelper.Create(t, d);
        }

        public abstract void Execute(string endstate);

        public virtual Model.History GetResult()
        {
            result = result.Select((c, index) => new { c, index })
                                         .OrderByDescending(x => x.index)
                                         .Select(x => x.c)
                                         .ToList();

            return new History(result, counter);
        }

        protected void SetDataForFS()
        {
            hanoiState = new HanoiState(this.towers);
            distance = new Dictionary<string, int>();
            parents = new Dictionary<string, string>();
            result = new List<string>();

            distance[hanoiState.Id] = 0;
            parents[hanoiState.Id] = string.Empty;
        }

        protected void GenerateResult(string endstate)
        {
            result.Add(endstate);
            var position = endstate;

            while (true)
            {
                if (parents[position] != string.Empty)
                {
                    position = parents[position];
                    result.Add(position);
                }
                else
                {
                    return;
                }
            }
        }
    }
}