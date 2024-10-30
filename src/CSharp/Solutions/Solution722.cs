using System.Text;

namespace LeetCode.Solutions;

public class Solution722
{
    /// <summary>
    /// 722. Remove Comments - Medium
    /// <a href="https://leetcode.com/problems/remove-comments">See the problem</a>
    /// </summary>
    public IList<string> RemoveComments(string[] source)
    {
        var sb = new StringBuilder();
        var inBlockComment = false;
        var result = new List<string>();

        foreach (var line in source)
        {
            var i = 0;
            if (!inBlockComment)
            {
                sb = new StringBuilder();
            }

            while (i < line.Length)
            {
                if (!inBlockComment && i + 1 < line.Length && line[i] == '/' && line[i + 1] == '/')
                {
                    break;  // Skip the rest of the line
                }
                else if (!inBlockComment && i + 1 < line.Length && line[i] == '/' && line[i + 1] == '*')
                {
                    inBlockComment = true;
                    i++;
                }
                else if (inBlockComment && i + 1 < line.Length && line[i] == '*' && line[i + 1] == '/')
                {
                    inBlockComment = false;
                    i++;
                }
                else if (!inBlockComment)
                {
                    sb.Append(line[i]);
                }
                i++;
            }

            if (!inBlockComment && sb.Length > 0)
            {
                result.Add(sb.ToString());
            }
        }

        return result;
    }
}
