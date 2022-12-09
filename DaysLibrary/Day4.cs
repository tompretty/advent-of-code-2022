using System.Text.RegularExpressions;

namespace DaysLibrary;

public static class Day4
{
    public static int GetNumberOfAssignmentsThatFullyOverlap(IEnumerable<string> lines)
    {
        return GetNumberOfAssignmentsThatSatisfyPredicate(lines, a => a.IsEitherFullyContaining());
    }

    public static int GetNumberOfAssignmentsThatOverlap(IEnumerable<string> lines)
    {
        return GetNumberOfAssignmentsThatSatisfyPredicate(lines, a => a.IsOverlapping());
    }

    public static int GetNumberOfAssignmentsThatSatisfyPredicate(
        IEnumerable<string> lines,
        Func<PairAssignment, bool> predicate
    )
    {
        return lines
            .Select(line => PairAssignment.ParseFromLine(line))
            .Where(predicate)
            .Count();
    }
}

public class PairAssignment
{
    public PairAssignment(IndividualAssignment first, IndividualAssignment second)
    {
        First = first;
        Second = second;
    }

    public static PairAssignment ParseFromLine(string line)
    {
        var regex = @"^([0-9]+)-([0-9]+),([0-9]+)-([0-9]+)$";
        var match = Regex.Match(line, regex, RegexOptions.None);

        var first = new IndividualAssignment
        (
            Int32.Parse(match.Groups[1].Captures[0].Value),
            Int32.Parse(match.Groups[2].Captures[0].Value)
        );

        var second = new IndividualAssignment
        (
            Int32.Parse(match.Groups[3].Captures[0].Value),
            Int32.Parse(match.Groups[4].Captures[0].Value)
        );

        return new PairAssignment(first, second);
    }

    public bool IsOverlapping()
    {
        return First.IsOverlapping(Second);
    }

    public bool IsEitherFullyContaining()
    {
        return First.IsFullyContaining(Second) || Second.IsFullyContaining(First);
    }

    public IndividualAssignment First { get; }
    public IndividualAssignment Second { get; }
}

public class IndividualAssignment
{
    public IndividualAssignment(int lower, int upper)
    {
        Lower = lower;
        Upper = upper;
    }

    public bool IsOverlapping(IndividualAssignment other)
    {
        return other.Lower <= Upper && other.Upper >= Lower;
    }

    public bool IsFullyContaining(IndividualAssignment other)
    {
        return Lower <= other.Lower && other.Upper <= Upper;
    }

    public int Lower { get; }
    public int Upper { get; }
}
