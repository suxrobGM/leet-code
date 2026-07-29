namespace LeetCode.Solutions;

public class Solution2222
{
    /// <summary>
    /// 2222. Number of Ways to Select Buildings - Medium
    /// <a href="https://leetcode.com/problems/number-of-ways-to-select-buildings">See the problem</a>
    /// </summary>
    public long NumberOfWays(string s)
    {
        long zero = 0, one = 0;
        long zeroOne = 0, oneZero = 0;
        long result = 0;

        foreach (char c in s)
        {
            if (c == '0')
            {
                result += zeroOne;
                oneZero += one;
                zero++;
            }
            else
            {
                result += oneZero;
                zeroOne += zero;
                one++;
            }
        }

        return result;
    }
}
