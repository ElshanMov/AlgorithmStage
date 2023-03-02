using System.ComponentModel;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BirthdayCakeCandles
{
    internal class Program
    {
        class Result
        {


            /*
             * In the best-case scenario, the list contains only one candle, so the loop is executed only
             * once and the maximum value and count are determined in O(1) time.Therefore, the best-case 
             * runtime of this algorithm is O(1).

             In the worst-case scenario, the list contains n candles and all candles have the same height.In this case, 
             the loop must compare every candle to the current maximum and update the maximum and count accordingly.
             This results in n-1 comparisons and n-1 conditional statements executed in the loop, giving a worst-case runtime of O(n).

            */
            public static int birthdayCakeCandles(List<int> candles)
            {
                //Variable where we will keep the longest candle length.
                int max = candles[0];
                //The variable where we hold the longest candle count.
                int count = 0;
                for (int i = 0; i < candles.Count; i++)
                {
                    //The condition in which we determine the longest candle in the list.
                    if (max <= candles[i])
                    {
                        //If there is a candle of the same length as the longest candle, we need to increase its number.
                        if (max == candles[i])
                        {
                            count += 1;

                        }
                        //If it's not the same length and we're in max<= candles[i] then that means we've found the longer candle.
                        //And we have to start counting again.
                        else
                        {
                            max = candles[i];
                            count = 1;
                        }
                    }
                }
                //At the end of the iteration, the longest candle count is now determined.
                return count;
            }

        }
        static void Main(string[] args)
        {
            //Input where we set the number of candles.
            Console.WriteLine("Enter the candle count:");
            int candlesCount = Convert.ToInt32(Console.ReadLine());

            //List of candles' length entered.
            List<int> candles = new List<int>();
            Console.WriteLine("Enter the candle lengths.");
            for (int i = 0; i < candlesCount; i++)
            {
                candles.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("Longest number of candles:");
            int result = Result.birthdayCakeCandles(candles);
            Console.WriteLine(result);

        }
    }
}