using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution959
{
    /// <summary>
    /// 959. Regions Cut By Slashes - Medium
    /// <a href="https://leetcode.com/problems/regions-cut-by-slashes">See the problem</a>
    /// </summary>
    public int RegionsBySlashes(string[] grid)
    {
        var n = grid.Length;
        var size = n * n * 4;
        var dsu = new DisjointSetUnion(size);

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var index = i * n + j;
                var offset = index * 4;

                switch (grid[i][j])
                {
                    case ' ':
                        dsu.Union(offset, offset + 1);
                        dsu.Union(offset + 1, offset + 2);
                        dsu.Union(offset + 2, offset + 3);
                        break;
                    case '/':
                        dsu.Union(offset, offset + 3);
                        dsu.Union(offset + 1, offset + 2);
                        break;
                    case '\\':
                        dsu.Union(offset, offset + 1);
                        dsu.Union(offset + 2, offset + 3);
                        break;
                }

                if (i > 0)
                {
                    dsu.Union(offset, offset - n * 4 + 2);
                }

                if (j > 0)
                {
                    dsu.Union(offset + 3, offset - 4 + 1);
                }
            }
        }

        var result = 0;

        for (var i = 0; i < size; i++)
        {
            if (dsu.Find(i) == i)
            {
                result++;
            }
        }

        return result;
    }

    private class DisjointSetUnion
    {
        private readonly int[] _parent;

        public DisjointSetUnion(int n)
        {
            _parent = new int[n];

            for (var i = 0; i < n; i++)
            {
                _parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (_parent[x] != x)
            {
                _parent[x] = Find(_parent[x]);
            }

            return _parent[x];
        }

        public void Union(int x, int y)
        {
            _parent[Find(x)] = Find(y);
        }
    }
}
