using System.Text;

namespace LeetCode.Solutions;

public class Solution1796
{
    /// <summary>
    /// 1796. Second Largest Digit in a String - Easy
    /// <a href="https://leetcode.com/problems/second-largest-digit-in-a-string">See the problem</a>
    /// </summary>
    public int SecondHighest(string s)
    {
        int first = -1, second = -1;
        foreach (char c in s)
        {
            if (char.IsDigit(c))
            {
                int digit = c - '0';
                if (digit > first)
                {
                    second = first;
                    first = digit;
                }
                else if (digit > second && digit < first)
                {
                    second = digit;
                }
            }
        }
        return second;
    }
}

