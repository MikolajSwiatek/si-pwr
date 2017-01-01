using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.Hanoi.Model
{
    public class Tower
    {
        public string Name { get; set; }
        public List<int> Discs { get; set; }

        public Tower()
        {
            Discs = new List<int>();
        }
    }

    public class History
    {
        public List<HanoiTowers> HanoiTowers { get; set; }

        public History()
        {
            HanoiTowers = new List<HanoiTowers>();
        }
    }

    public class HanoiTowers
    {
        public List<Tower> Towers { get; set; }
        public string Action { get; set; }

        public HanoiTowers()
        {
            Towers = new List<Tower>();
        }
    }
}