namespace LeetCode.Solutions;

public class Solution289
{
    /// <summary>
    /// 289. Game of Life
    /// <a href="https://leetcode.com/problems/game-of-life">See the problem</a>
    /// </summary>
    public void GameOfLife(int[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;

        // Iterate through the board and update the state of each cell
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var liveNeighbors = CountLiveNeighbors(board, i, j);

                if ((board[i][j] & 1) == 1)
                {
                    if (liveNeighbors is 2 or 3)
                    {
                        board[i][j] |= 2;
                    }
                }
                else
                {
                    if (liveNeighbors == 3)
                    {
                        board[i][j] |= 2;
                    }
                }
            }
        }

        // Update the board
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                board[i][j] >>= 1;
            }
        }
    }
    
    private int CountLiveNeighbors(int[][] board, int i, int j)
    {
        var m = board.Length;
        var n = board[0].Length;
        var count = 0;
        var directions = new[] // 8 directions
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, -1),
            (0, 1),
            (1, -1),
            (1, 0),
            (1, 1)
        };

        foreach (var (dx, dy) in directions)
        {
            var x = i + dx;
            var y = j + dy;

            // Check if the cell is valid and is alive
            if (x >= 0 && x < m && y >= 0 && y < n && (board[x][y] & 1) == 1)
            {
                count++;
            }
        }

        return count;
    }
}
