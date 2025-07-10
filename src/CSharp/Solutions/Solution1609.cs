using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1609
{
    /// <summary>
    /// 1609. Even Odd Tree - Medium
    /// <a href="https://leetcode.com/problems/even-odd-tree">See the problem</a>
    /// </summary>
    public bool IsEvenOddTree(TreeNode root)
    {
        if (root == null) return true;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool isEvenLevel = true;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            int prevValue = isEvenLevel ? int.MinValue : int.MaxValue;

            for (int i = 0; i < levelSize; i++)
            {
                var currentNode = queue.Dequeue();
                int currentValue = currentNode.val;

                if (isEvenLevel)
                {
                    if (currentValue % 2 == 0 || currentValue <= prevValue)
                        return false;
                }
                else
                {
                    if (currentValue % 2 != 0 || currentValue >= prevValue)
                        return false;
                }

                prevValue = currentValue;

                if (currentNode.left != null) queue.Enqueue(currentNode.left);
                if (currentNode.right != null) queue.Enqueue(currentNode.right);
            }

            isEvenLevel = !isEvenLevel;
        }

        return true;
    }
}
