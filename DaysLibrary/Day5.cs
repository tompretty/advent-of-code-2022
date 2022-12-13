using System.Text.RegularExpressions;

namespace DaysLibrary;

public static class Day5
{
    public static string GetCratesThatEndUpOnTopWithCrateMover9000(IEnumerable<string> lines)
    {
        var mover = new CrateMover9000<char>
        (
            new CrateStacks<char>
            (
                new List<Stack<char>>
                {
                    new Stack<char>(new char[] { 'F', 'C', 'P', 'G', 'Q', 'R' }),
                    new Stack<char>(new char[] { 'W', 'T', 'C', 'P' }),
                    new Stack<char>(new char[] { 'B', 'H', 'P', 'M', 'C' }),
                    new Stack<char>(new char[] { 'L', 'T', 'Q', 'S', 'M', 'P', 'R' }),
                    new Stack<char>(new char[] { 'P', 'H', 'J', 'Z', 'V', 'G', 'N' }),
                    new Stack<char>(new char[] { 'D', 'P', 'J' }),
                    new Stack<char>(new char[] { 'L', 'G', 'P', 'Z', 'F', 'J', 'T', 'R' }),
                    new Stack<char>(new char[] { 'N', 'L', 'H', 'C', 'F', 'P', 'T', 'J' }),
                    new Stack<char>(new char[] { 'G', 'V', 'Z', 'Q', 'H', 'T', 'C', 'W' }),
                }
            )
        );

        var moves = lines.Select(l => Move.ParseFromLine(l));

        mover.ExecuteMoves(moves);

        var topItems = mover.Stacks.GetTopItems();

        return String.Join("", topItems);
    }

    public static string GetCratesThatEndUpOnTopWithCrateMover9001(IEnumerable<string> lines)
    {
        var mover = new CrateMover9001<char>
        (
            new CrateStacks<char>
            (
                new List<Stack<char>>
                {
                    new Stack<char>(new char[] { 'F', 'C', 'P', 'G', 'Q', 'R' }),
                    new Stack<char>(new char[] { 'W', 'T', 'C', 'P' }),
                    new Stack<char>(new char[] { 'B', 'H', 'P', 'M', 'C' }),
                    new Stack<char>(new char[] { 'L', 'T', 'Q', 'S', 'M', 'P', 'R' }),
                    new Stack<char>(new char[] { 'P', 'H', 'J', 'Z', 'V', 'G', 'N' }),
                    new Stack<char>(new char[] { 'D', 'P', 'J' }),
                    new Stack<char>(new char[] { 'L', 'G', 'P', 'Z', 'F', 'J', 'T', 'R' }),
                    new Stack<char>(new char[] { 'N', 'L', 'H', 'C', 'F', 'P', 'T', 'J' }),
                    new Stack<char>(new char[] { 'G', 'V', 'Z', 'Q', 'H', 'T', 'C', 'W' }),
                }
            )
        );

        var moves = lines.Select(l => Move.ParseFromLine(l));

        mover.ExecuteMoves(moves);

        var topItems = mover.Stacks.GetTopItems();

        return String.Join("", topItems);
    }
}

public abstract class CrateMover<T>
{
    public CrateMover(CrateStacks<T> stacks)
    {
        Stacks = stacks;
    }

    public void ExecuteMoves(IEnumerable<Move> moves)
    {
        foreach (var move in moves)
        {
            ExecuteMove(move);
        }
    }

    public abstract void ExecuteMove(Move move);

    public CrateStacks<T> Stacks { get; }
}

public class CrateMover9000<T>: CrateMover<T>
{
    public CrateMover9000(CrateStacks<T> stacks) : base(stacks)
    {
    }

    public override void ExecuteMove(Move move)
    {
        for (int i = 0; i < move.Amount; i++)
        {
            Stacks.AddToStack(move.To, Stacks.RemoveFromStack(move.From));
        }
    }
}


public class CrateMover9001<T>: CrateMover<T>
{
    public CrateMover9001(CrateStacks<T> stacks) : base(stacks)
    {
    }

    public override void ExecuteMove(Move move)
    {
        var items = new Stack<T>();

        for (int i = 0; i < move.Amount; i++)
        {
            items.Push(Stacks.RemoveFromStack(move.From));
        }

        for (int i = 0; i < move.Amount; i++)
        {
            Stacks.AddToStack(move.To, items.Pop());
        }
    }
}

public class Move 
{
    public Move(int amount, int from, int to)
    {
        Amount = amount;
        From = from;
        To = to;
    }

    public static Move ParseFromLine(string line)
    {
        var regex = @"^move ([0-9]+) from ([0-9]+) to ([0-9]+)$";
        var match = Regex.Match(line, regex, RegexOptions.None);

        return new Move
        (
            Int32.Parse(match.Groups[1].Captures[0].Value),
            Int32.Parse(match.Groups[2].Captures[0].Value) - 1,
            Int32.Parse(match.Groups[3].Captures[0].Value) - 1
        );
    }

    public int Amount { get ;}
    public int From { get ;}
    public int To { get ;}
}

public class CrateStacks<T>
{
    public CrateStacks(List<Stack<T>> stacks)
    {
        Stacks = stacks;
    }

    public void AddToStack(int index, T item)
    {
        Stacks.ElementAt(index).Push(item);
    }

    public T RemoveFromStack(int index)
    {
        return Stacks.ElementAt(index).Pop();
    }

    public IEnumerable<T> GetTopItems()
    {
        return Stacks.Select(s => s.Peek());
    }

    public List<Stack<T>> Stacks { get; }
}
