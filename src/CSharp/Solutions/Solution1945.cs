using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1945
{
    /// <summary>
    /// 1945. Sum of Digits of String After Convert - Easy
    /// <a href="https://leetcode.com/problems/sum-of-digits-of-string-after-convert">See the problem</a>
    /// </summary>
    public int GetLucky(string s, int k)
    {
        var sb = new StringBuilder();
        foreach (var c in s)
        {
            sb.Append(c - 'a' + 1);
        }

        var sum = 0;
        foreach (var c in sb.ToString())
        {
            sum += c - '0';
        }

        for (int i = 1; i < k; i++)
        {
            var temp = 0;
            while (sum > 0)
            {
                temp += sum % 10;
                sum /= 10;
            }
            sum = temp;
        }

        return sum;
    }
}
