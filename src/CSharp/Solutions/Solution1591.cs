using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1591
{
    /// <summary>
    /// 1591. Strange Printer II- Hard
    /// <a href="https://leetcode.com/problems/strange-printer-ii">See the problem</a>
    /// </summary>
    public bool IsPrintable(int[][] targetGrid)
    {
        int m = targetGrid.Length, n = targetGrid[0].Length;
        var minRow = new int[61];
        var maxRow = new int[61];
        var minCol = new int[61];
        var maxCol = new int[61];

        Array.Fill(minRow, int.MaxValue);
        Array.Fill(minCol, int.MaxValue);

        var colors = new HashSet<int>();

        // Step 1: Compute the bounding rectangle for each color
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int color = targetGrid[i][j];
                colors.Add(color);
                minRow[color] = Math.Min(minRow[color], i);
                maxRow[color] = Math.Max(maxRow[color], i);
                minCol[color] = Math.Min(minCol[color], j);
                maxCol[color] = Math.Max(maxCol[color], j);
            }
        }

        // Step 2: Build dependency graph
        var graph = new Dictionary<int, HashSet<int>>();
        var indegree = new int[61];

        foreach (int color in colors)
            graph[color] = new HashSet<int>();

        foreach (int color in colors)
        {
            for (int i = minRow[color]; i <= maxRow[color]; i++)
            {
                for (int j = minCol[color]; j <= maxCol[color]; j++)
                {
                    int c = targetGrid[i][j];
                    if (c != color && !graph[color].Contains(c))
                    {
                        graph[color].Add(c);
                        indegree[c]++;
                    }
                }
            }
        }

        // Step 3: Topological sort
        var queue = new Queue<int>();
        foreach (int color in colors)
        {
            if (indegree[color] == 0)
                queue.Enqueue(color);
        }

        int printed = 0;
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            printed++;
            foreach (int neighbor in graph[curr])
            {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        return printed == colors.Count;
    }
}
