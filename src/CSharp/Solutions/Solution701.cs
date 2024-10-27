using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution701
{
    /// <summary>
    /// 701. Insert into a Binary Search Tree - Medium
    /// <a href="https://leetcode.com/problems/insert-into-a-binary-search-tree">See the problem</a>
    /// </summary>
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        if (val < root.val)
        {
            root.left = InsertIntoBST(root.left, val);
        }
        else
        {
            root.right = InsertIntoBST(root.right, val);
        }

        return root;
    }
}
