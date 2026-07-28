namespace LeetCode.Solutions;

public class Solution2221
{
    /// <summary>
    /// 2221. Find Triangular Sum of an Array - Medium
    /// <a href="https://leetcode.com/problems/find-triangular-sum-of-an-array">See the problem</a>
    /// </summary>
    public int TriangularSum(int[] nums)
    {
        int n = nums.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                nums[j] = (nums[j] + nums[j + 1]) % 10;
            }
        }

        return nums[0];
    }
}
