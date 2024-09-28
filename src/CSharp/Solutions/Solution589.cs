namespace LeetCode.Solutions;

public class Solution589
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
    /// 589. N-ary Tree Preorder Traversal - Easy
    /// <a href="https://leetcode.com/problems/n-ary-tree-preorder-traversal">See the problem</a>
    /// </summary>
    public IList<int> Preorder(Node root)
    {
        var result = new List<int>();
        Preorder(root, result);
        return result;
    }

    private void Preorder(Node root, List<int> result)
    {
        if (root == null)
        {
            return;
        }
        result.Add(root.val);
        foreach (var child in root.children)
        {
            Preorder(child, result);
        }
    }
}
