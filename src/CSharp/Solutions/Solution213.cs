namespace LeetCode.Solutions;

public class Solution213
{
    /// <summary>
    /// 213. House Robber II - Medium
    /// <a href="https://leetcode.com/problems/house-robber-ii">See the problem</a>
    /// </summary>
    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }
        
        return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
    }

    private int Rob(int[] nums, int start, int end)
    {
        var prev1 = 0;
        var prev2 = 0;
        
        for (var i = start; i <= end; i++)
        {
            var temp = prev1;
            prev1 = Math.Max(prev2 + nums[i], prev1);
            prev2 = temp;
        }
        
        return prev1;
    }
}
