using DaysLibrary;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // SolveDay1();
            // SolveDay2();
            // SolveDay3();
            // SolveDay4();
            SolveDay5();
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

        static void SolveDay3()
        {
            var lines = System.IO.File.ReadAllLines("./Inputs/Day3.txt").ToList();

            var q1 = Day3.GetTotalPriorityOfDuplicatedItems(lines);

            Console.WriteLine("Q1 = {0}", q1);

            var q2 = Day3.GetTotalPriorityOfGroupBadges(lines);

            Console.WriteLine("Q2 = {0}", q2);
        }

        static void SolveDay4()
        {
            var lines = System.IO.File.ReadAllLines("./Inputs/Day4.txt").ToList();

            var q1 = Day4.GetNumberOfAssignmentsThatFullyOverlap(lines);

            Console.WriteLine("Q1 = {0}", q1);

            var q2 = Day4.GetNumberOfAssignmentsThatOverlap(lines);

            Console.WriteLine("Q2 = {0}", q2);
        }

        static void SolveDay5()
        {
            var lines = System.IO.File.ReadAllLines("./Inputs/Day5.txt").ToList();

            var q1 = Day5.GetCratesThatEndUpOnTopWithCrateMover9000(lines);

            Console.WriteLine("Q1 = {0}", q1);

            var q2 = Day5.GetCratesThatEndUpOnTopWithCrateMover9001(lines);

            Console.WriteLine("Q2 = {0}", q2);
        }
    }
}
