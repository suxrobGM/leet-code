using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1038
{
    /// <summary>
    /// 1038. Binary Search Tree to Greater Sum Tree - Medium
    /// <a href="https://leetcode.com/problems/binary-search-tree-to-greater-sum-tree</a>
    /// </summary>
    public TreeNode BstToGst(TreeNode root)
    {
        int sum = 0;
        BstToGst(root, ref sum);
        return root;
    }

    private void BstToGst(TreeNode root, ref int sum)
    {
        if (root == null)
        {
            return;
        }

        BstToGst(root.right, ref sum);
        sum += root.val;
        root.val = sum;
        BstToGst(root.left, ref sum);
    }
}
