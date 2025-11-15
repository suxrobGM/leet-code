using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1903
{
    /// <summary>
    /// 1903. Largest Odd Number in String - Easy
    /// <a href="https://leetcode.com/problems/largest-odd-number-in-string">See the problem</a>
    /// </summary>
    public string LargestOddNumber(string num)
    {
        for (int i = num.Length - 1; i >= 0; i--)
        {
            if ((num[i] - '0') % 2 == 1)
            {
                return num.Substring(0, i + 1);
            }
        }
        return "";
    }
}
