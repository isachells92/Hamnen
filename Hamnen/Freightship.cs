using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class Freightship:Boat
    {
        public int ParkingRange  { get; set; }
        public int AmountOfContainers { get; set; }
       
        public Freightship(string id, int weight, int topspeed, int amountOfContainers)
        {
            Id = id;
            Weight = weight;
            Topspeed = topspeed;
            AmountOfContainers = amountOfContainers;
            ParkingRange = 3;
        }
        public Freightship()
        {

        }
       

    }
}
