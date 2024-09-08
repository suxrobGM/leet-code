using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution529
{
    /// <summary>
    /// 529. Minesweeper - Medium
    /// <a href="https://leetcode.com/problems/minesweeper">See the problem</a>
    /// </summary>
    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        var dx = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        var dy = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        var m = board.Length;
        var n = board[0].Length;

        var x = click[0];
        var y = click[1];

        if (board[x][y] == 'M')
        {
            board[x][y] = 'X';
        }
        else
        {
            Dfs(board, x, y, m, n, dx, dy);
        }

        return board;
    }

    private void Dfs(char[][] board, int x, int y, int m, int n, int[] dx, int[] dy)
    {
        if (x < 0 || x >= m || y < 0 || y >= n || board[x][y] != 'E')
        {
            return;
        }

        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];

            if (nx < 0 || nx >= m || ny < 0 || ny >= n)
            {
                continue;
            }

            if (board[nx][ny] == 'M')
            {
                count++;
            }
        }

        if (count > 0)
        {
            board[x][y] = (char)('0' + count);
        }
        else
        {
            board[x][y] = 'B';
            for (int i = 0; i < 8; i++)
            {
                Dfs(board, x + dx[i], y + dy[i], m, n, dx, dy);
            }
        }
    }
}
