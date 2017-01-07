using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.Hanoi.Model
{
    public class Tower : ICloneable
    {
        public string Name { get; set; }
        public List<int> Discs { get; set; }

        public Tower()
        {
            Discs = new List<int>();
        }

        public Tower(string name, List<int> discs)
        {
            this.Name = name;
            this.Discs = Discs;
        }

        public static Tower GetTower(string name, List<int> discs)
        {
            var tower = new Tower(name, discs);
            return tower;
        }

        public object Clone()
        {
            var copy = (Tower)this.MemberwiseClone();
            copy.Name = this.Name;
            copy.Discs = new List<int>();
            copy.Discs = copy.Discs.Concat(this.Discs).ToList();

            return copy;
        }

        public Tower CloneTower()
        {
            return (Tower)this.Clone();
        }
    }
}