namespace LeetCode.Solutions;

public class Solution590
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
    /// 590. N-ary Tree Postorder Traversal - Easy
    /// <a href="https://leetcode.com/problems/n-ary-tree-postorder-traversal">See the problem</a>
    /// </summary>
    public IList<int> Postorder(Node root)
    {
        var result = new List<int>();
        Postorder(root, result);
        return result;
    }

    private void Postorder(Node root, List<int> result)
    {
        if (root == null)
        {
            return;
        }
        foreach (var child in root.children)
        {
            Postorder(child, result);
        }
        result.Add(root.val);
    }
}
