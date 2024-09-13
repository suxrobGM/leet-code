using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution543
{
    /// <summary>
    /// 543. Diameter of Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/diameter-of-binary-tree">See the problem</a>
    /// </summary>
    public int DiameterOfBinaryTree(TreeNode root)
    {
        var diameter = 0;
        _ = GetDepth(root, ref diameter);
        return diameter;
    }

    private static int GetDepth(TreeNode node, ref int diameter)
    {
        if (node == null)
        {
            return 0;
        }

        var left = GetDepth(node.left, ref diameter);
        var right = GetDepth(node.right, ref diameter);
        diameter = Math.Max(diameter, left + right);
        return Math.Max(left, right) + 1;
    }
}
