using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1147
{
    /// <summary>
    /// 1147. Longest Chunked Palindrome Decomposition - Hard
    /// <a href="https://leetcode.com/problems/longest-chunked-palindrome-decomposition">See the problem</a>
    /// </summary>
    public int LongestDecomposition(string text)
    {
        int left = 0, right = text.Length - 1;
        int k = 0;

        while (left <= right)
        {
            var matched = false;

            for (int len = 1; left + len - 1 < right - len + 1; len++)
            {
                var prefix = text.Substring(left, len);
                var suffix = text.Substring(right - len + 1, len);

                if (prefix == suffix)
                {
                    k += 2;
                    left += len;
                    right -= len;
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                k += 1;
                break;
            }
        }

        return k;
    }
}
