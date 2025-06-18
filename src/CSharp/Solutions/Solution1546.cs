using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1546
{
    /// <summary>
    /// 1546. Maximum Number of Non-Overlapping Subarrays With Sum Equals Target - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-non-overlapping-subarrays-with-sum-equals-target">See the problem</a>
    /// </summary>
    public int MaxNonOverlapping(int[] nums, int target)
    {
        var count = 0;
        var sum = 0;
        var seenSums = new HashSet<int> { 0 };

        foreach (var num in nums)
        {
            sum += num;

            if (seenSums.Contains(sum - target))
            {
                count++;
                sum = 0;
                seenSums.Clear();
                seenSums.Add(0);
            }
            else
            {
                seenSums.Add(sum);
            }
        }

        return count;
    }
}
