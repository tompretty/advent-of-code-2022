using DaysLibrary;

namespace DaysLibraryTest;

[TestClass]
public class TestGetTotalPriorityOfDuplicatedItems
{
    [TestMethod]
    public void TestWithSingleRucksack()
    {
        List<string> lines = new List<string> { "vJrwpWtwJgWrhcsFMMfFFhFp" };

        Int32 totalPriority = Day3.GetTotalPriorityOfDuplicatedItems(lines);

        Assert.AreEqual(16, totalPriority);
    }

    [TestMethod]
    public void TestWithMultipleRucksacks()
    {
        List<string> lines = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw",
        };

        Int32 totalPriority = Day3.GetTotalPriorityOfDuplicatedItems(lines);

        Assert.AreEqual(157, totalPriority);
    }
}


[TestClass]
public class TestGetTotalPriorityOfGroupBadges
{
    [TestMethod]
    public void TestWithSingleGroup()
    {
        List<string> lines = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
        };

        Int32 totalPriority = Day3.GetTotalPriorityOfGroupBadges(lines);

        Assert.AreEqual(18, totalPriority);
    }

    [TestMethod]
    public void TestWithMultipleGroups()
    {
        List<string> lines = new List<string>
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw",
        };

        Int32 totalPriority = Day3.GetTotalPriorityOfGroupBadges(lines);

        Assert.AreEqual(70, totalPriority);
    }
}


[TestClass]
public class TestGroup
{
    [TestMethod]
    public void TestGetGroupBadge()
    {
        var group = new Group(
            new List<Rucksack>
            {
                new Rucksack("aaXa"),
                new Rucksack("bbXb"),
                new Rucksack("ccXc"),
            }
        );

        var badge = group.GetGroupBadge();

        Assert.AreEqual('X', badge);
    }
}

[TestClass]
public class TestRucksack
{
    [TestMethod]
    public void TestGetItemRepeatedInBothCompartments()
    {
        var rucksack = new Rucksack("aaXaabXbbb");

        var repeatedItem = rucksack.GetItemRepeatedInBothCompartments();

        Assert.AreEqual('X', repeatedItem);
    }
}