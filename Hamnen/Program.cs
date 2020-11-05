using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace Hamnen
{
    
    public class Dock
    {
        public string ID { get; set; }
        public double Size { get; set; }
    }
    class Program
    {
        // Settings
        static int DaysToSimulate = 30;
        static int BoatPerDay = 5;

        public static List<Boat> hamn = new List<Boat>();

        static Random rnd = new Random();
        public static List<Boat> rejectedBoats = new List<Boat>();
        static int slots { get; set; }
        static int day;
        static int harborSize = 10;
        static void Main(string[] args)
        {
            // Simulate days
            //for (int i = 0; i < DaysToSimulate; i++)
            //{
            //    // Day Start

            //    // Get 5 random boats
            //    for (int x = 0; i < BoatPerDay; x++)
            //    { 
            //         // Does the boat fit in the harbor
            //         // If boat fits, park it, else lose it. 
            //    }
            //    // Day End
            //}

            for (int i = 0; i < harborSize; i++)      // Fyller hamnen med "tomt"
            {
                hamn.Add(new Tomt { Type = "tomt", Id = "" });
            }

            Console.WriteLine("------------Empty harbor ---");

            foreach (var boat in hamn)
            {
                Console.WriteLine(boat.Type);
            }

            while (true)
            {
                day++;

                int temp = 0;

                foreach (var item in hamn)            
                {
                    var q = hamn
                       .GroupBy(a => a.Id)
                       .Where(b => b.Count() > 1)
                       .Select(c => c.Key)
                       .ToList();
                    foreach (var distinctId in q)
                    {
                        if (item.Id == distinctId)
                        {
                            item.DaysLeft -= 1;
                        }
                    }

                    //  item.DaysLeft -= 1;
                }
                Console.WriteLine($"-----------DAY {day}-----------------");

                for (int i = 0; i < hamn.Count; i++)     // Boats depart.     
                {

                    if (hamn[i].Type == "tomt" || hamn[i].DaysLeft == 0)                          
                    {
                                hamn.RemoveRange(i, 1);
                                Tomt newTomt = InitializeTomt();
                                hamn.Insert(i, newTomt);
                    }
                }


                // If sailboat arrives - find parking, else rejectedboats.add();  
                for (int i = 0; i < hamn.Count; i++)
                {
                    // abvryta här?
                    int slump = rnd.Next(1, 4 + 1);
                    switch (slump)
                    {
                        case 1:
                            try
                            {
                                foreach (var item in hamn)
                                {
                                    //FindParkingSizeHalf
                                    //FindParkingSizeOne
                                    //FindparkingSizeTwo
                                    //FindparkingSizeFour
                                    
                                }
                                hamn.RemoveRange(i, 1);
                                hamn.RemoveRange(i + 1, 1);
                                Sailboat newSailBoat = new Sailboat();
                                RandomizeSailBoat(newSailBoat);
                                hamn.Insert(i, newSailBoat);
                                hamn.Insert(i + 1, newSailBoat);
                                Console.WriteLine("A sailboat has arrived.... !!");
                            }
                            catch (ArgumentException) { }
                            break;
                        case 2:
                            try
                            {
                                hamn.RemoveRange(i, 1);
                                Motorboat newMotorBoat = new Motorboat();
                                RandomizeMotorBoat(newMotorBoat);
                                hamn.Insert(i, newMotorBoat);
                                Console.WriteLine("A Motorboat has arrived.... !!");
                            }
                            catch (ArgumentException) { }
                            break;
                        case 3:
                            try
                            {
                                hamn.RemoveRange(i, 1);           // TODO Hur ska vi göra med roddbåtarna
                                Rowingboat newRowingBboat = new Rowingboat();
                                RandomizeRowingBoat(newRowingBboat);
                                hamn.Insert(i, newRowingBboat);
                                Console.WriteLine("A Rowingboat has arrived.... !!");
                            }
                            catch (ArgumentException) { }
                            break;
                        case 4:
                            try
                            {
                                hamn.RemoveRange(i, 4);
                                Freightship newFreightship = new Freightship();
                                RandomizeFreightship(newFreightship);
                                hamn.Insert(i, newFreightship);
                                hamn.Insert(i + 1, newFreightship);
                                hamn.Insert(i + 2, newFreightship);
                                hamn.Insert(i + 3, newFreightship);
                                Console.WriteLine("A Freightship has arrived.... !!");
                            }
                            catch (ArgumentException) { }
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("--------------------------- !!");
                    int parkingSpace = 1;
                    foreach (var boat in hamn)
                    {
                        Console.WriteLine($" Space: {parkingSpace}  Reg: {boat.Id} Type: {boat.Type}, Weight: {boat.Weight}kg Misc: Error. ");
                        parkingSpace++;
                    }
                    Console.ReadKey(true);

                    Boat boata = new Boat();

                }


            }
        }
      
        public static Tomt InitializeTomt()
        {
            Tomt tomt = new Tomt() { Type = "tomt" };
            return tomt;
        }
        public static Rowingboat InitializeRowingBoat()
        {
            Rowingboat x = new Rowingboat() { Id = "", Weight = 0, Topspeed = 0, MaxPassengers = 0, ParkingRange = 1, Type = " Error Message", DaysLeft = 1 };
            return x;
        }
        public static Motorboat InitializeMotorBoat()
        {
            Motorboat x = new Motorboat() { Id = "", Weight = 0, Topspeed = 0, AmountOfHorsePower = 0, ParkingRange = 1, Type = " Error Message", DaysLeft = 3 };
            return x;
        }
        public static Sailboat InitializeSailingBoat()
        {
            Sailboat x = new Sailboat() { Id = "", Weight = 0, Topspeed = 0, Length = 0, ParkingRange = 2, Type = " Error Message", DaysLeft = 4 };
            return x;
        }
        public static Freightship InitializeFreightship()
        {
            Freightship x = new Freightship() { Id = "", Weight = 0, Topspeed = 0, AmountOfContainers = 4, ParkingRange = 2, Type = " Error Message", DaysLeft = 6 };
            return x;
        }
        public static Boat RandomizeSailBoat(Sailboat boat)
        {
            int sailboatWeight = rnd.Next(600, 6000 + 1);                   // Generating random boat
            int sailboatSpeed = rnd.Next(0, 12 + 1);
            int sailboatLength = rnd.Next(10, 60 + 1);

            StringBuilder strbuild = new StringBuilder();
            string randomString;

            // strbuild.Clear();
            char letter;
            int length = 3;
            for (int j = 0; j < length; j++)                                 // Creating stringbuilder.
            {
                double flt = rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                strbuild.Append(letter);
            }
            randomString = strbuild.ToString();
            boat.Id = $"S-{randomString}";
            boat.Weight = sailboatWeight;
            boat.Topspeed = sailboatSpeed;
            boat.Type = "Sailboat";
            boat.Length = sailboatLength;
            boat.DaysLeft = 4;
            boat.ParkingRange = 2;

            return boat;

        }
        public static Boat RandomizeMotorBoat(Motorboat boat)
        {
            int motorboatWeight = rnd.Next(200, 3000 + 1);                          // Random Motorboat spec
            int motorboatSpeed = rnd.Next(0, 60 + 1);
            int motorboatMaxHorsepower = rnd.Next(10, 1000 + 1);

            StringBuilder strbuild = new StringBuilder();
            string randomString;

            // strbuild.Clear();
            char letter;
            int length = 3;
            for (int j = 0; j < length; j++)                                 // Creating stringbuilder.
            {
                double flt = rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                strbuild.Append(letter);
            }
            randomString = strbuild.ToString();
            boat.Id = $"M-{randomString}";
            boat.Weight = motorboatWeight;
            boat.Topspeed = motorboatSpeed;
            boat.AmountOfHorsePower = motorboatMaxHorsepower;
            boat.Type = "Motorboat";
            boat.DaysLeft = 3;
            boat.ParkingRange = 1;

            return boat;
        }
        public static Boat RandomizeRowingBoat(Rowingboat boat)
        {


            int rowboatWeight = rnd.Next(100, 300 + 1);                          // Random rowboat spec
            int rowboatSpeed = rnd.Next(0, 3 + 1);
            int rowboatMaxPassenger = rnd.Next(0, 6 + 1);

            StringBuilder strbuild = new StringBuilder();
            string randomString;

            // strbuild.Clear();
            char letter;
            int length = 3;
            for (int j = 0; j < length; j++)                                 // Creating stringbuilder.
            {
                double flt = rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                strbuild.Append(letter);
            }
            randomString = strbuild.ToString();
            boat.Id = $"R-{randomString}";
            boat.Weight = rowboatWeight;
            boat.Topspeed = rowboatSpeed;
            boat.Type = "Rowboat";
            boat.MaxPassengers = rowboatMaxPassenger;
            boat.DaysLeft = 1;
            boat.ParkingRange = 1;   //TODO en halv

            return boat;
        }
        public static Boat RandomizeFreightship(Freightship boat)
        {
            int freightshipWeight = rnd.Next(3000, 20000 + 1);                          // Random Freightship spec
            int freightshipSpeed = rnd.Next(0, 20 + 1);
            int freightshipAmountofContainer = rnd.Next(0, 500 + 1);

            StringBuilder strbuild = new StringBuilder();
            string randomString;

            // strbuild.Clear();
            char letter;
            int length = 3;
            for (int j = 0; j < length; j++)                                 // Creating stringbuilder.
            {
                double flt = rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                strbuild.Append(letter);
            }
            randomString = strbuild.ToString();
            boat.Id = $"F-{randomString}";
            boat.Weight = freightshipWeight;
            boat.Topspeed = freightshipSpeed;
            boat.Type = "Freightship";
            boat.AmountOfContainers = freightshipAmountofContainer;
            boat.DaysLeft = 6;
            boat.ParkingRange = 4;
            return boat;


        }
    }
}

//hamn.RemoveAt();
//hamn.BinarySearch();
//hamn.RemoveRange();
//hamn.InsertRange();
//hamn.bi
//hamn.s for (int i = 0; i < 3; i++)
////if (boat.gettype() == typeof(rowingboat))
////{
////    var r = (rowingboat)boat;
////    console.writeline($" reg: {boat.id} type: {boat.type} weight {boat.weight} misc: {r.maxpassengers} ");
////}
////if (boat.gettype() == typeof(motorboat))
////{
////    var r = (motorboat)boat;
////    console.writeline($" reg: {boat.id} type: {boat.type} weight {boat.weight} misc: {r.topspeed} ");
//}
////if (boat.gettype() == typeof(sailboat))
////{
////    var r = (sailboat)boat;
////    console.writeline($" reg: {boat.id} type: {boat.type} weight {boat.weight} misc: {r.length} ");
////}
////if (boat.gettype() == typeof(freightship))
////{
////    var r = (freightship)boat;
////    console.writeline($" reg: {boat.id} type: {boat.type} weight {boat.weight} misc: {r.amountofcontainers} ");
////}
////if (boat.gettype() == typeof(tomt))
////{
////    var r = (tomt)boat;
////    console.writeline($"  type: {boat.type} ");
////}


