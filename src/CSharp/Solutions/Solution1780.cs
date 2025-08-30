using System.Text;

namespace LeetCode.Solutions;

public class Solution1780
{
    /// <summary>
    /// 1780. Check if Number is a Sum of Powers of Three - Medium
    /// <a href="https://leetcode.com/problems/check-if-number-is-a-sum-of-powers-of-three">See the problem</a>
    /// </summary>
    public bool CheckPowersOfThree(int n)
    {
        while (n > 0)
        {
            int remainder = n % 3;
            if (remainder > 1) return false;
            n /= 3;
        }
        return true;
    }
}
