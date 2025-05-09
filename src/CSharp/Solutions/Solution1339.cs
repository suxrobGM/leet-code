using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1339
{
    /// <summary>
    /// 1339. Maximum Product of Splitted Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/maximum-product-of-splitted-binary-tree">See the problem</a>
    /// </summary>
    public int MaxProduct(TreeNode root)
    {
        var totalSum = GetTotalSum(root);
        long maxProduct = 0;
        GetMaxProduct(root, totalSum, ref maxProduct);
        return (int)(maxProduct % 1_000_000_007);
    }

    private long GetTotalSum(TreeNode node)
    {
        if (node == null) return 0;
        return node.val + GetTotalSum(node.left) + GetTotalSum(node.right);
    }

    private long GetMaxProduct(TreeNode node, long totalSum, ref long maxProduct)
    {
        if (node == null) return 0;
        long leftSum = GetMaxProduct(node.left, totalSum, ref maxProduct);
        long rightSum = GetMaxProduct(node.right, totalSum, ref maxProduct);
        long currentSum = node.val + leftSum + rightSum;
        long product = currentSum * (totalSum - currentSum);
        maxProduct = Math.Max(maxProduct, product);
        return currentSum;
    }
}
