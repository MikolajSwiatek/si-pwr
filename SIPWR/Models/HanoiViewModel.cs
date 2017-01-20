using SIPWR.Hanoi;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIPWR.Models
{
    public class HanoiViewModel
    {
        public IEnumerable<SelectListItem> HanoiAlgorithms { get; set; }

        public string SelectedPosition { get; set; }

        public int DiscNumber { get; set; }

        public int TowerNumber { get; set; }

        public int SelectedTower { get; set; }
    }
}