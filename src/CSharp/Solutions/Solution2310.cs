using System.Text;

namespace LeetCode.Solutions;

public class Solution2310
{
    /// <summary>
    /// 2310. Sum of Numbers With Units Digit K - Medium
    /// <a href="https://leetcode.com/problems/sum-of-numbers-with-units-digit-k">See the problem</a>
    /// </summary>
    public int MinimumNumbers(int num, int k)
    {
        if (num == 0)
        {
            return 0;
        }

        for (int i = 1; i <= 10; i++)
        {
            if (k * i <= num && (num - k * i) % 10 == 0)
            {
                return i;
            }
        }

        return -1;
    }
}
