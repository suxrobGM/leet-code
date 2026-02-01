namespace LeetCode.Solutions;

public class Solution2012
{
    /// <summary>
    /// 2012. Sum of Beauty in the Array - Medium
    /// <a href="https://leetcode.com/problems/sum-of-beauty-in-the-array">See the problem</a>
    /// </summary>
    public int SumOfBeauties(int[] nums)
    {
        int n = nums.Length;
        int[] prefixMax = new int[n];
        int[] suffixMin = new int[n];

        prefixMax[0] = nums[0];
        for (int i = 1; i < n; i++)
            prefixMax[i] = Math.Max(prefixMax[i - 1], nums[i]);

        suffixMin[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
            suffixMin[i] = Math.Min(suffixMin[i + 1], nums[i]);

        int sum = 0;
        for (int i = 1; i < n - 1; i++)
        {
            if (nums[i] > prefixMax[i - 1] && nums[i] < suffixMin[i + 1])
                sum += 2;
            else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1])
                sum += 1;
        }

        return sum;
    }
}
