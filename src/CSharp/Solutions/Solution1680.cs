using System.Text;


namespace LeetCode.Solutions;

public class Solution1680
{
    /// <summary>
    /// 1680. Concatenation of Consecutive Binary Numbers - Medium
    /// <a href="https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers">See the problem</a>
    /// </summary>
    public int ConcatenatedBinary(int n)
    {
        const int MOD = 1_000_000_007;
        long result = 0;

        for (int i = 1; i <= n; i++)
        {
            int bitLength = (int)Math.Floor(Math.Log2(i)) + 1;
            result = ((result << bitLength) % MOD + i) % MOD;
        }

        return (int)result;
    }
}
