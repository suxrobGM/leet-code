namespace LeetCode.Solutions;

public class Solution14
{
    /// <summary>
    /// Write a function to find the longest common prefix string amongst an array of strings.
    /// If there is no common prefix, return an empty string ""
    /// <a href="https://leetcode.com/problems/longest-common-prefix/">See the problem</a>
    /// </summary>
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length < 1)
        {
            return "";
        }

        var prefix = strs[0];
        for (int i = 1; i < strs.Length; i++)
        {
            while (strs[i].IndexOf(prefix) != 0)
            {
                prefix = prefix.Substring(0, prefix.Length - 1);

                if (string.IsNullOrEmpty(prefix))
                {
                    return "";
                }
            }
        }

        return prefix;
    }
}
