using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1457
{
    private int count = 0;

    /// <summary>
    /// 1457. Pseudo-Palindromic Paths in a Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree">See the problem</a>
    /// </summary>
    public int PseudoPalindromicPaths(TreeNode root)
    {
        DFS(root, 0);
        return count;
    }

    private void DFS(TreeNode node, int path)
    {
        if (node == null)
            return;

        // Flip the bit corresponding to the node's value
        path ^= (1 << node.val);

        // If it's a leaf node, check if the path is pseudo-palindromic
        if (node.left == null && node.right == null)
        {
            // Check if at most one bit is set in path
            if ((path & (path - 1)) == 0)
            {
                count++;
            }
        }

        DFS(node.left, path);
        DFS(node.right, path);
    }
}
