using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics.Metrics;
using System.Numerics;
namespace ClimbingTheLeaderboard
{
    class Result
    {
        /*
         Best case: If the player's scores are all higher than the highest score on the ranked leaderboard, the algorithm will only
         execute the outer loop for each of the player's scores.Since the inner while loop will never execute, the algorithm will
         have a runtime of O(n), where k is the number of scores the player has.

         Worst case: If the player's scores are all lower than the lowest score on the ranked leaderboard, the algorithm will execute
         the outer loop for each of the player's scores, and the inner while loop will also execute for each score. This will result
         in a worst-case runtime of O(nm), where k is the number of scores the player has and n is the number of scores on the ranked
         leaderboard.
        */

       
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {            
            List<int> result = new List<int>();

            //Bu metodda əvvəlcə təkrarlanan ədədləri təmizləmək üçün HashSet`dən istifadə olundu. Daha sonra, player List`indəki hər bir ədəd(score) üçün
            //dövr yaradılır və hər bir ədədin sırasını tapmaq üçün while dövrü istifadə olunur. Dövr, sıralı List`in(ranked) ən yüksək sırasından başlayır
            //və ikinci List`dəki(player) ədəd ranked List`dəki bir ədəddən kiçikdirsə, player List`indəki ədədin sırasını tapmış oluruq. Əgər player
            //List`indəki ədəd ranked List`inin bir elementi ilə bərabərdirsə, həmin elementin sırasını tapmış oluruq. Əgər ranked List`in sonuna qədər
            //gediriksə və bərabərlik tapmırıqsa, player List`indəki ədəd List`in ən aşağı sırasındadır.
            //Nəticədə, player List`indəki hər bir ədədin sırasını ehtiva edən List return edirik.

            var cleanerRank = ranked.ToHashSet().ToArray();
            int i = cleanerRank.Length - 1;

            for (int j = 0; j < player.Count; j++)
            {
                bool rankFound = false;
                while (!rankFound && i >= 0)
                {
                    if (player[j] < cleanerRank[i])
                    {
                        result.Add(i + 2);
                        rankFound = true;
                    }
                    else if (player[j] == cleanerRank[i])
                    {
                        result.Add(i + 1);
                        rankFound = true;
                    }
                    else
                    {
                        i--;
                    }
                }

                if (!rankFound)
                {
                    result.Add(1);
                }
            }

            return result;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Ranked Count");
            int rankedCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ranked");
            List<int> ranked = new();

            for (int i=0;i<rankedCount;i++) 
            { 
                ranked.Add(Convert.ToInt32(Console.ReadLine())); 
            }
            Console.WriteLine("Player Count");
            int playerCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Player");
            List<int> player = new();
            for (int i = 0; i < playerCount; i++) 
            { 
                player.Add(Convert.ToInt32(Console.ReadLine())); 
            }

            List<int> result = Result.climbingLeaderboard(ranked, player);
            result.ForEach(x => Console.WriteLine(x));
            Console.ReadLine();
        }
    }
}