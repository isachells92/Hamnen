using System;
using System.Linq;

namespace ArrayThings
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] personArray = new Person[10];

            personArray[2] = new Person { Name = "Håkan", Age = 58 };
            Console.WriteLine(personArray[2].Name);

            //int i = 0;                                                            // Array lösning.
            //for (; i < personArray.Length; i++)
            //{
            //    if (personArray[i] == null)
            //        break;
            //}
            //personArray[i] = new Person { Name = "Antonio", Age = 30 };


            var q = personArray.ToList().FindIndex(p => p is null);                 // Linq lösning.
                personArray[q] = new Person { Name = "Isac", Age = 28 };


            //ExtendArray(personArray);
            //personArray = DiminishArray(personArray);
        }

        private static Person[] DiminishArray(Person[] personArray)   // Copy array to a smaller one
        {
            int tempArrayLength = 0;

            foreach (Person person in personArray)
            {
                if (person != null)
                    tempArrayLength++;
            }

            Person[] temp = new Person[tempArrayLength];

            int tempIndex = 0;

            for (int i = 0; i < personArray.Length; i++)
            {
                if (personArray[i] != null)
                    temp[tempIndex++] = personArray[i];
            }

            return temp;
        }

        private static void ExtendArray(Person[] personArray)       // Copy array to a bigger one
        {
            Person[] temp = new Person[personArray.Length * 2];

            for (int i = 0; i < personArray.Length; i++)
            {
                temp[i] = personArray[i];
            }

            personArray = temp;
        }
    }
    
}
