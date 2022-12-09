namespace DaysLibrary;

public static class Day1
{
    public static Int32 GetTotalCaloriesOfElfWithMostCalories(IEnumerable<string> lines) 
    {
        return GetCalories(lines).Max();
    }

    public static Int32 GetTotalCaloriesOfTop3ElvesWithMostCalories(IEnumerable<string> lines) 
    {
        return GetCalories(lines).OrderByDescending(c => c).Take(3).Sum();
    }

    private static IEnumerable<Int32> GetCalories(IEnumerable<string> lines)
    {
        List<List<Int32>> elves = new List<List<Int32>>();
        elves.Add(new List<Int32>());

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line)) 
            {
                elves.Add(new List<Int32>());
                continue;
            }

            elves.Last().Add(Int32.Parse(line));
        }

        return elves.Select(elf => elf.Sum());
    }
}
