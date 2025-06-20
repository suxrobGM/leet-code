using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1556
{
    /// <summary>
    /// 1556. Thousand Separator - Easy
    /// <a href="https://leetcode.com/problems/thousand-separator">See the problem</a>
    /// </summary>
    public string ThousandSeparator(int n)
    {
        if (n == 0) { return "0"; }

        var result = new StringBuilder();
        int count = 0;

        while (n > 0)
        {
            if (count > 0 && count % 3 == 0)
            {
                result.Insert(0, '.');
            }

            result.Insert(0, n % 10);
            n /= 10;
            count++;
        }

        return result.ToString();
    }
}
