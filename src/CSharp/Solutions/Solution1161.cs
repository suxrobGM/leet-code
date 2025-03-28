using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1161
{
    /// <summary>
    /// 1161. Maximum Level Sum of a Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree">See the problem</a>
    /// </summary>
    public int MaxLevelSum(TreeNode root)
    {
        var maxSum = int.MinValue;
        var maxLevel = 0;
        var level = 1;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var size = queue.Count;
            var sum = 0;

            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                sum += node.val;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                maxLevel = level;
            }

            level++;
        }

        return maxLevel;
    }
}
