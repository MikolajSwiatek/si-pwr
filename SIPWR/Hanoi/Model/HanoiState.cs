using System;
using System.Collections.Generic;
using System.Linq;

namespace SIPWR.Hanoi.Model
{
    public class HanoiState : ICloneable
    {
        public List<Tower> Towers { get; set; }

        public HanoiState(List<Tower> towers)
        {
            this.Towers = towers;
        }

        public HanoiState(HanoiState hanoiState)
        {
            this.Towers = hanoiState.Towers;
        }

        public int? FirstItem(int x)
        {
            if (this.Towers.ElementAt(x).Discs.Count() == 0)
            {
                return null;
            }

            var item = this.Towers.ElementAt(x).Discs.LastOrDefault();
            return item;
        }

        public string Id
        {
            get
            {
                var id = string.Empty;

                foreach (var t in this.Towers)
                {
                    id += "[";

                    for (var index = 0; index < t.Discs.Count(); index++)
                    {
                        var d = t.Discs.ElementAt(index);

                        if (index > 0)
                        {
                            id += ";";
                        }

                        id += d.ToString();
                    }

                    for (var index = 0; index < GetTotalDisc - t.Discs.Count(); index++)
                    {
                        if (index > 0 || GetTotalDisc != t.Discs.Count() && t.Discs.Count() != 0)
                        {
                            id += ";";
                        }

                        id += "0";
                    }

                    id += "]";
                }

                return id;
            }
        }

        public List<HanoiState> GetNeighbor()
        {
            var result = new List<HanoiState>();
            var validMoves = GetValidMoves();

            foreach (var move in validMoves)
            {
                var newHanoiState = (HanoiState)Clone();
                MoveDisc(newHanoiState, move);
                result.Add(newHanoiState);
            }

            return result;
        }

        private List<KeyValuePair<int, int>> GetValidMoves()
        {
            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();

            for (var i = 0; i < this.Towers.Count(); i++)
            {
                for (var j = 0; j < this.Towers.Count(); j++)
                {
                    if (CanMove(i, j))
                    {
                        var pair = new KeyValuePair<int, int>(i, j);
                        result.Add(pair);
                    }
                }
            }

            return result;
        }

        private bool CanMove(int fromIndex, int toIndex)
        {
            var from = FirstItem(fromIndex);
            var to = FirstItem(toIndex);

            if (fromIndex == toIndex || from == null)
            {
                return false;
            }

            if (to != null && from > to)
            {
                return false;
            }

            return true;
        }


        public static void MoveDisc(HanoiState hanoiState, KeyValuePair<int, int> pair)
        {
            var disc = hanoiState.Towers.ElementAt(pair.Key).Discs.Last();
            hanoiState.Towers.ElementAt(pair.Key).Discs.Remove(disc);
            hanoiState.Towers.ElementAt(pair.Value).Discs.Add(disc);
        }

        public object Clone()
        {
            var copy = (HanoiState)this.MemberwiseClone();
            copy.Towers = this.Towers.Select(c => c.CloneTower()).ToList();
            return copy;
        }

        private int GetTotalDisc
        {
            get
            {
                var count = 0;

                foreach (var t in this.Towers)
                {
                    count += t.Discs.Count();
                }

                return count;
            }
        }
    }
}