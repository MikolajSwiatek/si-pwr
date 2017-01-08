using System;

namespace SIPWR.TSP.Model
{
    public class City : ICloneable
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public City()
        {
        }

        public City(string name, double x, double y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public double Proximity(City city)
        {
            return this.Proximity(city.X, city.Y);
        }

        private double Proximity(double x, double y)
        {
            var xDiff = this.X - x;
            var yDiff = this.Y - y;

            return (double)Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
        }

        public static City GenerateCiy()
        {
            var name = Guid.NewGuid().ToString("N");

            return new City(
                name,
                RandomHelper.Get(),
                RandomHelper.Get());
        }

        public object Clone()
        {
            var copy = (City)this.MemberwiseClone();
            copy.Name = this.Name;
            copy.X = this.X;
            copy.Y = this.Y;

            return copy;
        }
    }
}