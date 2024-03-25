namespace LeetCode.Solutions;

public class Solution52
{
    /// <summary>
    /// 52. N-Queens II - Hard
    /// <a href="https://leetcode.com/problems/n-queens">See the problem</a>
    /// </summary>
    public int TotalNQueens(int n)
    {
        var result = 0;
        var board = new char[n][];
        
        for (var i = 0; i < n; i++)
        {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }
        
        SolveNQueens(ref result, board, 0);
        return result;
    }
    
    private void SolveNQueens(ref int result, char[][] board, int row)
    {
        if (row == board.Length)
        {
            result++;
            return;
        }
        
        for (var col = 0; col < board.Length; col++)
        {
            if (IsValid(board, row, col))
            {
                board[row][col] = 'Q';
                SolveNQueens(ref result, board, row + 1);
                board[row][col] = '.';
            }
        }
    }
    
    private bool IsValid(char[][] board, int row, int col)
    {
        // Check the column
        for (var i = 0; i < row; i++)
        {
            if (board[i][col] == 'Q')
            {
                return false;
            }
        }
        
        // Check the left diagonal
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i][j] == 'Q')
            {
                return false;
            }
        }
        
        // Check the right diagonal
        for (int i = row - 1, j = col + 1; i >= 0 && j < board.Length; i--, j++)
        {
            if (board[i][j] == 'Q')
            {
                return false;
            }
        }
        
        return true;
    }
}
