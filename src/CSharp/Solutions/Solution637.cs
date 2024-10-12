using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution637
{
    /// <summary>
    /// 637. Average of Levels in Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/average-of-levels-in-binary-tree">See the problem</a>
    /// </summary>
    public IList<double> AverageOfLevels(TreeNode root)
    {
        var result = new List<double>();
        var queue = new Queue<TreeNode>();

        if (root == null)
        {
            return result;
        }

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var levelSize = queue.Count;
            var levelSum = 0.0;

            for (var i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                levelSum += node.val;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(levelSum / levelSize);
        }

        return result;
    }
}
