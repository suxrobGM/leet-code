using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution947
{
    /// <summary>
    /// 947. Most Stones Removed with Same Row or Column - Medium
    /// <a href="https://leetcode.com/problems/most-stones-removed-with-same-row-or-column">See the problem</a>
    /// </summary>
    public int RemoveStones(int[][] stones)
    {
        var uf = new UnionFind();

        foreach (var stone in stones)
        {
            uf.Union(stone[0] + 10000, stone[1]);
        }

        return stones.Length - uf.Count;
    }

    public class UnionFind
    {
        private Dictionary<int, int> parent;
        public int Count { get; private set; }

        public UnionFind()
        {
            parent = new Dictionary<int, int>();
            Count = 0;
        }

        public int Find(int x)
        {
            if (!parent.ContainsKey(x))
            {
                parent[x] = x;
                Count++;
            }

            if (x != parent[x])
            {
                parent[x] = Find(parent[x]);
            }

            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                parent[rootX] = rootY;
                Count--;
            }
        }
    }
}
