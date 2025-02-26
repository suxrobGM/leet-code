using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1026
{
    /// <summary>
    /// 1026. Maximum Difference Between Node and Ancestor - Medium
    /// <a href="https://leetcode.com/problems/maximum-difference-between-node-and-ancestor</a>
    /// </summary>
    public int MaxAncestorDiff(TreeNode root)
    {
        return MaxAncestorDiff(root, root.val, root.val);
    }

    private int MaxAncestorDiff(TreeNode node, int min, int max)
    {
        if (node == null)
        {
            return max - min;
        }

        max = Math.Max(max, node.val);
        min = Math.Min(min, node.val);

        var left = MaxAncestorDiff(node.left, min, max);
        var right = MaxAncestorDiff(node.right, min, max);

        return Math.Max(left, right);
    }
}
