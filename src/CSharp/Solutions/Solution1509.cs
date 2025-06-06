using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1509
{
    /// <summary>
    /// 1509. Minimum Difference Between Largest and Smallest Value in Three Moves - Medium
    /// <a href="https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves">See the problem</a>
    /// </summary>
    public int MinDifference(int[] nums)
    {
        if (nums.Length <= 4)
        {
            return 0;
        }

        Array.Sort(nums);
        int n = nums.Length;

        // Calculate the minimum difference by considering the four cases
        int case1 = nums[n - 1] - nums[3]; // Remove 3 smallest
        int case2 = nums[n - 2] - nums[2]; // Remove 2 smallest, 1 largest
        int case3 = nums[n - 3] - nums[1]; // Remove 1 smallest, 2 largest
        int case4 = nums[n - 4] - nums[0]; // Remove 4 largest

        return Math.Min(Math.Min(case1, case2), Math.Min(case3, case4));
    }
}
