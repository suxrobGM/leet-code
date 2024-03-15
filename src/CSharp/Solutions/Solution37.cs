namespace LeetCode.Solutions;

public class Solution37
{
    /// <summary>
    /// 37. Sudoku Solver - Hard
    /// <a href="https://leetcode.com/problems/sudoku-solver">See the problem</a>
    /// </summary>
    public void SolveSudoku(char[][] board)
    {
        Solve(board);
    }

    private bool Solve(char[][] board)
    {
        for (var row = 0; row < board.Length; row++)
        {
            for (var col = 0; col < board[0].Length; col++)
            {
                // Skip filled cells
                if (board[row][col] != '.')
                {
                    continue;
                }

                for (var num = '1'; num <= '9'; num++)
                {
                    if (!IsValid(board, row, col, num))
                    {
                        continue;
                    }
                    
                    board[row][col] = num;

                    if (Solve(board))
                    {
                        return true; // If it's the solution, return true
                    }

                    board[row][col] = '.'; // Otherwise, backtrack
                }

                // If no valid number can be placed in this cell, return false
                return false;
            }
        }

        // If all cells are filled correctly, we've found a solution
        return true;
    }

    private bool IsValid(char[][] board, int row, int col, char num)
    {
        // Check the row and column
        for (var i = 0; i < 9; i++)
        {
            if (board[row][i] == num || board[i][col] == num)
            {
                return false;
            }
        }

        // Check the 3x3 sub-grid
        var startRow = row / 3 * 3;
        var startCol = col / 3 * 3;
        
        for (var i = startRow; i < startRow + 3; i++)
        {
            for (var j = startCol; j < startCol + 3; j++)
            {
                if (board[i][j] == num)
                {
                    return false;
                }
            }
        }

        return true; // The number can be placed in this cell
    }
}
