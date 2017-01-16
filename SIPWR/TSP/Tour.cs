using SIPWR.TSP.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SIPWR.TSP
{
    public class Tour
    {
        public List<City> TourCities { get; set; }
        public double Distance { get; set; }

        public Tour()
        {
            this.TourCities = new List<City>();
            GenerateIndividual();

            this.Distance = 0;
        }

        public Tour(List<City> tour)
        {
            this.TourCities = tour.Select(c => c != null ? (City)c.Clone() : null).ToList();
            this.Distance = 0;
        }

        public Tour(List<City> tour, double distance)
        {
            this.TourCities = tour;
            this.Distance = distance;
        }

        private void GenerateIndividual()
        {
            for (int cityIndex = 0; cityIndex < TourManager.Cities.Count(); cityIndex++)
            {
                SetCity(cityIndex, TourManager.Cities.ElementAt(cityIndex));
            }

            var sorted = this.TourCities.OrderBy(a => Guid.NewGuid()).ToList();
            this.TourCities.Clear();
            this.TourCities.AddRange(sorted);
        }

        public void SetCity(int index, City city)
        {
            this.TourCities.Remove(city);
            this.TourCities.Insert(index, city);
            this.Distance = 0;
        }

        public double GetDistance(
            Dictionary<string, Dictionary<string, double>> distanceList)
        {
            if (this.Distance == 0)
            {
                var tourDistance = 0d;

                for (int cityIndex = 0; cityIndex < this.TourCities.Count(); cityIndex++)
                {
                    var fromCity = this.TourCities.ElementAt(cityIndex);
                    City destinationCity;

                    if (cityIndex + 1 < this.TourCities.Count())
                    {
                        destinationCity = this.TourCities.ElementAt(cityIndex + 1);
                    }
                    else
                    {
                        destinationCity = this.TourCities.ElementAt(0);
                    }

                    tourDistance += distanceList[fromCity.Name][destinationCity.Name];
                }

                this.Distance = tourDistance;
            }

            return this.Distance;
        }

        public double Fitness
        {
            get
            {
                if (this.Distance == 0)
                {
                    return 0;
                }
                else
                {
                    return 1 / this.Distance;
                }
            }
        }
    }
}