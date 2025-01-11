using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution938
{
    /// <summary>
    /// 938. Range Sum of BST - Easy
    /// <a href="https://leetcode.com/problems/range-sum-of-bst">See the problem</a>
    /// </summary>
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        int sum = 0;
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node == null)
            {
                continue;
            }

            if (node.val > low)
            {
                stack.Push(node.left);
            }

            if (node.val < high)
            {
                stack.Push(node.right);
            }

            if (node.val >= low && node.val <= high)
            {
                sum += node.val;
            }
        }

        return sum;
    }
}
