using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1261
{
    /// <summary>
    /// 1261. Find Elements in a Contaminated Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree">See the problem</a>
    /// </summary>
    public class FindElements
    {
        private readonly HashSet<int> _elements = [];

        public FindElements(TreeNode root)
        {
            if (root == null) return;
            root.val = 0;
            _elements.Add(0);
            RecoverTree(root);
        }

        private void RecoverTree(TreeNode node)
        {
            if (node.left != null)
            {
                node.left.val = 2 * node.val + 1;
                _elements.Add(node.left.val);
                RecoverTree(node.left);
            }

            if (node.right != null)
            {
                node.right.val = 2 * node.val + 2;
                _elements.Add(node.right.val);
                RecoverTree(node.right);
            }
        }

        public bool Find(int target) => _elements.Contains(target);
    }
}
