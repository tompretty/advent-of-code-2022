using DaysLibrary;

namespace DaysLibraryTest;


[TestClass]
public class TestDay4
{
    [TestMethod]
    public void TestGetNumberOfAssignmentsThatFullyOverlap()
    {
        List<string> lines = new List<string>
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
        };

        var numThatFullyOverlap = Day4.GetNumberOfAssignmentsThatFullyOverlap(lines);

        Assert.AreEqual(2, numThatFullyOverlap);
    }

    [TestMethod]
    public void TestGetNumberOfAssignmentsThatOverlap()
    {
        List<string> lines = new List<string>
        {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
        };

        var numThatFullyOverlap = Day4.GetNumberOfAssignmentsThatOverlap(lines);

        Assert.AreEqual(4, numThatFullyOverlap);
    }
}

[TestClass]
public class TestAssignment
{
    [TestMethod]
    public void TestParseFromLine()
    {
        string line = "2-4,6-8";

        var (a1, a2) = Assignment.ParseFromLine(line);

        Assert.AreEqual(2, a1.Lower);
        Assert.AreEqual(4, a1.Upper);
        Assert.AreEqual(6, a2.Lower);
        Assert.AreEqual(8, a2.Upper);
    }


    [TestMethod]
    public void TestIsOverlappingWhenNotOverlapping()
    {
        var a1 = new Assignment(1, 2);
        var a2 = new Assignment(3, 4);

        Assert.IsFalse(a1.IsOverlapping(a2));
    }

    [TestMethod]
    public void TestIsOverlappingWhenOverlapping()
    {
        var a1 = new Assignment(1, 3);
        var a2 = new Assignment(3, 4);

        Assert.IsTrue(a1.IsOverlapping(a2));
    }

    [TestMethod]
    public void TestIsFullyContainingWhenNotFullyContaining()
    {
        var a1 = new Assignment(1, 2);
        var a2 = new Assignment(3, 4);

        Assert.IsFalse(a1.IsFullyContaining(a2));
    }

    [TestMethod]
    public void TestIsFullyContainingWhenFullyContaining()
    {
        var a1 = new Assignment(1, 4);
        var a2 = new Assignment(2, 3);

        Assert.IsTrue(a1.IsFullyContaining(a2));
    }


    [TestMethod]
    public void TestIsEitherFullyContainingWhenNeitherAreFullyContaining()
    {
        var a1 = new Assignment(1, 2);
        var a2 = new Assignment(3, 4);

        Assert.IsFalse(Assignment.IsEitherFullyContaining(a1, a2));
    }


    [TestMethod]
    public void TestIsEitherFullyContainingWhenA1IsFullyContaining()
    {
        var a1 = new Assignment(1, 4);
        var a2 = new Assignment(2, 3);

        Assert.IsTrue(Assignment.IsEitherFullyContaining(a1, a2));
    }

    [TestMethod]
    public void TestIsEitherFullyContainingWhenA2IsFullyContaining()
    {
        var a1 = new Assignment(2, 3);
        var a2 = new Assignment(1, 4);

        Assert.IsTrue(Assignment.IsEitherFullyContaining(a1, a2));
    }
}
