using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution560
{
    /// <summary>
    /// 560. Subarray Sum Equals K - Medium
    /// <a href="https://leetcode.com/problems/subarray-sum-equals-k">See the problem</a>
    /// </summary>
    public int SubarraySum(int[] nums, int k)
    {
        var count = 0;
        var sum = 0;
        var map = new Dictionary<int, int> { [0] = 1 };

        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (map.ContainsKey(sum - k))
            {
                count += map[sum - k];
            }

            if (map.ContainsKey(sum))
            {
                map[sum]++;
            }
            else
            {
                map[sum] = 1;
            }
        }

        return count;
    }
}
