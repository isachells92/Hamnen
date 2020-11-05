using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class Rowingboat:Boat
    {
        public Double ParkingRange { get; set; }
        public int MaxPassengers { get; set; }
        public Rowingboat(string id, int weight, int topspeed, int maxPassengers)
        {
            Id = id;
            Weight = weight;
            Topspeed = topspeed;
            MaxPassengers = maxPassengers;
            ParkingRange = 0.5;
        }
        public Rowingboat()
        {

        }
    }
}
