using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1636
{
    /// <summary>
    /// 1636. Sort Array by Increasing Frequency - Easy
    /// <a href="https://leetcode.com/problems/sort-array-by-increasing-frequency">See the problem</a>
    /// </summary>
    public int[] FrequencySort(int[] nums)
    {
        var frequency = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (frequency.ContainsKey(num))
                frequency[num]++;
            else
                frequency[num] = 1;
        }

        var sorted = nums.OrderBy(n => frequency[n]).ThenByDescending(n => n).ToArray();
        return sorted;
    }
}
