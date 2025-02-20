using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1008
{
    /// <summary>
    /// 1008. Construct Binary Search Tree from Preorder Traversal - Medium
    /// <a href="https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal</a>
    /// </summary>
    public TreeNode BstFromPreorder(int[] preorder)
    {
        var root = new TreeNode(preorder[0]);
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        for (var i = 1; i < preorder.Length; i++)
        {
            var node = stack.Peek();
            var child = new TreeNode(preorder[i]);

            while (stack.Count > 0 && stack.Peek().val < child.val)
            {
                node = stack.Pop();
            }

            if (node.val < child.val)
            {
                node.right = child;
            }
            else
            {
                node.left = child;
            }

            stack.Push(child);
        }

        return root;
    }
}
