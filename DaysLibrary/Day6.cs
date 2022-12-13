
namespace DaysLibrary;

public static class Day6
{
    public static int GetEndOfStartOfPacketMarkerIndex(string datastream, int packetSize)
    {
        var chars = new Queue<char>(datastream.Substring(0, packetSize).ToCharArray());
        var endIndex = packetSize - 1;
        while (chars.ToHashSet().Count < packetSize)
        {
            endIndex++;

            chars.Dequeue();
            chars.Enqueue(datastream.ElementAt(endIndex));
        }

        return endIndex;
    }
}