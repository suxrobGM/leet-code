using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1080
{
    /// <summary>
    /// 1080. Insufficient Nodes in Root to Leaf Paths - Medium
    /// <a href="https://leetcode.com/problems/insufficient-nodes-in-root-to-leaf-paths"</a>
    /// </summary>
    public TreeNode SufficientSubset(TreeNode root, int limit)
    {
        return Dfs(root, 0, limit);
    }

    private TreeNode Dfs(TreeNode node, int sum, int limit)
    {
        if (node == null)
        {
            return null;
        }

        sum += node.val;

        if (node.left == null && node.right == null)
        {
            return sum < limit ? null : node;
        }

        node.left = Dfs(node.left, sum, limit);
        node.right = Dfs(node.right, sum, limit);

        return node.left == null && node.right == null ? null : node;
    }
}
