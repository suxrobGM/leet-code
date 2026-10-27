namespace LeetCode.Solutions;

public class Solution2332
{
    /// <summary>
    /// 2332. The Latest Time to Catch a Bus - Medium
    /// <a href="https://leetcode.com/problems/the-latest-time-to-catch-a-bus">See the problem</a>
    /// </summary>
    public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
    {
        Array.Sort(buses);
        Array.Sort(passengers);

        int passengerIndex = 0;
        int remainingSeats = 0;
        foreach (int bus in buses)
        {
            remainingSeats = capacity;
            while (remainingSeats > 0 && passengerIndex < passengers.Length && passengers[passengerIndex] <= bus)
            {
                passengerIndex++;
                remainingSeats--;
            }
        }

        int arrival = remainingSeats > 0 ? buses[^1] : passengers[passengerIndex - 1];
        while (passengerIndex > 0 && passengers[passengerIndex - 1] == arrival)
        {
            arrival--;
            passengerIndex--;
        }

        return arrival;
    }
}
