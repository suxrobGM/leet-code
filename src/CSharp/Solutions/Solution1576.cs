using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1576
{
    /// <summary>
    /// 1576. Replace All ?'s to Avoid Consecutive Repeating Characters - Easy
    /// <a href="https://leetcode.com/problems/replace-all-s-to-avoid-consecutive-repeating-characters">See the problem</a>
    /// </summary>
    public string ModifyString(string s)
    {
        var sb = new StringBuilder(s);
        int n = sb.Length;

        for (int i = 0; i < n; i++)
        {
            if (sb[i] == '?')
            {
                for (char c = 'a'; c <= 'c'; c++)
                {
                    if ((i > 0 && sb[i - 1] == c) || (i < n - 1 && sb[i + 1] == c))
                        continue;

                    sb[i] = c;
                    break;
                }
            }
        }

        return sb.ToString();
    }
}
