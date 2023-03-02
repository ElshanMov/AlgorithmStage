using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Grade
{
    internal class Program
    {

        class Result
        {
            /*
             In the best case, when all students' grades are already 38 or higher, the loop will not be entered at all, 
             and the algorithm's runtime will be O(1).
             
             In the worst case, when all students' grades are 37 or lower, the loop will run for all elements, and an additional operation will be
             performed to change each student's grade.In this case, the algorithm's runtime, expressed as the size of the list n, will be O(n).

            */
            public static List<int> gradingStudents(List<int> grades)
            {
                for (int i = 0; i < grades.Count; i++)
                {
                    //Grades greater than 37 will be rounded off for passing.
                    if (grades[i] > 37)
                    {
                        /*
                         * If the difference between the grade and the next multiple of 5 is less than 3, we need to satisfy the condition that we need to
                         * round the grade to the next multiple of 5.
                         */
                        int temp = 5 - (grades[i] % 5);
                        if (temp < 3)
                        {
                            //Since the condition is met, the rounded grades should be reflected in the list.
                            grades[i] += temp;
                        }
                    }
                }
                return grades;
            }

        }

        class Solution
        {

            public static void Main(string[] args)
            {
                //Input that determines how many grades will be given.
                Console.WriteLine("Enter the grade count:");
                int gradesCount = Convert.ToInt32(Console.ReadLine());

                //List of grades entered
                List<int> grades = new List<int>();

                //Loop for listing grades
                Console.WriteLine("Enter the grades:");
                for (int i = 0; i < gradesCount; i++)
                {
                    int gradesItem = Convert.ToInt32(Console.ReadLine());
                    grades.Add(gradesItem);
                }

                Console.WriteLine("Result:");
                List<int> result = Result.gradingStudents(grades);
                result.ForEach(x => Console.WriteLine(x + " "));

            }
        }
    }
}