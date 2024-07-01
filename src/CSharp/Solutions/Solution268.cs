namespace LeetCode.Solutions;

public class Solution268
{
    /// <summary>
    /// 268. Missing Number - Easy
    /// <a href="https://leetcode.com/problems/missing-number">See the problem</a>
    /// </summary>
    public int MissingNumber(int[] nums)
    {
        var n = nums.Length;
        var expectedSum = n * (n + 1) / 2;
        var actualSum = nums.Sum();

        return expectedSum - actualSum;
    }
}
