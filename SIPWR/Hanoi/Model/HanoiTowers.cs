﻿using System.Collections.Generic;

namespace SIPWR.Hanoi.Model
{
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