using System.Text.RegularExpressions;

namespace DaysLibrary;

public static class Day8
{
    public static int GetTotalNumberOfVisibleTrees(IEnumerable<string> lines)
    {
        var grid = lines
            .Select(
                l => l
                    .Select(c => int.Parse(c.ToString()))
                    .ToArray())
            .ToArray();

        var gridHeight = grid.Length;
        var gridWidth = grid[0].Length;

        var visibleInternalTrees = new HashSet<Tuple<int, int>>();

        // Check left to right
        for (int y = 1; y < gridHeight - 1; y++)
        {
            var maxHeight = grid[y][0];
            for (int x = 1; x < gridWidth - 1; x++)
            {
                var height = grid[y][x];

                if (height > maxHeight) 
                {
                    var coords = new Tuple<int, int>(x, y);
                    visibleInternalTrees.Add(coords);

                    maxHeight = height;
                }
            }
        }

        // Check right to left
        for (int y = 1; y < gridHeight - 1; y++)
        {
            var maxHeight = grid[y][gridWidth - 1];
            for (int x = gridWidth - 2; x > 0; x--)
            {
                var height = grid[y][x];

                if (height > maxHeight) 
                {
                    var coords = new Tuple<int, int>(x, y);
                    visibleInternalTrees.Add(coords);

                    maxHeight = height;
                }
            }
        }

        // Check top to bottom
        for (int x = 1; x < gridWidth - 1; x++)
        {
            var maxHeight = grid[0][x];
            for (int y = 1; y < gridHeight - 1; y++)
            {
                var height = grid[y][x];

                if (height > maxHeight) 
                {
                    var coords = new Tuple<int, int>(x, y);
                    visibleInternalTrees.Add(coords);

                    maxHeight = height;
                }
            }
        }

        // Check bottom to top
        for (int x = 1; x < gridWidth - 1; x++)
        {
            var maxHeight = grid[gridHeight - 1][x];
            for (int y = gridHeight - 2; y > 0; y--)
            {
                var height = grid[y][x];

                if (height > maxHeight) 
                {
                    var coords = new Tuple<int, int>(x, y);
                    visibleInternalTrees.Add(coords);

                    maxHeight = height;
                }
            }
        }

        return visibleInternalTrees.Count + 2 * gridHeight + 2 * gridWidth - 4;
    }

    public static int GetHighestScenicScore(IEnumerable<string> lines)
    {
        var grid = lines
            .Select(
                l => l
                    .Select(c => int.Parse(c.ToString()))
                    .ToArray())
            .ToArray();

        var gridHeight = grid.Length;
        var gridWidth = grid[0].Length;

        var highestScore = 0;

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                var numTreesToTheLeft = 0;
                for (int xLeft = x - 1; xLeft > -1; xLeft--)
                {
                    numTreesToTheLeft++;
                    if (grid[y][xLeft] >= grid[y][x])
                    {
                        break;
                    }
                }

                var numTreesToTheRight = 0;
                for (int xRight = x + 1; xRight < gridWidth; xRight++)
                {
                    numTreesToTheRight++;
                    if (grid[y][xRight] >= grid[y][x])
                    {
                        break;
                    }
                }

                var numTreesAbove = 0;
                for (int yAbove = y - 1; yAbove > -1; yAbove--)
                {
                    numTreesAbove++;
                    if (grid[yAbove][x] >= grid[y][x])
                    {
                        break;
                    }
                }

                var numTreesBelow = 0;
                for (int yBelow = y + 1; yBelow < gridHeight; yBelow++)
                {
                    numTreesBelow++;
                    if (grid[yBelow][x] >= grid[y][x])
                    {
                        break;
                    }
                }

                var score = numTreesToTheLeft 
                    * numTreesToTheRight
                    * numTreesAbove
                    * numTreesBelow;

                if (score > highestScore)
                {
                    highestScore = score;
                }
            }
        }

        return highestScore;
    }
}