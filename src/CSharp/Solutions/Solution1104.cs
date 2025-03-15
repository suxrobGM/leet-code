using System.Text;

namespace LeetCode.Solutions;

public class Solution1104
{
    /// <summary>
    /// 1104. Path In Zigzag Labelled Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/path-in-zigzag-labelled-binary-tree">See the problem</a>
    /// </summary>
    public IList<int> PathInZigZagTree(int label)
    {
        var path = new List<int>();
        int row = (int)Math.Floor(Math.Log2(label)) + 1; // Find the row of the node

        while (label > 0)
        {
            path.Add(label);

            // Compute the true parent in a zigzag structure
            int maxVal = (1 << row) - 1; // Maximum value in the current row
            int minVal = (1 << (row - 1)); // Minimum value in the current row
            
            // Compute the true parent using reversed logic
            label = (maxVal + minVal - label) / 2;

            row--; // Move one level up
        }

        path.Reverse(); // Reverse to show path from root to node
        return path;
    }
}
