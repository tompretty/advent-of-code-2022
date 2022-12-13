using DaysLibrary;

namespace DaysLibraryTest;


[TestClass]
public class TestDay5
{
}

[TestClass]
public class TestCrateMover9000
{
    [TestMethod]
    public void TestExecuteMoveCanMoveASingleCrate()
    {
        var mover = new CrateMover9000<char>
        (
            new CrateStacks<char>
            (
                new List<Stack<char>>
                {
                    new Stack<char>(new char[] { 'A' }),
                    new Stack<char>()
                }
            )
        );
        var move = Move.ParseFromLine("move 1 from 1 to 2");

        mover.ExecuteMove(move);

        Assert.AreEqual(0, mover.Stacks.Stacks[0].Count);
        Assert.AreEqual(1, mover.Stacks.Stacks[1].Count);
        Assert.AreEqual('A', mover.Stacks.Stacks[1].Peek());
    }

    [TestMethod]
    public void TestExecuteMoveCanMoveMultipleCrates()
    {
        var mover = new CrateMover9000<char>
        (
            new CrateStacks<char>
            (
                new List<Stack<char>>
                {
                    new Stack<char>(new char[] { 'A', 'B' }),
                    new Stack<char>()
                }
            )
        );
        var move = Move.ParseFromLine("move 2 from 1 to 2");

        mover.ExecuteMove(move);

        Assert.AreEqual(0, mover.Stacks.Stacks[0].Count);
        Assert.AreEqual(2, mover.Stacks.Stacks[1].Count);
        Assert.AreEqual('A', mover.Stacks.Stacks[1].Pop());
        Assert.AreEqual('B', mover.Stacks.Stacks[1].Pop());
    }

    [TestMethod]
    public void TestExecuteMoves()
    {
        var mover = new CrateMover9000<char>
        (
            new CrateStacks<char>
            (
                new List<Stack<char>>
                {
                    new Stack<char>(new char[] { 'A', 'B' }),
                    new Stack<char>()
                }
            )
        );
        var moves = new List<Move>
        {
            Move.ParseFromLine("move 1 from 1 to 2"),
            Move.ParseFromLine("move 1 from 1 to 2"),
        };

        mover.ExecuteMoves(moves);

        Assert.AreEqual(0, mover.Stacks.Stacks[0].Count);
        Assert.AreEqual(2, mover.Stacks.Stacks[1].Count);
        Assert.AreEqual('A', mover.Stacks.Stacks[1].Pop());
        Assert.AreEqual('B', mover.Stacks.Stacks[1].Pop());
    }
}

[TestClass]
public class TestCrateMover9001
{
    [TestMethod]
    public void TestExecuteMoveCanMoveASingleCrate()
    {
        var mover = new CrateMover9001<char>
        (
            new CrateStacks<char>
            (
                new List<Stack<char>>
                {
                    new Stack<char>(new char[] { 'A' }),
                    new Stack<char>()
                }
            )
        );
        var move = Move.ParseFromLine("move 1 from 1 to 2");

        mover.ExecuteMove(move);

        Assert.AreEqual(0, mover.Stacks.Stacks[0].Count);
        Assert.AreEqual(1, mover.Stacks.Stacks[1].Count);
        Assert.AreEqual('A', mover.Stacks.Stacks[1].Peek());
    }

    [TestMethod]
    public void TestExecuteMoveCanMoveMultipleCrates()
    {
        var mover = new CrateMover9001<char>
        (
            new CrateStacks<char>
            (
                new List<Stack<char>>
                {
                    new Stack<char>(new char[] { 'A', 'B' }),
                    new Stack<char>()
                }
            )
        );
        var move = Move.ParseFromLine("move 2 from 1 to 2");

        mover.ExecuteMove(move);

        Assert.AreEqual(0, mover.Stacks.Stacks.ElementAt(0).Count);
        Assert.AreEqual(2, mover.Stacks.Stacks.ElementAt(1).Count);
        Assert.AreEqual('A', mover.Stacks.Stacks[1].ElementAt(1));
        Assert.AreEqual('B', mover.Stacks.Stacks[1].ElementAt(0));
    }
}


[TestClass]
public class TestMove 
{
    [TestMethod]
    public void TestParseFromLine()
    {
        var line = "move 2 from 2 to 1";

        var move = Move.ParseFromLine(line);

        Assert.AreEqual(2, move.Amount);
        Assert.AreEqual(1, move.From);
        Assert.AreEqual(0, move.To);
    }
}

[TestClass]
public class TestStacks
{
    [TestMethod]
    public void TestAddToStack()
    {
        var stacks = new CrateStacks<char>
        (
            new List<Stack<char>>
            { 
                new Stack<char>()
            }
        );

        stacks.AddToStack(0, 'A');

        Assert.AreEqual('A', stacks.Stacks[0].Peek());
    }

    [TestMethod]
    public void TestRemoveFromStack()
    {
        var stacks = new CrateStacks<char>
        (
            new List<Stack<char>>
            {
                new Stack<char>( new char[] { 'A' })
            }
        );

        var item = stacks.RemoveFromStack(0);

        Assert.AreEqual(0, stacks.Stacks[0].Count);
        Assert.AreEqual('A', item);
    }

    [TestMethod]
    public void TestGetTopItems()
    {
        var stacks = new CrateStacks<char>
        (
            new List<Stack<char>>
            {
                new Stack<char>(new char[] { 'A', 'B' }),
                new Stack<char>(new char[] { 'C', 'D' }),
            }
        );

        var topItems = stacks.GetTopItems();

        Assert.AreEqual('B', topItems.ElementAt(0));
        Assert.AreEqual('D', topItems.ElementAt(1));
    }
}
