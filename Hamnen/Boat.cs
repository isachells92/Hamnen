using System;
using System.Collections;

namespace Hamnen
{

    public class Boat //: IComparable
    {
        private class findParkingSizeTwoHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                Boat b1 = (Boat)a;
                Boat b2 = (Boat)b;
                return String.Compare(b1.Id, b2.Id);
            }
        }

        public static Random pRandom { get; set; }

        public string Id { get; set; }
        public int Weight { get; set; }
        public int Topspeed { get; set; }
        public string Type { get; set; }
        public int DaysLeft { get; set; }
        public int ParkingRange { get; set; }

        public static IComparer findParkingSizeFour()
        {
            return (IComparer)new findParkingSizeTwoHelper();
        }

    }
}
