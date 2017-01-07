using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.KnapsackProblem
{
    public class Bag
    {
        public int Weight { get; set; }

        public List<Item> Items { get; set; }

        public Bag()
        {
            this.Items = new List<Item>();
        }

        public Bag(Bag bag)
        {
            this.Weight = bag.Weight;
            this.Items = bag.Items;
        }

        public int Total
        {
            get
            {
                return this.Items.Count();
            }
        }

        public int TotalValue
        {
            get
            {
                return this.Items.Sum(x => x.Value);
            }
        }
    }
}