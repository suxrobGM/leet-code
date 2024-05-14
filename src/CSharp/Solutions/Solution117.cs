namespace LeetCode.Solutions;

public class Solution117
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
    /// 117. Populating Next Right Pointers in Each Node II - Medium
    /// <a href="https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii">See the problem</a>
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
            Node prev = null;

            for (var i = 0; i < size; i++)
            {
                var current = queue.Dequeue();

                if (prev != null)
                {
                    prev.next = current;
                }

                prev = current;

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
