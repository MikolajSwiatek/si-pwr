using SIPWR.TSP.Model;
using System.Collections.Generic;

namespace SIPWR.Data
{
    public static class DemoTSPData
    {
        public static List<City> Get()
        {
            var cities = new List<City>();

            cities.Add(new City("1", 20833.3333, 17100.0000));
            cities.Add(new City("2", 20900.0000, 17066.6667));
            cities.Add(new City("3", 21300.0000, 13016.6667));
            cities.Add(new City("4", 21600.0000, 14150.0000));
            cities.Add(new City("5", 21600.0000, 14966.6667));
            cities.Add(new City("6", 21600.0000, 16500.0000));
            cities.Add(new City("7", 22183.3333, 13133.3333));
            cities.Add(new City("8", 22583.3333, 14300.0000));
            cities.Add(new City("9", 22683.3333, 12716.6667));
            cities.Add(new City("10", 23616.6667, 15866.6667));
            cities.Add(new City("11", 23700.0000, 15933.3333));
            cities.Add(new City("12", 23883.3333, 14533.3333));
            cities.Add(new City("13", 24166.6667, 13250.0000));
            cities.Add(new City("14", 25149.1667, 12365.8333));
            cities.Add(new City("15", 26133.3333, 14500.0000));
            cities.Add(new City("16", 26150.0000, 10550.0000));
            cities.Add(new City("17", 26283.3333, 12766.6667));
            cities.Add(new City("18", 26433.3333, 13433.3333));
            cities.Add(new City("19", 26550.0000, 13850.0000));
            cities.Add(new City("20", 26733.3333, 11683.3333));
            cities.Add(new City("21", 27026.1111, 13051.9444));
            cities.Add(new City("22", 27096.1111, 13415.8333));
            cities.Add(new City("23", 27153.6111, 13203.3333));
            cities.Add(new City("24", 27166.6667, 9833.3333));
            cities.Add(new City("25", 27233.3333, 10450.0000));
            cities.Add(new City("26", 27233.3333, 11783.3333));
            cities.Add(new City("27", 27266.6667, 10383.3333));
            cities.Add(new City("28", 27433.3333, 12400.0000));
            cities.Add(new City("29", 27462.5000, 12992.2222));

            return cities;
        }
    }
}