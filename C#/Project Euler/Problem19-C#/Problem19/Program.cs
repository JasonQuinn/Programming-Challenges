using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem19
{
    class Program
    {
        /// <summary>
        /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int count = GetNumberOfDays(DayOfWeek.Sunday,1901,2000);
            Console.WriteLine(count);
            Console.Read();
        }

        private static int GetNumberOfDays(DayOfWeek dayOfWeek, int startYear, int finishYear)
        {
            int count = 0;
            for (int year = startYear; year <= finishYear; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    if (new DateTime(year, month, 1).DayOfWeek == dayOfWeek)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
