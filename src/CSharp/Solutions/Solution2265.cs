using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2265
{
    /// <summary>
    /// 2265. Count Nodes Equal to Average of Subtree - Medium
    /// <a href="https://leetcode.com/problems/count-nodes-equal-to-average-of-subtree">See the problem</a>
    /// </summary>
    public int AverageOfSubtree(TreeNode root)
    {
        var count = 0;

        int[] dfs(TreeNode node)
        {
            if (node == null)
            {
                return [0, 0];
            }

            var left = dfs(node.left);
            var right = dfs(node.right);

            var sum = left[0] + right[0] + node.val;
            var nodes = left[1] + right[1] + 1;

            if (sum / nodes == node.val)
            {
                count++;
            }

            return [sum, nodes];
        }

        dfs(root);

        return count;
    }
}
