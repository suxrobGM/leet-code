namespace LeetCode.Solutions;

public class Solution136
{
    /// <summary>
    /// 136. Single Number - Easy
    /// <a href="https://leetcode.com/problems/single-number">See the problem</a>
    /// </summary>
    public int SingleNumber(int[] nums)
    {
        var result = 0;
        foreach (var num in nums)
        {
            result ^= num;
        }

        return result;
    }
}
