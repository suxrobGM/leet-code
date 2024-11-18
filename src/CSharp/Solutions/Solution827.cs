using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution827
{
    /// <summary>
    /// 827. Making A Large Island - Hard
    /// <a href="https://leetcode.com/problems/making-a-large-island">See the problem</a>
    /// </summary>
    public int LargestIsland(int[][] grid)
    {
        var n = grid.Length;
        var islandId = new int[n, n];
        var islandSizes = new Dictionary<int, int>();
        var id = 2; // Start island IDs from 2 (0 and 1 are used in the grid)

        // DFS to label islands and calculate their sizes
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 1 && islandId[i, j] == 0)
                {
                    int size = MarkIsland(grid, islandId, i, j, id);
                    islandSizes[id] = size;
                    id++;
                }
            }
        }

        // Max size of an island without flipping any 0
        int maxIsland = 0;
        foreach (var size in islandSizes.Values)
        {
            maxIsland = Math.Max(maxIsland, size);
        }

        // Check each 0 to calculate the largest possible island size
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                {
                    var seenIslands = new HashSet<int>();
                    int potentialSize = 1; // The flipped 0 counts as part of the island

                    foreach (var (ni, nj) in GetNeighbors(i, j, n))
                    {
                        int neighborId = islandId[ni, nj];
                        if (neighborId > 1 && !seenIslands.Contains(neighborId))
                        {
                            seenIslands.Add(neighborId);
                            potentialSize += islandSizes[neighborId];
                        }
                    }

                    maxIsland = Math.Max(maxIsland, potentialSize);
                }
            }
        }

        return maxIsland;
    }

    private int MarkIsland(int[][] grid, int[,] islandId, int i, int j, int id)
    {
        var n = grid.Length;
        var stack = new Stack<(int, int)>();
        stack.Push((i, j));
        islandId[i, j] = id;
        int size = 0;

        while (stack.Count > 0)
        {
            var (x, y) = stack.Pop();
            size++;

            foreach (var (nx, ny) in GetNeighbors(x, y, n))
            {
                if (grid[nx][ny] == 1 && islandId[nx, ny] == 0)
                {
                    islandId[nx, ny] = id;
                    stack.Push((nx, ny));
                }
            }
        }

        return size;
    }

    private IEnumerable<(int, int)> GetNeighbors(int i, int j, int n)
    {
        int[][] directions = [
            [1, 0], [-1, 0], [0, 1], [0, -1]
        ];

        foreach (var dir in directions)
        {
            var ni = i + dir[0];
            var nj = j + dir[1];

            if (ni >= 0 && ni < n && nj >= 0 && nj < n)
            {
                yield return (ni, nj);
            }
        }
    }
}
