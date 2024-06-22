namespace LeetCode.Solutions;

public class Solution201
{
    /// <summary>
    /// 201. Bitwise AND of Numbers Range - Medium
    /// <a href="https://leetcode.com/problems/bitwise-and-of-numbers-range">See the problem</a>
    /// </summary>
    public int RangeBitwiseAnd(int left, int right)
    {
        var shift = 0;
        while (left < right)
        {
            left >>= 1;
            right >>= 1;
            shift++;
        }
        return left << shift;
    }
}
