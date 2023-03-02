using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SherlockAndSquares
{
    internal class Program
    {
        /*This C# program calculates the number of perfect squares within a given range of integers.
         To determine the best and worst cases for this algorithm, we need to consider the behavior of the loop
         in relation to the input values.

         In the best-case scenario, the lower bound is a perfect square, so the loop will only execute once, 
         and the count of perfect squares will be determined in O(1) time.
         Therefore, the best-case runtime of this algorithm is O(1).

         In the worst-case scenario, the upper bound is much larger than the lower bound, 
         and the loop must iterate through a large number of values to determine the count of perfect squares.
         In this case, the loop will execute n times, where n is the difference between the upper and lower bounds. 
         Since the loop contains only a few basic operations, the worst-case runtime of this algorithm is O(n).

         Overall, this algorithm has a best-case runtime of O(1) and a worst-case runtime of O(n), 
         where n is the difference between the upper and lower bounds.
       */
        public static int Squares(int start, int end)
        {
            //To find the square root number that is in the interval, we need the initial value.
            int temp = (int)Math.Pow(start, 0.5);

            //Variable to hold the number of square root values in the range.
            int count = 0;

            //We need to find which numbers are squared up to the ending number of the interval.
            do
            {
                if (temp * temp >= start)
                {
                    count++;
                }
                temp++;
            } while (temp * temp <= end);
            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the starting number:");
            int start = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the ending number:");
            int end = Convert.ToInt32(Console.ReadLine());

            int result = Squares(start, end);
            Console.WriteLine("Square integer in range: "+result);
        }
       
    }
}