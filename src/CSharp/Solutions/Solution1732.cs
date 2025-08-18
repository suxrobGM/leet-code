using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1732
{
    /// <summary>
    /// 1732. Find the Highest Altitude - Easy
    /// <a href="https://leetcode.com/problems/find-the-highest-altitude">See the problem</a>
    /// </summary>
    public int LargestAltitude(int[] gain)
    {
        int maxAltitude = 0;
        int currentAltitude = 0;

        foreach (int g in gain)
        {
            currentAltitude += g;
            maxAltitude = Math.Max(maxAltitude, currentAltitude);
        }

        return maxAltitude;
    }
}
