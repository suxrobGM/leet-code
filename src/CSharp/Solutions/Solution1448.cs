using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1448
{
    /// <summary>
    /// 1448. Count Good Nodes in Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/count-good-nodes-in-binary-tree">See the problem</a>
    /// </summary>
    public int GoodNodes(TreeNode root)
    {
        return CountGoodNodes(root, root.val);
    }

    private int CountGoodNodes(TreeNode node, int maxValue)
    {
        if (node == null)
        {
            return 0;
        }

        var goodNodeCount = node.val >= maxValue ? 1 : 0;
        maxValue = Math.Max(maxValue, node.val);

        goodNodeCount += CountGoodNodes(node.left, maxValue);
        goodNodeCount += CountGoodNodes(node.right, maxValue);

        return goodNodeCount;
    }
}
