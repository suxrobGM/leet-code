using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1530
{
    private int result = 0;

    /// <summary>
    /// 1530. Number of Good Leaf Nodes Pairs - Medium
    /// <a href="https://leetcode.com/problems/number-of-good-leaf-nodes-pairs">See the problem</a>
    /// </summary>
    public int CountPairs(TreeNode root, int distance)
    {
        DFS(root, distance);
        return result;
    }

    private int[] DFS(TreeNode node, int distance)
    {
        int[] counts = new int[distance + 1];
        if (node == null) return counts;

        // If it's a leaf node
        if (node.left == null && node.right == null)
        {
            counts[1] = 1; // 1 step from current node to leaf
            return counts;
        }

        int[] left = DFS(node.left, distance);
        int[] right = DFS(node.right, distance);

        // Count all good leaf pairs
        for (int i = 1; i <= distance; i++)
        {
            for (int j = 1; j <= distance - i; j++)
            {
                result += left[i] * right[j];
            }
        }

        // Update counts to parent (add 1 to all depths)
        for (int i = 1; i < distance; i++)
        {
            counts[i + 1] = left[i] + right[i];
        }

        return counts;
    }
}
