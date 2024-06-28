using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution230
{
    /// <summary>
    /// 230. Kth Smallest Element in a BST - Medium
    /// <a href="https://leetcode.com/problems/kth-smallest-element-in-a-bst">See the problem</a>
    /// </summary>
    public int KthSmallest(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        var current = root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            k--;

            if (k == 0)
            {
                return current.val;
            }

            current = current.right;
        }

        return -1;
    }
}
