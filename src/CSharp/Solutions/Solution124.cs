using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution124
{
    /// <summary>
    /// 124. Binary Tree Maximum Path Sum - Hard
    /// <a href="https://leetcode.com/problems/binary-tree-maximum-path-sum">See the problem</a>
    /// </summary>
    public int MaxPathSum(TreeNode root)
    {
        var maxSum = int.MinValue;

        MaxPathSum(root, ref maxSum);

        return maxSum;
    }
    
    private int MaxPathSum(TreeNode node, ref int maxSum)
    {
        if (node is null)
        {
            return 0;
        }

        var left = Math.Max(0, MaxPathSum(node.left, ref maxSum));
        var right = Math.Max(0, MaxPathSum(node.right, ref maxSum));

        maxSum = Math.Max(maxSum, left + right + node.val);

        return Math.Max(left, right) + node.val;
    }
}
