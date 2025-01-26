using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution958
{
    /// <summary>
    /// 958. Check Completeness of a Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/check-completeness-of-a-binary-tree">See the problem</a>
    /// </summary>
    public bool IsCompleteTree(TreeNode root)
    {
        if (root == null) 
        {
            return true;
        }

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var encounteredNull = false;

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (currentNode == null)
            {
                encounteredNull = true;
            }
            else
            {
                if (encounteredNull)
                {
                    // If we see a non-null node after a null, it's not a complete binary tree
                    return false;
                }

                queue.Enqueue(currentNode.left);
                queue.Enqueue(currentNode.right);
            }
        }

        return true;
    }
}
