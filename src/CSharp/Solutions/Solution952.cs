using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution952
{
    /// <summary>
    /// 952. Largest Component Size by Common Factor - Hard
    /// <a href="https://leetcode.com/problems/largest-component-size-by-common-factor">See the problem</a>
    /// </summary>
    public int LargestComponentSize(int[] nums)
    {
        var max = nums.Max();
        var dsu = new DisjointSetUnion(max + 1);

        foreach (var num in nums)
        {
            for (var i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    dsu.Union(num, i);
                    dsu.Union(num, num / i);
                }
            }
        }

        var count = new Dictionary<int, int>();
        var result = 0;

        foreach (var num in nums)
        {
            var root = dsu.Find(num);
            count[root] = count.GetValueOrDefault(root) + 1;
            result = Math.Max(result, count[root]);
        }

        return result;
    }

    public class DisjointSetUnion
    {
        private readonly int[] _parent;
        private readonly int[] _rank;

        public DisjointSetUnion(int n)
        {
            _parent = new int[n];
            _rank = new int[n];

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
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY)
            {
                return;
            }

            if (_rank[rootX] < _rank[rootY])
            {
                _parent[rootX] = rootY;
            }
            else if (_rank[rootX] > _rank[rootY])
            {
                _parent[rootY] = rootX;
            }
            else
            {
                _parent[rootX] = rootY;
                _rank[rootY]++;
            }
        }
    }
}
