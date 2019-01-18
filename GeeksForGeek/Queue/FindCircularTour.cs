using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeek.Queue
{
    //using System;

    class GFG
    {
        // A petrol pump has petrol and  
        // distance to next petrol pump  
        public class petrolPump
        {
            public int petrol;
            public int distance;

            // constructor  
            public petrolPump(int petrol,
                              int distance)
            {
                this.petrol = petrol;
                this.distance = distance;
            }
        }

        // The function returns starting point  
        // if there is a possible solution,  
        // otherwise returns -1  
        public static int printTour(petrolPump[] arr,
                                    int n)
        {
            int start = 0;
            int end = 1;
            int curr_petrol = arr[start].petrol -
                              arr[start].distance;

            // If current amount of petrol in   
            // truck becomes less than 0, then  
            // remove the starting petrol pump from tour  
            while (end != start || curr_petrol < 0)
            {

                // If current amount of petrol in 
                // truck becomes less than 0, then  
                // remove the starting petrol pump from tour  
                while (curr_petrol < 0 && start != end)
                {
                    // Remove starting petrol pump. 
                    // Change start  
                    curr_petrol -= arr[start].petrol -
                                   arr[start].distance;
                    start = (start + 1) % n;

                    // If 0 is being considered as  
                    // start again, then there is no  
                    // possible solution  
                    if (start == 0)
                    {
                        return -1;
                    }
                }

                // Add a petrol pump to current tour  
                curr_petrol += arr[end].petrol -
                               arr[end].distance;

                end = (end + 1) % n;
            }

            // Return starting point  
            return start;
        }

        // Driver Code 
        public static void Main1(string[] args)
        {
            petrolPump[] arr = new petrolPump[]
            {
                new petrolPump(2, 5),
                new petrolPump(7, 5),
                new petrolPump(9, 4),
                new petrolPump(8, 11),
                new petrolPump(4, 9),
                new petrolPump(7, 4),
                new petrolPump(6, 4)
            };

            int start = printTour(arr, arr.Length);

            Console.WriteLine(start == -1 ? "No Solution" :
                                       "Start = " + start);
        }
    }
}
