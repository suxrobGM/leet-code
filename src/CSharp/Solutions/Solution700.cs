using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution700
{
    /// <summary>
    /// 700. Search in a Binary Search Tree - Easy
    /// <a href="https://leetcode.com/problems/search-in-a-binary-search-tree">See the problem</a>
    /// </summary>
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root == null)
        {
            return null;
        }

        if (root.val == val)
        {
            return root;
        }

        if (val < root.val)
        {
            return SearchBST(root.left, val);
        }

        return SearchBST(root.right, val);
    }
}
