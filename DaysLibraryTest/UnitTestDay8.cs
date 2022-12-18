using DaysLibrary;

namespace DaysLibraryTest;

[TestClass]
public class TestDay8
{
    [TestMethod]
    public void TestGetTotalNumberOfVisibleTrees()
    {
        var lines = new List<string> 
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390",
        };

        var total = Day8.GetTotalNumberOfVisibleTrees(lines);

        Assert.AreEqual(21, total);
    }

    [TestMethod]
    public void TestGetHighestScenicScore()
    {
        var lines = new List<string> 
        {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390",
        };

        var score = Day8.GetHighestScenicScore(lines);

        Assert.AreEqual(8, score);
    }
}
