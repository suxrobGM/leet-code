using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution624
{
    /// <summary>
    /// 624. Maximum Distance in Arrays - Medium
    /// <a href="https://leetcode.com/problems/maximum-distance-in-arrays">See the problem</a>
    /// </summary>
    public int MaxDistance(IList<IList<int>> arrays)
    {
        var min = arrays[0][0];
        var max = arrays[0][^1];
        var result = 0;

        for (var i = 1; i < arrays.Count; i++)
        {
            var currentMin = arrays[i][0];
            var currentMax = arrays[i][^1];
            result = Math.Max(result, Math.Max(Math.Abs(currentMax - min), Math.Abs(max - currentMin)));
            min = Math.Min(min, currentMin);
            max = Math.Max(max, currentMax);
        }

        return result;
    }
}
