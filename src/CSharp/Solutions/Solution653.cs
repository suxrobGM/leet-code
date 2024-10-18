using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution653
{
    /// <summary>
    /// 653. Two Sum IV - Input is a BST - Easy
    /// <a href="https://leetcode.com/problems/two-sum-iv-input-is-a-bst">See the problem</a>
    /// </summary>
    public bool FindTarget(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        var visited = new HashSet<int>();
        stack.Push(root);

        while (stack.Count != 0)
        {
            var top = stack.Pop();
            if (visited.Contains(k - top.val))
            {
                return true;
            }

            visited.Add(top.val);
            if (top.right != null)
            {
                stack.Push(top.right);
            }

            if (top.left != null)
            {
                stack.Push(top.left);
            }
        }

        return false;
    }
}
