namespace LeetCode.Solutions;

public class Solution137
{
    /// <summary>
    /// 137. Single Number II - Medium
    /// <a href="https://leetcode.com/problems/single-number-ii">See the problem</a>
    /// </summary>
    public int SingleNumber(int[] nums)
    {
        var ones = 0;
        var twos = 0;

        foreach (var num in nums)
        {
            ones = (ones ^ num) & ~twos;
            twos = (twos ^ num) & ~ones;
        }

        return ones;
    }
}
