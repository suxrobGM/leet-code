using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1629
{
    /// <summary>
    /// 1629. Slowest Key - Easy
    /// <a href="https://leetcode.com/problems/slowest-key">See the problem</a>
    /// </summary>
    public char SlowestKey(int[] releaseTimes, string keysPressed)
    {
        char slowestKey = keysPressed[0];
        int maxDuration = releaseTimes[0];

        for (int i = 1; i < releaseTimes.Length; i++)
        {
            int duration = releaseTimes[i] - releaseTimes[i - 1];
            if (duration > maxDuration || (duration == maxDuration && keysPressed[i] > slowestKey))
            {
                maxDuration = duration;
                slowestKey = keysPressed[i];
            }
        }

        return slowestKey;
    }
}
