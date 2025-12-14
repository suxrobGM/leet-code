using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1943
{
    /// <summary>
    /// 1943. Describe the Painting - Medium
    /// <a href="https://leetcode.com/problems/describe-the-painting">See the problem</a>
    /// </summary>
    public IList<IList<long>> SplitPainting(int[][] segments)
    {
        var result = new List<IList<long>>();
        var map = new SortedDictionary<long, long>();

        foreach (var segment in segments)
        {
            var start = segment[0];
            var end = segment[1];
            var value = segment[2];

            if (!map.ContainsKey(start))
            {
                map[start] = 0;
            }

            if (!map.ContainsKey(end))
            {
                map[end] = 0;
            }

            map[start] += value;
            map[end] -= value;
        }

        var currentStart = 0L;
        var currentSum = 0L;

        foreach (var kvp in map)
        {
            if (currentSum != 0)
            {
                result.Add([currentStart, kvp.Key, currentSum]);
            }

            currentStart = kvp.Key;
            currentSum += kvp.Value;
        }

        return result;
    }
}
