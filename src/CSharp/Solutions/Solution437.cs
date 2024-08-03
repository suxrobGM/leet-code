using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution437
{
    /// <summary>
    /// 437. Path Sum III - Medium
    /// <a href="https://leetcode.com/problems/path-sum-iii">See the problem</a>
    /// </summary>
    public int PathSum(TreeNode root, int targetSum)
    {
        if (root == null)
        {
            return 0;
        }

        return Dfs(root, targetSum)
            + PathSum(root.left, targetSum)
            + PathSum(root.right, targetSum);

        int Dfs(TreeNode node, long sum)
        {
            var s = node.val == sum ? 1 : 0;

            if (node.left != null)
                s += Dfs(node.left, sum - node.val);

            if (node.right != null)
                s += Dfs(node.right, sum - node.val);

            return s;
        }
    }
}
