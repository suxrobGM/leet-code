using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1632
{
    /// <summary>
    /// 1632. Rank Transform of a Matrix - Hard
    /// <a href="https://leetcode.com/problems/rank-transform-of-a-matrix">See the problem</a>
    /// </summary>
    public int[][] MatrixRankTransform(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int[][] answer = new int[m][];
        for (int i = 0; i < m; i++) answer[i] = new int[n];

        // Track the current max rank in each row and column
        int[] rowMax = new int[m];
        int[] colMax = new int[n];

        // Group cells by value
        var valueGroups = new SortedDictionary<int, List<(int, int)>>();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int val = matrix[i][j];
                if (!valueGroups.ContainsKey(val))
                    valueGroups[val] = new List<(int, int)>();
                valueGroups[val].Add((i, j));
            }
        }


        foreach (var group in valueGroups)
        {
            var parent = new Dictionary<(int, int), (int, int)>();

            // Union-Find with path compression
            (int, int) Find((int, int) p)
            {
                if (!parent.ContainsKey(p)) parent[p] = p;
                if (!parent[p].Equals(p))
                    parent[p] = Find(parent[p]);
                return parent[p];
            }

            void Union((int, int) a, (int, int) b)
            {
                parent[Find(a)] = Find(b);
            }

            // Union same rows and same columns
            var rowMap = new Dictionary<int, (int, int)>();
            var colMap = new Dictionary<int, (int, int)>();
            foreach (var (i, j) in group.Value)
            {
                if (rowMap.ContainsKey(i))
                    Union((i, j), rowMap[i]);
                else
                    rowMap[i] = (i, j);

                if (colMap.ContainsKey(j))
                    Union((i, j), colMap[j]);
                else
                    colMap[j] = (i, j);
            }

            // Group by root parent
            var groupMap = new Dictionary<(int, int), List<(int, int)>>();
            foreach (var (i, j) in group.Value)
            {
                var root = Find((i, j));
                if (!groupMap.ContainsKey(root))
                    groupMap[root] = new List<(int, int)>();
                groupMap[root].Add((i, j));
            }

            // For each group, find the rank and assign
            var rankUpdates = new List<(int, int, int)>();
            foreach (var kv in groupMap)
            {
                int maxRank = 0;
                foreach (var (i, j) in kv.Value)
                    maxRank = Math.Max(maxRank, Math.Max(rowMax[i], colMax[j]));

                int rank = maxRank + 1;
                foreach (var (i, j) in kv.Value)
                {
                    answer[i][j] = rank;
                    rowMax[i] = rank;
                    colMax[j] = rank;
                }
            }
        }

        return answer;
    }
}
