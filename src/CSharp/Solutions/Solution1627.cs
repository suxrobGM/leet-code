using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1627
{
    /// <summary>
    /// 1626. Best Team With No Conflicts - Medium
    /// <a href="https://leetcode.com/problems/best-team-with-no-conflicts">See the problem</a>
    /// </summary>
    public IList<bool> AreConnected(int n, int threshold, int[][] queries)
    {
        int[] parent = new int[n + 1];

        // Initialize Union-Find
        for (int i = 0; i <= n; i++)
        {
            parent[i] = i;
        }

        int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        void Union(int x, int y)
        {
            int px = Find(x);
            int py = Find(y);
            if (px != py)
            {
                parent[px] = py;
            }
        }

        // Union all numbers with common divisors > threshold
        for (int i = threshold + 1; i <= n; i++)
        {
            for (int multiple = 2 * i; multiple <= n; multiple += i)
            {
                Union(i, multiple);
            }
        }

        // Answer each query
        bool[] answer = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int a = queries[i][0];
            int b = queries[i][1];
            answer[i] = Find(a) == Find(b);
        }

        return answer;
    }
}
