
namespace LeetCode.Solutions;

public class Solution803
{
    private int[] parent;
    private int[] size;
    private int cols;

    /// <summary>
    /// 803. Bricks Falling When Hit - Hard
    /// <a href="https://leetcode.com/problems/bricks-falling-when-hit">See the problem</a>
    /// </summary>
    public int[] HitBricks(int[][] grid, int[][] hits)
    {
        var rows = grid.Length;
        cols = grid[0].Length;

        parent = new int[rows * cols + 1];
        size = new int[rows * cols + 1];

        for (int i = 0; i <= rows * cols; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }

        // Mark bricks to be removed
        foreach (var hit in hits)
        {
            int x = hit[0], y = hit[1];
            if (grid[x][y] == 1) grid[x][y] = 2; // Mark brick for removal
        }

        // Connect all stable bricks initially
        for (var j = 0; j < cols; j++)
        {
            if (grid[0][j] == 1) Union(j, rows * cols); // Connect top row to a virtual root
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1)
                {
                    ConnectNeighbors(grid, i, j);
                }
            }
        }

        // Reverse process the hits and count drops
        var result = new int[hits.Length];
        for (var i = hits.Length - 1; i >= 0; i--)
        {
            int x = hits[i][0], y = hits[i][1];
            if (grid[x][y] == 2)
            {
                grid[x][y] = 1; // Re-add the brick
                var prevStableCount = Size(rows * cols); // Count of stable bricks before re-adding
                ConnectNeighbors(grid, x, y);
                Union(x * cols + y, rows * cols); // Connect the re-added brick to the top if it's in the top row
                var newStableCount = Size(rows * cols); // Count of stable bricks after re-adding
                result[i] = Math.Max(0, newStableCount - prevStableCount - 1); // Bricks that fall
            }
        }

        return result;
    }

    private void ConnectNeighbors(int[][] grid, int i, int j)
    {
        int rows = grid.Length, cols = grid[0].Length;
        int[][] directions = [
            [1, 0], [0, 1], [-1, 0], [0, -1]
        ];
        foreach (var dir in directions)
        {
            int x = i + dir[0], y = j + dir[1];
            if (x >= 0 && x < rows && y >= 0 && y < cols && grid[x][y] == 1)
            {
                Union(i * cols + j, x * cols + y);
            }
        }
    }

    private int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]); // Path compression
        }
        return parent[x];
    }

    private void Union(int x, int y)
    {
        var rootX = Find(x);
        var rootY = Find(y);
        if (rootX != rootY)
        {
            if (size[rootX] < size[rootY])
            {
                parent[rootX] = rootY;
                size[rootY] += size[rootX];
            }
            else
            {
                parent[rootY] = rootX;
                size[rootX] += size[rootY];
            }
        }
    }

    private int Size(int x)
    {
        return size[Find(x)];
    }
}
