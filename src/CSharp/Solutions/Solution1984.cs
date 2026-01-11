namespace LeetCode.Solutions;

public class Solution1984
{
    /// <summary>
    /// 1984. Minimum Difference Between Highest and Lowest of K Scores - Easy
    /// <a href="https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores">See the problem</a>
    /// </summary>
    public int MinimumDifference(int[] nums, int k)
    {
        if (k <= 1) return 0;

        Array.Sort(nums);
        int minDiff = int.MaxValue;

        for (int i = 0; i <= nums.Length - k; i++)
        {
            int diff = nums[i + k - 1] - nums[i];
            if (diff < minDiff)
            {
                minDiff = diff;
            }
        }

        return minDiff;
    }
}
