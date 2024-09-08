using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution530
{
    /// <summary>
    /// 530. Minimum Absolute Difference in BST - Easy
    /// <a href="https://leetcode.com/problems/minimum-absolute-difference-in-bst">See the problem</a>
    /// </summary>
    public int GetMinimumDifference(TreeNode root)
    {
        var prev = -1;
        var minDiff = int.MaxValue;

        void InOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.left);

            if (prev != -1)
            {
                minDiff = Math.Min(minDiff, node.val - prev);
            }

            prev = node.val;

            InOrder(node.right);
        }

        InOrder(root);

        return minDiff;
    }
}
