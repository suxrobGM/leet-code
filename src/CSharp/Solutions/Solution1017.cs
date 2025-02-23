using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1017
{
    /// <summary>
    /// 1017. Convert to Base -2 - Medium
    /// <a href="https://leetcode.com/problems/convert-to-base-2</a>
    /// </summary>
    public string BaseNeg2(int n)
    {
        if (n == 0)
        {
            return "0";
        }

        var result = new StringBuilder();
        while (n != 0)
        {
            var remainder = n % -2;
            n /= -2;

            if (remainder < 0)
            {
                remainder += 2;
                n++;
            }

            result.Insert(0, remainder);
        }

        return result.ToString();
    }
}
