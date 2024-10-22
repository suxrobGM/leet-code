using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution675
{
    /// <summary>
    /// 675. Cut Off Trees for Golf Event - Hard
    /// <a href="https://leetcode.com/problems/cut-off-trees-for-golf-event">See the problem</a>
    /// </summary>
    public int CutOffTree(IList<IList<int>> forest)
    {
        if (forest == null || forest.Count == 0 || forest[0].Count == 0) return -1;

        int m = forest.Count, n = forest[0].Count;

        // Get all trees along with their heights and positions
        var trees = new List<(int height, int row, int col)>();

        for (var i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (forest[i][j] > 1)
                {
                    trees.Add((forest[i][j], i, j));
                }
            }
        }

        // Sort trees by their height
        trees.Sort((a, b) => a.height.CompareTo(b.height));

        // Start BFS from (0, 0)
        var totalSteps = 0;
        int startRow = 0, startCol = 0;

        foreach (var tree in trees)
        {
            int steps = BFS(forest, startRow, startCol, tree.row, tree.col);
            if (steps == -1)
            {
                return -1;  // Tree is unreachable
            }
            totalSteps += steps;
            startRow = tree.row;
            startCol = tree.col;
        }

        return totalSteps;
    }

    private int BFS(IList<IList<int>> forest, int startRow, int startCol, int targetRow, int targetCol)
    {
        if (startRow == targetRow && startCol == targetCol) return 0;

        int m = forest.Count, n = forest[0].Count;
        var directions = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
        var queue = new Queue<(int row, int col, int steps)>();
        var visited = new bool[m, n];

        queue.Enqueue((startRow, startCol, 0));
        visited[startRow, startCol] = true;

        while (queue.Count > 0)
        {
            var (row, col, steps) = queue.Dequeue();

            foreach (var (dr, dc) in directions)
            {
                int newRow = row + dr, newCol = col + dc;

                // Check if the new position is within bounds, walkable, and not visited
                if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n &&
                    forest[newRow][newCol] != 0 && !visited[newRow, newCol])
                {

                    if (newRow == targetRow && newCol == targetCol)
                    {
                        return steps + 1;  // Found the target
                    }

                    queue.Enqueue((newRow, newCol, steps + 1));
                    visited[newRow, newCol] = true;
                }
            }
        }

        return -1;  // Target is unreachable
    }
}
