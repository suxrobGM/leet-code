using System.Numerics;
using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution974
{
    /// <summary>
    /// 974. Subarray Sums Divisible by K - Medium
    /// <a href="https://leetcode.com/problems/subarray-sums-divisible-by-k">See the problem</a>
    /// </summary>
    public int SubarraysDivByK(int[] nums, int k)
    {
        var map = new Dictionary<int, int> { [0] = 1 };
        var sum = 0;
        var count = 0;

        foreach (var num in nums)
        {
            sum = (sum + num) % k;
            if (sum < 0)
            {
                sum += k;
            }

            if (map.ContainsKey(sum))
            {
                count += map[sum];
            }

            map[sum] = map.GetValueOrDefault(sum, 0) + 1;
        }

        return count;
    }
}
