using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution984
{
    /// <summary>
    /// 984. String Without AAA or BBB - Medium
    /// <a href="https://leetcode.com/problems/string-without-aaa-or-bbb">See the problem</a>
    /// </summary>
    public string StrWithout3a3b(int a, int b)
    {
        var result = new StringBuilder();
        while (a > 0 || b > 0)
        {
            int len = result.Length;

            bool writeA;
            // Determine whether to add 'a' or 'b' based on previous characters and remaining counts
            if (len >= 2 && result[len - 1] == result[len - 2])
            {
                // If the last two characters are the same, switch to the other character
                writeA = result[len - 1] == 'b';
            }
            else
            {
                // Otherwise, prefer the letter that has more remaining
                writeA = a >= b;
            }

            if (writeA)
            {
                result.Append('a');
                a--;
            }
            else
            {
                result.Append('b');
                b--;
            }
        }
        return result.ToString();
    }
}
