using System.Text.RegularExpressions;

namespace DaysLibrary;

public static class Day4
{
    public static int GetNumberOfAssignmentsThatFullyOverlap(IEnumerable<string> lines)
    {
        return lines
            .Select(l => Assignment.ParseFromLine(l))
            .Where(assignments => Assignment.IsEitherFullyContaining(assignments.Item1, assignments.Item2))
            .Count();
    }

    public static int GetNumberOfAssignmentsThatOverlap(IEnumerable<string> lines)
    {
        return lines
            .Select(l => Assignment.ParseFromLine(l))
            .Where(assignments => assignments.Item1.IsOverlapping(assignments.Item2))
            .Count();
    }
}

public class Assignment 
{
    public Assignment(int lower, int upper)
    {
        Lower = lower;
        Upper = upper;
    }

    public static (Assignment, Assignment) ParseFromLine(string line)
    {
        var regex = @"^([0-9]+)-([0-9]+),([0-9]+)-([0-9]+)$";
        var match = Regex.Match(line, regex, RegexOptions.None);

        var a1 = new Assignment
        (
            Int32.Parse(match.Groups[1].Captures[0].Value),
            Int32.Parse(match.Groups[2].Captures[0].Value)
        );

        var a2 = new Assignment
        (
            Int32.Parse(match.Groups[3].Captures[0].Value),
            Int32.Parse(match.Groups[4].Captures[0].Value)
        );

        return (a1, a2);
    }

    public bool IsOverlapping(Assignment other)
    {
        return other.Lower <= Upper && other.Upper >= Lower;
    }

    public bool IsFullyContaining(Assignment other)
    {
        return Lower <= other.Lower && other.Upper <= Upper;
    }

    public static bool IsEitherFullyContaining(Assignment a1, Assignment a2)
    {
        return a1.IsFullyContaining(a2) || a2.IsFullyContaining(a1);
    }

    public int Lower { get; }
    public int Upper { get; }
}