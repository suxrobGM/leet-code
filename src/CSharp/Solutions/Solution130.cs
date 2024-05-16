using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution130
{
    /// <summary>
    /// 130. Surrounded Regions - Medium
    /// <a href="https://leetcode.com/problems/surrounded-regions">See the problem</a>
    /// </summary>
    public void Solve(char[][] board)
    {
        if (board.Length == 0 || board[0].Length == 0)
        {
            return;
        }
        
        var rows = board.Length;
        var cols = board[0].Length;
        
        for (var i = 0; i < rows; i++)
        {
            if (board[i][0] == 'O')
            {
                DFS(board, i, 0);
            }
            
            if (board[i][cols - 1] == 'O')
            {
                DFS(board, i, cols - 1);
            }
        }
        
        for (var j = 0; j < cols; j++)
        {
            if (board[0][j] == 'O')
            {
                DFS(board, 0, j);
            }
            
            if (board[rows - 1][j] == 'O')
            {
                DFS(board, rows - 1, j);
            }
        }
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (board[i][j] == 'O')
                {
                    board[i][j] = 'X';
                }
                else if (board[i][j] == '1')
                {
                    board[i][j] = 'O';
                }
            }
        }
    }
    
    private void DFS(char[][] board, int i, int j)
    {
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != 'O')
        {
            return;
        }
        
        board[i][j] = '1';
        
        DFS(board, i - 1, j);
        DFS(board, i + 1, j);
        DFS(board, i, j - 1);
        DFS(board, i, j + 1);
    }
}
