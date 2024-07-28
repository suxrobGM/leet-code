namespace LeetCode.Solutions;

public class Solution427
{
    /// <summary>
    /// 427. Construct Quad Tree - Medium
    /// <a href="https://leetcode.com/problems/construct-quad-tree">See the problem</a>
    /// </summary>
    public Node Construct(int[][] grid)
    {
        return Construct(grid, 0, 0, grid.Length);
    }

    private Node Construct(int[][] grid, int x, int y, int size)
    {
        if (size == 1)
        {
            return new Node(grid[x][y] == 1, true);
        }

        var half = size / 2;
        var topLeft = Construct(grid, x, y, half);
        var topRight = Construct(grid, x, y + half, half);
        var bottomLeft = Construct(grid, x + half, y, half);
        var bottomRight = Construct(grid, x + half, y + half, half);

        if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf &&
            topLeft.val == topRight.val && topRight.val == bottomLeft.val && bottomLeft.val == bottomRight.val)
        {
            return new Node(topLeft.val, true);
        }

        return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }

    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node()
        {
        }

        public Node(bool val, bool isLeaf)
        {
            this.val = val;
            this.isLeaf = isLeaf;
        }

        public Node(bool val, bool isLeaf, Node topLeft, Node topRight, Node bottomLeft, Node bottomRight)
        {
            this.val = val;
            this.isLeaf = isLeaf;
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
        }
    }
}
