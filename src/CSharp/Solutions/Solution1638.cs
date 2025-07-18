using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1638
{
    /// <summary>
    /// 1638. Count Substrings That Differ by One Character - Medium
    /// <a href="https://leetcode.com/problems/count-substrings-that-differ-by-one-character">See the problem</a>
    /// </summary>
    public int CountSubstrings(string s, string t)
    {
        int count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < t.Length; j++)
            {
                int diff = 0;

                for (int k = 0; i + k < s.Length && j + k < t.Length; k++)
                {
                    if (s[i + k] != t[j + k])
                        diff++;

                    if (diff > 1)
                        break;

                    if (diff == 1)
                        count++;
                }
            }
        }

        return count;
    }
}
