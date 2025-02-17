using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution998
{
    /// <summary>
    /// 998. Maximum Binary Tree II - Medium
    /// <a href="https://leetcode.com/problems/maximum-binary-tree-ii">See the problem</a>
    /// </summary>
    public TreeNode InsertIntoMaxTree(TreeNode root, int val)
    {
        if (root == null || root.val < val)
        {
            var node = new TreeNode(val);
            node.left = root;
            return node;
        }

        root.right = InsertIntoMaxTree(root.right, val);
        return root;
    }
}
