
namespace LeetCode.Solutions;

public class Solution794
{
    /// <summary>
    /// 794. Valid Tic-Tac-Toe State - Medium
    /// <a href="https://leetcode.com/problems/valid-tic-tac-toe-state">See the problem</a>
    /// </summary>
    public bool ValidTicTacToe(string[] board)
    {
        var xCount = 0;
        var oCount = 0;

        foreach (var row in board)
        {
            foreach (var cell in row)
            {
                if (cell == 'X')
                {
                    xCount++;
                }
                else if (cell == 'O')
                {
                    oCount++;
                }
            }
        }

        if (oCount > xCount || xCount - oCount > 1)
        {
            return false;
        }

        if (IsWin(board, 'X') && xCount - oCount != 1)
        {
            return false;
        }

        if (IsWin(board, 'O') && xCount != oCount)
        {
            return false;
        }

        return true;
    }

    private bool IsWin(string[] board, char player)
    {
        for (var i = 0; i < 3; i++)
        {
            if (board[i][0] == player && board[i][1] == player && board[i][2] == player)
            {
                return true;
            }

            if (board[0][i] == player && board[1][i] == player && board[2][i] == player)
            {
                return true;
            }
        }

        if (board[0][0] == player && board[1][1] == player && board[2][2] == player)
        {
            return true;
        }

        if (board[0][2] == player && board[1][1] == player && board[2][0] == player)
        {
            return true;
        }

        return false;
    }
}
