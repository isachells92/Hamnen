using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class Motorboat:Boat
    {
        public int ParkingRange { get; set; }
        public int AmountOfHorsePower { get; set; }
        public Motorboat(string id, int weight, int topspeed, int amountHorsePower)
        {
            Id = id;
            Weight = weight;
            Topspeed = topspeed;
            AmountOfHorsePower = amountHorsePower;
            ParkingRange = 1;
        }
        public Motorboat()
        {

        }
        
    }
}
