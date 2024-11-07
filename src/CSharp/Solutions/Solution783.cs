using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution783
{
    /// <summary>
    /// 783. Minimum Distance Between BST Nodes - Easy
    /// <a href="https://leetcode.com/problems/minimum-distance-between-bst-nodes">See the problem</a>
    /// </summary>
    public int MinDiffInBST(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        long prev = int.MinValue;
        long minDiff = int.MaxValue;

        while (root != null || stack.Count > 0)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            root = stack.Pop();
            minDiff = Math.Min(minDiff, root.val - prev);
            prev = root.val;
            root = root.right;
        }

        return (int)minDiff;
    }
}
