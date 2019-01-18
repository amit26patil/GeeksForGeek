using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Queue
{
    public class FindCircularTour
    {
        public class PetrolPump
        {
            public int Petrol;
            public int Distance;

            // constructor  
            public PetrolPump(int petrol,
                              int distance)
            {
                this.Petrol = petrol;
                this.Distance = distance;
            }

        }
        public static int PrintTour(PetrolPump[] arr)
        {
            int start = -1;
            int balance = 0;
            int balance1 = 0;
            int startBalance = 0;

            for (int ind = 0; ind < arr.Length; ind++)
            {
                var cBalance = arr[ind].Petrol - arr[ind].Distance;
                if (ind != 0)
                {
                    balance1 += arr[ind - 1].Petrol - arr[ind - 1].Distance;
                }
                if (arr[ind].Petrol > arr[ind].Distance && start==-1)
                {
                    start = ind;
                    balance = cBalance;
                    startBalance = balance1;
                }
                else if (start != -1)
                {
                    balance += cBalance;
                    if (balance <= 0)
                    {
                        balance = 0;
                        start = -1;
                    }
                }
            }
            if (start != -1 && (balance + startBalance) >= 0)
            {
                return start;
            }
            else
            {
                return -1;
            }
        }
        public static void Main1()
        {
            PetrolPump[] arr = new PetrolPump[]
            {
                new PetrolPump(2, 5),//-3
                new PetrolPump(7, 5),//2
                new PetrolPump(9, 4),//5
                new PetrolPump(8, 11),//-3
                new PetrolPump(4, 9),//-5
                new PetrolPump(7, 4),
                new PetrolPump(6, 6)
            };
            var index = PrintTour(arr);
            Console.WriteLine(index);
        }
    }
}
