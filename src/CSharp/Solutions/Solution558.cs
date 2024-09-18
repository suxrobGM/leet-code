using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution558
{
    public class Node {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node() { }
        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

    /// <summary>
    /// 558. Logical OR of Two Binary Grids Represented as Quad-Trees - Medium
    /// <a href="https://leetcode.com/problems/logical-or-of-two-binary-grids-represented-as-quad-trees">See the problem</a>
    /// </summary>
    public Node Intersect(Node quadTree1, Node quadTree2)
    {
        if (quadTree1.isLeaf)
        {
            return quadTree1.val ? quadTree1 : quadTree2;
        }

        if (quadTree2.isLeaf)
        {
            return quadTree2.val ? quadTree2 : quadTree1;
        }

        var topLeft = Intersect(quadTree1.topLeft, quadTree2.topLeft);
        var topRight = Intersect(quadTree1.topRight, quadTree2.topRight);
        var bottomLeft = Intersect(quadTree1.bottomLeft, quadTree2.bottomLeft);
        var bottomRight = Intersect(quadTree1.bottomRight, quadTree2.bottomRight);

        if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf &&
            topLeft.val == topRight.val && topRight.val == bottomLeft.val && bottomLeft.val == bottomRight.val)
        {
            return new Node(topLeft.val, true, null, null, null, null);
        }

        return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }
}
