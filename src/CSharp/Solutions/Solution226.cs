using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution226
{
    /// <summary>
    /// 226. Invert Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/invert-binary-tree">See the problem</a>
    /// </summary>
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        var left = InvertTree(root.left);
        var right = InvertTree(root.right);

        root.left = right;
        root.right = left;

        return root;
    }
}
