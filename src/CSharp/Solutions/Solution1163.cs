using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1163
{
    /// <summary>
    /// 1163. Last Substring in Lexicographical Order - Hard
    /// <a href="https://leetcode.com/problems/last-substring-in-lexicographical-order">See the problem</a>
    /// </summary>
    public string LastSubstring(string s)
    {
        int n = s.Length;
        int i = 0, j = 1, k = 0;

        while (j + k < n)
        {
            if (s[i + k] == s[j + k])
            {
                k++;
            }
            else if (s[i + k] < s[j + k])
            {
                i = Math.Max(i + k + 1, j);
                j = i + 1;
                k = 0;
            }
            else // s[i + k] > s[j + k]
            {
                j = j + k + 1;
                k = 0;
            }
        }

        return s.Substring(i);
    }
}
