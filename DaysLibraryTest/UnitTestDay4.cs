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
public class TestPairAssignment
{
    [TestMethod]
    public void TestParseFromLine()
    {
        string line = "2-4,6-8";

        var assignment = PairAssignment.ParseFromLine(line);

        Assert.AreEqual(2, assignment.First.Lower);
        Assert.AreEqual(4, assignment.First.Upper);
        Assert.AreEqual(6, assignment.Second.Lower);
        Assert.AreEqual(8, assignment.Second.Upper);
    }



    [TestMethod]
    public void TestIsEitherFullyContainingWhenNeitherAreFullyContaining()
    {
        var assignment = new PairAssignment
        (
            new IndividualAssignment(1, 2),
            new IndividualAssignment(3, 4)
        );

        Assert.IsFalse(assignment.IsEitherFullyContaining());
    }


    [TestMethod]
    public void TestIsEitherFullyContainingWhenFirstIsFullyContaining()
    {
        var assignment = new PairAssignment
        (
            new IndividualAssignment(1, 4),
            new IndividualAssignment(2, 3)
        );

        Assert.IsTrue(assignment.IsEitherFullyContaining());
    }

    [TestMethod]
    public void TestIsEitherFullyContainingWhenSecondIsFullyContaining()
    {
        var assignment = new PairAssignment
        (
            new IndividualAssignment(2, 3),
            new IndividualAssignment(1, 4)
        );

        Assert.IsTrue(assignment.IsEitherFullyContaining());
    }
}

[TestClass]
public class TestIndividualAssignment
{
    [TestMethod]
    public void TestIsOverlappingWhenNotOverlapping()
    {
        var first = new IndividualAssignment(1, 2);
        var second = new IndividualAssignment(3, 4);

        Assert.IsFalse(first.IsOverlapping(second));
    }

    [TestMethod]
    public void TestIsOverlappingWhenOverlapping()
    {
        var first = new IndividualAssignment(1, 3);
        var second = new IndividualAssignment(3, 4);

        Assert.IsTrue(first.IsOverlapping(second));
    }

    [TestMethod]
    public void TestIsFullyContainingWhenNotFullyContaining()
    {
        var first = new IndividualAssignment(1, 2);
        var second = new IndividualAssignment(3, 4);

        Assert.IsFalse(first.IsFullyContaining(second));
    }

    [TestMethod]
    public void TestIsFullyContainingWhenFullyContaining()
    {
        var first = new IndividualAssignment(1, 4);
        var second = new IndividualAssignment(2, 3);

        Assert.IsTrue(first.IsFullyContaining(second));
    }
}