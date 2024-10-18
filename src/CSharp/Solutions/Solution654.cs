using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution654
{
    /// <summary>
    /// 654. Maximum Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/maximum-binary-tree">See the problem</a>
    /// </summary>
    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        var stack = new Stack<TreeNode>();
        foreach (var num in nums)
        {
            var node = new TreeNode(num);
            while (stack.Count != 0 && stack.Peek().val < num)
            {
                node.left = stack.Pop();
            }

            if (stack.Count != 0)
            {
                stack.Peek().right = node;
            }

            stack.Push(node);
        }

        while (stack.Count > 1)
        {
            stack.Pop();
        }

        return stack.Pop();
    }
}
