using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1541
{
    /// <summary>
    /// 1541. Minimum Insertions to Balance a Parentheses String - Medium
    /// <a href="https://leetcode.com/problems/minimum-insertions-to-balance-a-parentheses-string">See the problem</a>
    /// </summary>
    public int MinInsertions(string s)
    {
        int openCount = 0;
        int insertions = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                openCount++;
            }
            else if (s[i] == ')')
            {
                if (i + 1 < s.Length && s[i + 1] == ')')
                {
                    // Found a pair of closing parentheses
                    openCount--;
                    i++; // Skip the next character
                }
                else
                {
                    // Found a single closing parenthesis
                    insertions++;
                    openCount--;
                }

                // If openCount goes negative, we need to insert an opening parenthesis
                if (openCount < 0)
                {
                    insertions++;
                    openCount = 0;
                }
            }
        }

        // If there are unmatched opening parentheses, we need to insert closing ones
        return insertions + openCount * 2;
    }
}
