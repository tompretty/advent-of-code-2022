
namespace DaysLibrary;

public static class Day3
{
    public static int GetTotalPriorityOfDuplicatedItems(IEnumerable<string> lines)
    {
        var rucksacks = lines.Select(l => new Rucksack(l));
        var items = rucksacks.Select(r => r.GetItemRepeatedInBothCompartments());
        var priorities = items.Select(i => GetItemPriority(i));

        return priorities.Sum();
    }

    public static int GetTotalPriorityOfGroupBadges(IEnumerable<string> lines)
    {
        var rucksacks = lines.Select(l => new Rucksack(l));
        var groups = rucksacks
            .Select((r, index) => new { r, index })
            .GroupBy(x => x.index / 3)
            .Select(g => new Group(g.Select(x => x.r)));
        var badges = groups.Select(g => g.GetGroupBadge());
        var priorities = badges.Select(b => GetItemPriority(b));

        return priorities.Sum();
    }

    private static int GetItemPriority(char item) 
    {
        var val = (int)item;

        // It's upper case, so sub 38 (A = 65, 65 - 38 = 27)
        if (val < 97)
        {
            return val - 38;
        }

        // It's lower case, so sub 96 (a = 97, 97 - 96 = 1)
        return val - 96;
    }
}

public class Group
{
    public Group(IEnumerable<Rucksack> rucksacks)
    {
        Rucksacks = rucksacks;
    }

    public char GetGroupBadge()
    {
        var r1 = Rucksacks.ElementAt(0);
        var r2 = Rucksacks.ElementAt(1);
        var r3 = Rucksacks.ElementAt(2);

        var query = from items in r1.Items.Intersect(r2.Items).Intersect(r3.Items) select items;

        return query.ElementAt(0);
    }

    public IEnumerable<Rucksack> Rucksacks { get; }
}

public class Rucksack
{
    public Rucksack(string items)
    {
        Items = items;
    }

    public char GetItemRepeatedInBothCompartments()
    {
        var numItemsPerCompartment = Items.Length / 2;

        char repeatedItem = ' ';
        for (int i = 0; i < numItemsPerCompartment; i++)
        {
            char item = Items[i];

            for (int j = 0; j < numItemsPerCompartment; j++)
            {
                char otherItem = Items[numItemsPerCompartment + j];

                if (item == otherItem)
                {
                    repeatedItem = item;
                    break;
                }
            }
        }

        return repeatedItem;
    }

    public string Items { get; }

}