using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1302
{
    /// <summary>
    /// 1302. Deepest Leaves Sum - Medium
    /// <a href="https://leetcode.com/problems/deepest-leaves-sum">See the problem</a>
    /// </summary>
    public int DeepestLeavesSum(TreeNode root)
    {
        if (root == null) return 0;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int sum = 0;
        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            sum = 0; // Reset sum for the current level

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();
                sum += node.val;

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }

        return sum;
    }
}
