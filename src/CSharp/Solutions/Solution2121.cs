using System.Numerics;

namespace LeetCode.Solutions;

public class Solution2121
{
    /// <summary>
    /// 2121. Intervals Between Identical Elements - Medium
    /// <a href="https://leetcode.com/problems/intervals-between-identical-elements">See the problem</a>
    /// </summary>
    public long[] GetDistances(int[] arr)
    {
        var n = arr.Length;
        var result = new long[n];
        var map = new Dictionary<int, List<int>>();

        for (var i = 0; i < n; i++)
        {
            if (!map.ContainsKey(arr[i]))
            {
                map[arr[i]] = [];
            }

            map[arr[i]].Add(i);
        }

        foreach (var list in map.Values)
        {
            var prefixSum = new long[list.Count];
            prefixSum[0] = list[0];
            for (var i = 1; i < list.Count; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + list[i];
            }

            for (var i = 0; i < list.Count; i++)
            {
                var idx = list[i];
                var leftCount = i;
                var rightCount = list.Count - 1 - i;
                var leftSum = leftCount > 0 ? prefixSum[i - 1] : 0;
                var rightSum = rightCount > 0 ? prefixSum[^1] - prefixSum[i] : 0;
                result[idx] = (long)idx * leftCount - leftSum + rightSum - (long)idx * rightCount;
            }
        }

        return result;
    }
}
