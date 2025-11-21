using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1910
{
    /// <summary>
    /// 1910. Remove All Occurrences of a Substring - Medium
    /// <a href="https://leetcode.com/problems/remove-all-occurrences-of-a-substring">See the problem</a>
    /// </summary>
    public string RemoveOccurrences(string s, string part)
    {
        var sb = new StringBuilder(s);
        int partLength = part.Length;

        int index = sb.ToString().IndexOf(part);
        while (index != -1)
        {
            sb.Remove(index, partLength);
            index = sb.ToString().IndexOf(part);
        }

        return sb.ToString();
    }
}
