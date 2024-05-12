namespace LeetCode.Solutions;

public class Solution116
{
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    
    /// <summary>
    /// 116. Populating Next Right Pointers in Each Node - Medium
    /// <a href="https://leetcode.com/problems/populating-next-right-pointers-in-each-node">See the problem</a>
    /// </summary>
    public Node Connect(Node root)
    {
        if (root == null)
        {
            return null;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var size = queue.Count;

            for (var i = 0; i < size; i++)
            {
                var current = queue.Dequeue();

                if (i < size - 1)
                {
                    current.next = queue.Peek();
                }

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }
        }

        return root;
    }
}
