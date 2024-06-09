namespace LeetCode.Solutions;

public class Solution172
{
    /// <summary>
    /// 172. Factorial Trailing Zeroes - Medium
    /// <a href="https://leetcode.com/problems/factorial-trailing-zeroes">See the problem</a>
    /// </summary>
    public int TrailingZeroes(int n)
    {
        var result = 0;

        while (n > 0)
        {
            n /= 5;
            result += n;
        }

        return result;
    }
}
