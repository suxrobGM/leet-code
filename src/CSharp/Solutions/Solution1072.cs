using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1072
{
    /// <summary>
    /// 1072. Flip Columns For Maximum Number of Equal Rows - Medium
    /// <a href="https://leetcode.com/problems/flip-columns-for-maximum-number-of-equal-rows"</a>
    /// </summary>
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        var patternCount = new Dictionary<string, int>();

        foreach (var row in matrix)
        {
            // Normalize pattern: Flip if the first element is '1'
            string pattern = NormalizePattern(row);

            // Increment count for this pattern
            if (!patternCount.ContainsKey(pattern))
                patternCount[pattern] = 0;

            patternCount[pattern]++;
        }

        // Find the maximum frequency of a pattern
        int maxRows = 0;
        foreach (var count in patternCount.Values)
        {
            maxRows = Math.Max(maxRows, count);
        }

        return maxRows;
    }

    private string NormalizePattern(int[] row)
    {
        int n = row.Length;
        int[] normalized = new int[n];

        // Flip row if the first element is '1'
        for (int i = 0; i < n; i++)
        {
            normalized[i] = row[i] ^ row[0]; // XOR for automatic flipping
        }

        return string.Join(",", normalized);
    }
}
