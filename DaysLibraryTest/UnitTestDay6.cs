using DaysLibrary;

namespace DaysLibraryTest;


[TestClass]
public class TestDay6
{
    [TestMethod]
    public void TestGetStartOfPacketMarkerLocation()
    {
        var datastream = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
        var packetSize = 4;

        var endIndex = Day6.GetEndOfStartOfPacketMarkerIndex(datastream, packetSize);

        Assert.AreEqual(7, endIndex + 1);
    }
}