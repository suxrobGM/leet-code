namespace LeetCode.Solutions;

public class Solution600
{
    /// <summary>
    /// 600. Non-negative Integers without Consecutive Ones - Hard
    /// <a href="https://leetcode.com/problems/non-negative-integers-without-consecutive-ones">See the problem</a>
    /// </summary>
    public int FindIntegers(int n)
    {
        var dp = new int[32];
        dp[0] = 1;
        dp[1] = 2;

        for (var i = 2; i < 32; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        var result = 0;
        var prevBit = 0;

        for (var i = 31; i >= 0; i--)
        {
            if ((n & (1 << i)) != 0)
            {
                result += dp[i];
                if (prevBit == 1)
                {
                    result--;
                    break;
                }
                prevBit = 1;
            }
            else
            {
                prevBit = 0;
            }
        }
        
        return result + 1;
    }
}
