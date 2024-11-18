using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution829
{
    /// <summary>
    /// 829. Consecutive Numbers Sum - Hard
    /// <a href="https://leetcode.com/problems/count-unique-characters-of-all-substrings-of-a-given-string">See the problem</a>
    /// </summary>
    public int ConsecutiveNumbersSum(int n)
    {
        int result = 0;
        for (int i = 1; i * (i + 1) / 2 <= n; i++)
        {
            if ((n - i * (i + 1) / 2) % i == 0)
            {
                result++;
            }
        }

        return result;
    }
}
