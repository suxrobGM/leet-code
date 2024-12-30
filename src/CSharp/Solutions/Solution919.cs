using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution919
{
    /// <summary>
    /// 919. Complete Binary Tree Inserter - Medium
    /// <a href="https://leetcode.com/problems/complete-binary-tree-inserter">See the problem</a>
    /// </summary>
    public class CBTInserter
    {
        private readonly TreeNode _root;
        private readonly Queue<TreeNode> _queue;

        public CBTInserter(TreeNode root)
        {
            _root = root;
            _queue = new Queue<TreeNode>();
            _queue.Enqueue(root);
            while (true)
            {
                var node = _queue.Peek();
                if (node.left != null)
                {
                    _queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    _queue.Enqueue(node.right);
                }
                if (node.left != null && node.right != null)
                {
                    _queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
        }

        public int Insert(int v)
        {
            var node = _queue.Peek();
            var newNode = new TreeNode(v);
            _queue.Enqueue(newNode);
            if (node.left == null)
            {
                node.left = newNode;
            }
            else
            {
                node.right = newNode;
                _queue.Dequeue();
            }
            return node.val;
        }

        public TreeNode Get_root()
        {
            return _root;
        }
    }
}
