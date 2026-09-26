namespace LeetCode.Solutions;

public class Solution2290
{
    /// <summary>
    /// 2290. Minimum Obstacle Removal to Reach Corner - Hard
    /// <a href="https://leetcode.com/problems/minimum-obstacle-removal-to-reach-corner">See the problem</a>
    /// </summary>
    public int MinimumObstacles(int[][] grid)
    {
        var rows = grid.Length;
        var columns = grid[0].Length;
        var distances = new int[rows, columns];

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                distances[row, column] = int.MaxValue;
            }
        }

        distances[0, 0] = 0;
        var deque = new LinkedList<(int row, int column, int obstacles)>();
        deque.AddFirst((0, 0, 0));
        int[] directions = [-1, 0, 1, 0, -1];

        while (deque.Count > 0)
        {
            var (row, column, obstacles) = deque.First!.Value;
            deque.RemoveFirst();

            if (obstacles != distances[row, column])
            {
                continue;
            }

            if (row == rows - 1 && column == columns - 1)
            {
                return obstacles;
            }

            for (var direction = 0; direction < 4; direction++)
            {
                var nextRow = row + directions[direction];
                var nextColumn = column + directions[direction + 1];

                if (nextRow < 0 || nextRow >= rows || nextColumn < 0 || nextColumn >= columns)
                {
                    continue;
                }

                var nextObstacles = obstacles + grid[nextRow][nextColumn];

                if (nextObstacles >= distances[nextRow, nextColumn])
                {
                    continue;
                }

                distances[nextRow, nextColumn] = nextObstacles;

                if (grid[nextRow][nextColumn] == 0)
                {
                    deque.AddFirst((nextRow, nextColumn, nextObstacles));
                }
                else
                {
                    deque.AddLast((nextRow, nextColumn, nextObstacles));
                }
            }
        }

        return distances[rows - 1, columns - 1];
    }
}
