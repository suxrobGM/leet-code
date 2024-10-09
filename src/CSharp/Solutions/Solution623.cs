using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution623
{
    /// <summary>
    /// 623. Add One Row to Tree - Medium
    /// <a href="https://leetcode.com/problems/add-one-row-to-tree">See the problem</a>
    /// </summary>
    public TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        if (depth == 1)
        {
            return new TreeNode(val, root);
        }
        AddRow(root, val, depth, 1);
        return root;
    }

    private void AddRow(TreeNode node, int val, int depth, int currentDepth)
    {
        if (node == null)
        {
            return;
        }
        if (currentDepth == depth - 1)
        {
            node.left = new TreeNode(val, node.left);
            node.right = new TreeNode(val, null, node.right);
            return;
        }
        AddRow(node.left, val, depth, currentDepth + 1);
        AddRow(node.right, val, depth, currentDepth + 1);
    }
}
