using SIPWR.TSP.Model;
using System.Collections.Generic;

namespace SIPWR.Models
{
    public class TSPResultViewModel
    {
        public History Result { get; set; }

        public List<City> Cities { get; set; }
    }
}