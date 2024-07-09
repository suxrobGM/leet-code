using System.Text;

namespace LeetCode.Solutions;

public class Solution347
{
    /// <summary>
    /// 347. Top K Frequent Elements - Medium
    /// <a href="https://leetcode.com/problems/top-k-frequent-elements">See the problem</a>
    /// </summary>
    public int[] TopKFrequent(int[] nums, int k)
    {
        var frequency = new Dictionary<int, int>();
        var bucket = new List<int>[nums.Length + 1];
        var result = new List<int>();

        foreach (var num in nums)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var key in frequency.Keys)
        {
            var count = frequency[key];
            if (bucket[count] == null)
            {
                bucket[count] = new List<int>();
            }

            bucket[count].Add(key);
        }

        for (var i = bucket.Length - 1; i >= 0 && result.Count < k; i--)
        {
            if (bucket[i] != null)
            {
                result.AddRange(bucket[i]);
            }
        }

        return result.ToArray();
    }
}
