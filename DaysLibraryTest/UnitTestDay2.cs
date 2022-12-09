using DaysLibrary;

namespace DaysLibraryTest;

[TestClass]
public class TestGetPointsForRockPaperScissorsStrategy
{
    [TestMethod]
    public void TestWithSingleRound()
    {
        List<string> lines = new List<string> { "A Y" };

        Int32 points = Day2.GetPointsForRockPaperScissorsStrategy(lines);

        Assert.AreEqual(8, points);
    }

    [TestMethod]
    public void TestWithMultipleRounds()
    {
        List<string> lines = new List<string> { "A Y", "B X", "C Z" };

        Int32 points = Day2.GetPointsForRockPaperScissorsStrategy(lines);

        Assert.AreEqual(15, points);
    }
}

[TestClass]
public class TestGetPointsForWinLoseDrawStrategy
{
    [TestMethod]
    public void TestWithSingleRound()
    {
        List<string> lines = new List<string> { "A Y" };

        Int32 points = Day2.GetPointsForWinLoseDrawStrategy(lines);

        Assert.AreEqual(4, points);
    }

    [TestMethod]
    public void TestWithMultipleRounds()
    {
        List<string> lines = new List<string> { "A Y", "B X", "C Z" };

        Int32 points = Day2.GetPointsForWinLoseDrawStrategy(lines);

        Assert.AreEqual(12, points);
    }
}