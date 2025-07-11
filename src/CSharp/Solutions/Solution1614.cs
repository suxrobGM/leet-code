using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1614
{
    /// <summary>
    /// 1614. Maximum Nesting Depth of the Parentheses - Easy
    /// <a href="https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses">See the problem</a>
    /// </summary>
    public int MaxDepth(string s)
    {
        int maxDepth = 0;
        int currentDepth = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                currentDepth++;
                maxDepth = Math.Max(maxDepth, currentDepth);
            }
            else if (c == ')')
            {
                currentDepth--;
            }
        }

        return maxDepth;
    }
}
