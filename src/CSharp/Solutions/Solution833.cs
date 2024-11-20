using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution833
{
    /// <summary>
    /// 833. Find And Replace in String - Medium
    /// <a href="https://leetcode.com/problems/find-and-replace-in-string">See the problem</a>
    /// </summary>
    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
    {
        var n = indices.Length;

        // Combine indices, sources, and targets into a list of tuples and sort by index
        var replacements = new List<(int index, string source, string target)>();
        for (var i = 0; i < n; i++)
        {
            replacements.Add((indices[i], sources[i], targets[i]));
        }
        replacements.Sort((a, b) => a.index.CompareTo(b.index));

        // Use StringBuilder to construct the result
        var result = new StringBuilder();
        var currentIndex = 0;

        foreach (var (index, source, target) in replacements)
        {
            // Append characters from the original string up to the current index
            while (currentIndex < index)
            {
                result.Append(s[currentIndex]);
                currentIndex++;
            }

            // Check if the source matches the substring starting at `index`
            if (index + source.Length <= s.Length && s.Substring(index, source.Length) == source)
            {
                result.Append(target); // Replace with target
                currentIndex = index + source.Length; // Skip over the replaced substring
            }
        }

        // Append the remaining characters of the original string
        while (currentIndex < s.Length)
        {
            result.Append(s[currentIndex]);
            currentIndex++;
        }

        return result.ToString();
    }
}
