using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution930
{
    /// <summary>
    /// 930. Binary Subarrays With Sum - Medium
    /// <a href="https://leetcode.com/problems/binary-subarrays-with-sum">See the problem</a>
    /// </summary>
    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        var prefixSum = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        var count = new Dictionary<int, int>();
        int result = 0;
        foreach (int sum in prefixSum)
        {
            result += count.GetValueOrDefault(sum - goal);
            count[sum] = count.GetValueOrDefault(sum) + 1;
        }

        return result;
    }
}
