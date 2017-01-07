using System.Collections.Generic;
using System.Linq;

namespace SIPWR.Hanoi
{
    public static class HanoiHelper
    {
        public static List<Hanoi.Model.Tower> Create(int tower, int disc)
        {
            var towers = CreateTowers(tower);
            AddDics(towers, disc);

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

        public static void AddDics(List<Hanoi.Model.Tower> towers, int disc)
        {
            for (var d = disc; d != 0; d--)
            {
                towers.First().Discs.Add(d);
            }
        }

        public static string ResultGenerator(int t, int d, int selectTower)
        {
            var result = string.Empty;

            for (var i = 0; i < t; i++)
            {
                result += "[";

                for (var j = d; j != 0; j--)
                {
                    if (j != d)
                    {
                        result += ";";
                    }

                    if (i + 1 != selectTower)
                    {
                        result += "0";
                    }
                    else
                    {
                        result += j.ToString();
                    }
                }

                result += "]";
            }

            return result;
        }
    }
}