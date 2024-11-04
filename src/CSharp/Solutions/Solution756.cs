using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution756
{
    /// <summary>
    /// 756. Pyramid Transition Matrix - Medium
    /// <a href="https://leetcode.com/problems/pyramid-transition-matrix">See the problem</a>
    /// </summary>
    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        var patterns = new Dictionary<string, List<char>>();

        // Build the patterns dictionary
        foreach (var pattern in allowed)
        {
            string baseBlocks = pattern.Substring(0, 2);
            char topBlock = pattern[2];
            if (!patterns.ContainsKey(baseBlocks))
            {
                patterns[baseBlocks] = new List<char>();
            }
            patterns[baseBlocks].Add(topBlock);
        }

        // Start building the pyramid from the bottom
        return CanBuildPyramid(bottom, patterns);
    }

    private bool CanBuildPyramid(string currentRow, Dictionary<string, List<char>> patterns)
    {
        // Base case: when the row has only one block, we've reached the top
        if (currentRow.Length == 1)
        {
            return true;
        }

        // Generate all possible next rows based on current row
        var nextRows = new List<string>();
        if (!BuildNextRow(currentRow, 0, new StringBuilder(), patterns, nextRows))
        {
            return false;
        }

        // Try each possible next row
        foreach (var nextRow in nextRows)
        {
            if (CanBuildPyramid(nextRow, patterns))
            {
                return true;
            }
        }

        return false;
    }

    private bool BuildNextRow(string currentRow, int index, StringBuilder nextRow, Dictionary<string, List<char>> patterns, List<string> nextRows)
    {
        // Base case: if we completed the row
        if (index == currentRow.Length - 1)
        {
            nextRows.Add(nextRow.ToString());
            return true;
        }

        // Get the two adjacent blocks
        var baseBlocks = currentRow.Substring(index, 2);

        // If there's no valid block for the pair, return false
        if (!patterns.ContainsKey(baseBlocks))
        {
            return false;
        }

        // Try each possible block on top of this pair
        var hasValidNextRow = false;
        foreach (var topBlock in patterns[baseBlocks])
        {
            nextRow.Append(topBlock);
            if (BuildNextRow(currentRow, index + 1, nextRow, patterns, nextRows))
            {
                hasValidNextRow = true;
            }
            nextRow.Length--; // Backtrack
        }

        return hasValidNextRow;
    }
}
