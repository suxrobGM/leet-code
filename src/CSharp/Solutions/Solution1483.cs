using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1483
{
    /// <summary>
    /// 1483. Kth Ancestor of a Tree Node - Hard
    /// <a href="https://leetcode.com/problems/kth-ancestor-of-a-tree-node">See the problem</a>
    /// </summary>
    public class TreeAncestor
    {
        private int[,] up;
        private int LOG;

        public TreeAncestor(int n, int[] parent)
        {
            LOG = 16; // Because 2^16 > 50000
            up = new int[n, LOG];

            for (int i = 0; i < n; i++)
            {
                up[i, 0] = parent[i];
            }

            for (int j = 1; j < LOG; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    int mid = up[i, j - 1];
                    up[i, j] = mid == -1 ? -1 : up[mid, j - 1];
                }
            }
        }

        public int GetKthAncestor(int node, int k)
        {
            for (int j = 0; j < LOG && node != -1; j++)
            {
                if (((k >> j) & 1) == 1)
                {
                    node = up[node, j];
                }
            }
            return node;
        }
    }
}
