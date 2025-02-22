using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1014
{
    /// <summary>
    /// 1014. Best Sightseeing Pair - Medium
    /// <a href="https://leetcode.com/problems/best-sightseeing-pair</a>
    /// </summary>
    public int MaxScoreSightseeingPair(int[] values)
    {
        var max = 0;
        var result = 0;

        foreach (var value in values)
        {
            result = Math.Max(result, max + value);
            max = Math.Max(max, value) - 1;
        }

        return result;
    }
}
