using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution979
{
    /// <summary>
    /// 979. Distribute Coins in Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/distribute-coins-in-binary-tree">See the problem</a>
    /// </summary>
    public int DistributeCoins(TreeNode root)
    {
        int moves = 0;
        Dfs(root, ref moves);
        return moves;
    }

    private int Dfs(TreeNode node, ref int moves)
    {
        if (node == null) return 0;

        int left = Dfs(node.left, ref moves);
        int right = Dfs(node.right, ref moves);

        moves += Math.Abs(left) + Math.Abs(right);

        return node.val + left + right - 1;
    }
}
