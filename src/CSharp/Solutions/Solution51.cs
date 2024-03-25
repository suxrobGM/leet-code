namespace LeetCode.Solutions;

public class Solution51
{
    /// <summary>
    /// 51. N-Queens - Hard
    /// <a href="https://leetcode.com/problems/n-queens">See the problem</a>
    /// </summary>
    public IList<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>();
        var board = new char[n][];
        
        for (var i = 0; i < n; i++)
        {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }
        
        SolveNQueens(result, board, 0);
        return result;
    }
    
    private void SolveNQueens(IList<IList<string>> result, char[][] board, int row)
    {
        if (row == board.Length)
        {
            result.Add(board.Select(row => new string(row)).ToList());
            return;
        }
        
        for (var col = 0; col < board.Length; col++)
        {
            if (IsValid(board, row, col))
            {
                board[row][col] = 'Q';
                SolveNQueens(result, board, row + 1);
                board[row][col] = '.';
            }
        }
    }
    
    private bool IsValid(char[][] board, int row, int col)
    {
        for (var i = 0; i < row; i++)
        {
            if (board[i][col] == 'Q')
            {
                return false;
            }
        }
        
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i][j] == 'Q')
            {
                return false;
            }
        }
        
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
