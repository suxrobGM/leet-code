namespace LeetCode.Solutions;

public class Solution429
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
        }

        public Node(int val)
        {
            this.val = val;
        }

        public Node(int val, IList<Node> children)
        {
            this.val = val;
            this.children = children;
        }
    }

    /// <summary>
    /// 429. N-ary Tree Level Order Traversal - Medium
    /// <a href="https://leetcode.com/problems/n-ary-tree-level-order-traversal">See the problem</a>
    /// </summary>
    public IList<IList<int>> LevelOrder(Node root)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var level = new List<int>();
            var size = queue.Count;

            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);

                foreach (var child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            result.Add(level);
        }

        return result;
    }
}
