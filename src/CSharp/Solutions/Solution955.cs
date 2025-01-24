using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution955
{
    /// <summary>
    /// 955. Delete Columns to Make Sorted II - Medium
    /// <a href="https://leetcode.com/problems/delete-columns-to-make-sorted-ii">See the problem</a>
    /// </summary>
    public int MinDeletionSize(string[] strs)
    {
        int rows = strs.Length;
        int cols = strs[0].Length;
        int deletions = 0;

        // Track if rows are sorted after each column
        var sorted = new bool[rows - 1];

        for (int col = 0; col < cols; col++)
        {
            // Assume this column will work; verify it
            var isColumnValid = true;

            for (int row = 1; row < rows; row++)
            {
                // If rows aren't sorted yet, check if this column breaks the order
                if (!sorted[row - 1] && strs[row][col] < strs[row - 1][col])
                {
                    isColumnValid = false;
                    break;
                }
            }

            if (!isColumnValid)
            {
                // This column needs to be deleted
                deletions++;
            }
            else
            {
                // Update sorted status based on this column
                for (int row = 1; row < rows; row++)
                {
                    if (strs[row][col] > strs[row - 1][col])
                    {
                        sorted[row - 1] = true;
                    }
                }
            }
        }

        return deletions;
    }
}
