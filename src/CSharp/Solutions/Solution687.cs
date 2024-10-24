using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution687
{
    /// <summary>
    /// 687. Longest Univalue Path - Medium
    /// <a href="https://leetcode.com/problems/longest-univalue-path">See the problem</a>
    /// </summary>
    public int LongestUnivaluePath(TreeNode root)
    {
        var result = 0;
        LongestUnivaluePath(root, ref result);
        return result;
    }

    private static int LongestUnivaluePath(TreeNode node, ref int result)
    {
        if (node == null)
        {
            return 0;
        }

        var left = LongestUnivaluePath(node.left, ref result);
        var right = LongestUnivaluePath(node.right, ref result);

        var leftArrow = 0;
        var rightArrow = 0;

        if (node.left != null && node.left.val == node.val)
        {
            leftArrow += left + 1;
        }

        if (node.right != null && node.right.val == node.val)
        {
            rightArrow += right + 1;
        }

        result = Math.Max(result, leftArrow + rightArrow);
        return Math.Max(leftArrow, rightArrow);
    }
}
