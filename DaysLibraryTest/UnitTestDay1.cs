using DaysLibrary;

namespace DaysLibraryTest;

[TestClass]
public class TestGetTotalCaloriesOfElfWithMostCalories
{
    [TestMethod]
    public void TestWithSingleElfWithSingleSnack()
    {
        List<string> lines = new List<string> { "1000" };

        Int32 calories = Day1.GetTotalCaloriesOfElfWithMostCalories(lines);

        Assert.AreEqual(1000, calories);
    }

    [TestMethod]
    public void TestWithSingleElfWithMultipleSnacks()
    {
        List<string> lines = new List<string> { "1000", "2000", "3000" };

        Int32 calories = Day1.GetTotalCaloriesOfElfWithMostCalories(lines);

        Assert.AreEqual(6000, calories);
    }

    [TestMethod]
    public void TestWithMultipleElvesWithMultipleSnacks()
    {
        List<string> lines = new List<string> { "1000", "2000", "", "4000" };

        Int32 calories = Day1.GetTotalCaloriesOfElfWithMostCalories(lines);

        Assert.AreEqual(4000, calories);
    }
}


[TestClass]
public class TestGetTotalCaloriesOfTop3ElvesWithMostCalories
{
    [TestMethod]
    public void TestWithMultipleElvesWithSingleSnacks()
    {
        List<string> lines = new List<string> { "1000", "", "2000", "", "3000", "", "4000" };

        Int32 calories = Day1.GetTotalCaloriesOfTop3ElvesWithMostCalories(lines);

        Assert.AreEqual(9000, calories);
    }
}