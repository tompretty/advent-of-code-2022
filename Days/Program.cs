using DaysLibrary;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // SolveDay1();
            SolveDay2();
        }

        static void SolveDay1()
        {
            var lines = System.IO.File.ReadAllLines("./Inputs/Day1.txt").ToList();

            var q1 = Day1.GetTotalCaloriesOfElfWithMostCalories(lines);

            Console.WriteLine("Q1 = {0}", q1);

            var q2 = Day1.GetTotalCaloriesOfTop3ElvesWithMostCalories(lines);

            Console.WriteLine("Q2 = {0}", q2);
        }

        static void SolveDay2()
        {
            var lines = System.IO.File.ReadAllLines("./Inputs/Day2.txt").ToList();

            var q1 = Day2.GetPointsForRockPaperScissorsStrategy(lines);

            Console.WriteLine("Q1 = {0}", q1);

            var q2 = Day2.GetPointsForWinLoseDrawStrategy(lines);

            Console.WriteLine("Q2 = {0}", q2);
        }
    }
}