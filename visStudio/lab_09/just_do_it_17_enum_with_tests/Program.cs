using System;

namespace just_do_it_17_enum_with_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(TestEnums.GetDayMonth((int)TestEnums.DaysOfTheWeek.Monday, (int)TestEnums.MonthsInAYear.October)); 
            Console.WriteLine(TestEnums.GetDayMonth(1,10));
        }
    }

    public class TestEnums
    {
        public static (string, string)GetDayMonth(int day, int month)
        {
            return (((DaysOfTheWeek)day).ToString(), ((MonthsInAYear)month).ToString()); //tuple - a custom anonymous data type (without a name)
        }

        public enum DaysOfTheWeek {Monday = 1, Tueday, Wednesday, Thursday, Friday, Saturday, Sunday};

        public enum MonthsInAYear {January = 1, February, March, April, May, June, July, August, September, October, November, December};
    }
}
