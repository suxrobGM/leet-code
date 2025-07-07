using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1598
{
    /// <summary>
    /// 1598. Crawler Log Folder - Easy
    /// <a href="https://leetcode.com/problems/crawler-log-folder">See the problem</a>
    /// </summary>
    public int MinOperations(string[] logs)
    {
        int depth = 0;

        foreach (string log in logs)
        {
            if (log == "../")
            {
                if (depth > 0) depth--;
            }
            else if (log == "./")
            {
                // Do nothing for current directory
            }
            else
            {
                // It's a folder, go deeper
                depth++;
            }
        }

        return depth;
    }
}
