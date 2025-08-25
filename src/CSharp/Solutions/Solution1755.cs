using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1755
{
    /// <summary>
    /// 1755. Closest Subsequence Sum - Hard
    /// <a href="https://leetcode.com/problems/closest-subsequence-sum">See the problem</a>
    /// </summary>
    public int MinAbsDifference(int[] nums, int goal)
    {
        int n = nums.Length;
        int mid = n / 2;

        // Generate all subset sums for left and right halves
        var leftSums = GetSubsetSums(nums, 0, mid);
        var rightSums = GetSubsetSums(nums, mid, n);

        rightSums.Sort();

        long ans = long.MaxValue;

        foreach (long left in leftSums)
        {
            long target = goal - left;
            // Binary search on rightSums for closest to target
            int idx = rightSums.BinarySearch(target);
            if (idx >= 0)
            {
                // Exact match -> diff = 0
                return 0;
            }
            else
            {
                idx = ~idx; // bitwise complement -> insertion point
                if (idx < rightSums.Count)
                {
                    ans = Math.Min(ans, Math.Abs(left + rightSums[idx] - goal));
                }
                if (idx > 0)
                {
                    ans = Math.Min(ans, Math.Abs(left + rightSums[idx - 1] - goal));
                }
            }
        }

        return (int)ans;
    }

    private List<long> GetSubsetSums(int[] nums, int start, int end)
    {
        var sums = new List<long>();
        int len = end - start;
        int total = 1 << len;

        for (int mask = 0; mask < total; mask++)
        {
            long sum = 0;
            for (int i = 0; i < len; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    sum += nums[start + i];
                }
            }
            sums.Add(sum);
        }

        return sums;
    }
}
