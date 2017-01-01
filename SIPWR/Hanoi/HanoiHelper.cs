using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPWR.Hanoi
{
    public static class HanoiHelper
    {
        public static List<Hanoi.Model.Tower> Create(int tower, int dics)
        {
            var towers = CreateTowers(tower);
            AddDics(towers, dics);

            return towers;
        }

        public static List<Hanoi.Model.Tower> CreateTowers(int n)
        {
            var result = new List<Hanoi.Model.Tower>();

            for (var index = 0; index < n; index++)
            {
                string name = "index_" + index;

                if (index < 9)
                {
                    name = "index_0" + index;
                }

                var tower = new Hanoi.Model.Tower()
                {
                    Name = name
                };

                result.Add(tower);
            }

            return result;
        }

        public static void AddDics(List<Hanoi.Model.Tower> towers, int dics)
        {
            var tower = towers.First();

            for (var d = 0; d < dics; d++)
            {
                tower.Discs.Add(d);
            }
        }
    }
}