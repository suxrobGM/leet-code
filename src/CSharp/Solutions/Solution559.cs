using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution559
{
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }

    /// <summary>
    /// 559. Maximum Depth of N-ary Tree - Easy
    /// <a href="https://leetcode.com/problems/maximum-depth-of-n-ary-tree">See the problem</a>
    /// </summary>
    public int MaxDepth(Node root)
    {
        if (root == null)
        {
            return 0;
        }

        int max = 0;
        foreach (var child in root.children)
        {
            max = Math.Max(max, MaxDepth(child));
        }

        return max + 1;
    }
}
