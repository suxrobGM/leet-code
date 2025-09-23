using System.Text;

namespace LeetCode.Solutions;

public class Solution1837
{
    /// <summary>
    /// 1837. Sum of Digits in Base K - Easy
    /// <a href="https://leetcode.com/problems/sum-of-digits-in-base-k">See the problem</a>
    /// </summary>
    public int SumBase(int n, int k)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += n % k;
            n /= k;
        }
        return sum;
    }
}
