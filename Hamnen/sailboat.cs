using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class Sailboat:Boat
    {
        public int ParkingRange { get; set; }
        public int Length { get; set; }
        public Sailboat(string id, int weight, int topspeed, int length, int parkingrange)
        {
            
            Id = id;
            Weight = weight;
            Topspeed = topspeed;
            Length = length;
            ParkingRange = parkingrange;
           
        }
        public Sailboat()
        {

        }


    }
}
