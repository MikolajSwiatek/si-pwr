using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.KnapsackProblem
{
    public abstract class Heuristic
    {
        protected List<Item> items { get; private set; }

        public Heuristic(List<Item> items)
        {
            if (items.Count() == 0)
            {
            }

            this.items = items;
        }

        protected int GenerateRandomNumberOfNeighbours()
        {
            Random random = new Random();
            return random.Next(10) + 1;
        }

        protected Bag GenerateNeighbour(Bag bag)
        {
            return bag;
        }
    }
}