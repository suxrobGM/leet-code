using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution173
{
    /// <summary>
    /// 173. Binary Search Tree Iterator - Medium
    /// <a href="https://leetcode.com/problems/binary-search-tree-iterator">See the problem</a>
    /// </summary>
    public class BSTIterator 
    {
        private readonly Stack<TreeNode> _stack = new();

        public BSTIterator(TreeNode root)
        {
            FillStack(root);
        }

        public int Next()
        {
            var node = _stack.Pop();
            FillStack(node.right);

            return node.val;
        }

        public bool HasNext()
        {
            return _stack.Count > 0;
        }

        private void FillStack(TreeNode node)
        {
            while (node != null)
            {
                _stack.Push(node);
                node = node.left;
            }
        }
    }
}
