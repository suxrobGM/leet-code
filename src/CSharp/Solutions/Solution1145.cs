using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1145
{
    /// <summary>
    /// 1145. Binary Tree Coloring Game - Medium
    /// <a href="https://leetcode.com/problems/binary-tree-coloring-game">See the problem</a>
    /// </summary>
    public bool BtreeGameWinningMove(TreeNode root, int n, int x)
    {
        var left = 0;
        var right = 0;

        var target = FindNode(root, x);

        if (target.left != null)
        {
            left = CountNodes(target.left);
        }

        if (target.right != null)
        {
            right = CountNodes(target.right);
        }

        var parent = n - left - right - 1;

        return left > n / 2 || right > n / 2 || parent > n / 2;
    }

    private TreeNode FindNode(TreeNode node, int x)
    {
        if (node == null)
        {
            return null;
        }

        if (node.val == x)
        {
            return node;
        }

        var left = FindNode(node.left, x);

        if (left != null)
        {
            return left;
        }

        return FindNode(node.right, x);
    }

    private int CountNodes(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + CountNodes(node.left) + CountNodes(node.right);
    }
}
