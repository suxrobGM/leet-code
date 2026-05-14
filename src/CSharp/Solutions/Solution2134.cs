namespace LeetCode.Solutions;

public class Solution2134
{
    /// <summary>
    /// 2134. Minimum Swaps to Group All 1's Together II - Medium
    /// <a href="https://leetcode.com/problems/minimum-swaps-to-group-all-1s-together-ii">See the problem</a>
    /// </summary>
    public int MinSwaps(int[] nums)
    {
        int n = nums.Length;
        int totalOnes = nums.Sum();
        if (totalOnes == 0)
        {
            return 0;
        }

        int currentOnes = 0;
        for (int i = 0; i < totalOnes; i++)
        {
            currentOnes += nums[i];
        }

        int maxOnesInWindow = currentOnes;
        for (int i = totalOnes; i < n + totalOnes; i++)
        {
            currentOnes += nums[i % n] - nums[(i - totalOnes) % n];
            maxOnesInWindow = Math.Max(maxOnesInWindow, currentOnes);
        }

        return totalOnes - maxOnesInWindow;
    }
}
