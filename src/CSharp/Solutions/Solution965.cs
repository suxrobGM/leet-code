using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution965
{
    /// <summary>
    /// 965. Univalued Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/univalued-binary-tree">See the problem</a>
    /// </summary>
    public bool IsUnivalTree(TreeNode root)
    {
        if (root == null) return true;

        static bool IsUnivalTree(TreeNode node, int val)
        {
            if (node == null) return true;
            if (node.val != val) return false;
            return IsUnivalTree(node.left, val) && IsUnivalTree(node.right, val);
        }
        
        return IsUnivalTree(root, root.val);
    }
}
