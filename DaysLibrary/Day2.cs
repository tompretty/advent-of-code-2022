
namespace DaysLibrary;

public static class Day2
{
    public static Int32 GetPointsForRockPaperScissorsStrategy(IEnumerable<string> lines)
    {
        return GetPointsForStrategy(lines, ROCK_PAPER_SCISSORS_SCORES);
    }

    public static Int32 GetPointsForWinLoseDrawStrategy(IEnumerable<string> lines)
    {
        return GetPointsForStrategy(lines, WIN_LOSE_DRAW_SCORES);
    }

    private static Int32 GetPointsForStrategy(IEnumerable<string> lines, Dictionary<Char, Dictionary<Char, Int32>> scores)
    {
        return lines.Select(line => GetPointsForRound(line.ElementAt(0), line.ElementAt(2), scores)).Sum();
    }

    private static Int32 GetPointsForRound(Char op, Char player, Dictionary<Char, Dictionary<Char, Int32>> scores)
    {
        return scores[op][player];
    }

    private static Dictionary<Char, Dictionary<Char, Int32>> ROCK_PAPER_SCISSORS_SCORES = new Dictionary<char, Dictionary<char, int>>
    {
        { 'A', new Dictionary<char, int> { { 'X', 4 }, { 'Y', 8 }, { 'Z', 3 } } },
        { 'B', new Dictionary<char, int> { { 'X', 1 }, { 'Y', 5 }, { 'Z', 9 } } },
        { 'C', new Dictionary<char, int> { { 'X', 7 }, { 'Y', 2 }, { 'Z', 6 } } },
    };

    private static Dictionary<Char, Dictionary<Char, Int32>> WIN_LOSE_DRAW_SCORES = new Dictionary<char, Dictionary<char, int>>
    {
        { 'A', new Dictionary<char, int> { { 'X', 3 }, { 'Y', 4 }, { 'Z', 8 } } },
        { 'B', new Dictionary<char, int> { { 'X', 1 }, { 'Y', 5 }, { 'Z', 9 } } },
        { 'C', new Dictionary<char, int> { { 'X', 2 }, { 'Y', 6 }, { 'Z', 7 } } },
    };
}