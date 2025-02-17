using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution999
{
    /// <summary>
    /// 999. Available Captures for Rook - Easy
    /// <a href="https://leetcode.com/problems/available-captures-for-rook">See the problem</a>
    /// </summary>
    public int NumRookCaptures(char[][] board)
    {
        var rookRow = 0;
        var rookCol = 0;
        var result = 0;

        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (board[i][j] == 'R')
                {
                    rookRow = i;
                    rookCol = j;
                    break;
                }
            }
        }

        for (var i = rookRow - 1; i >= 0; i--)
        {
            if (board[i][rookCol] == 'B')
            {
                break;
            }

            if (board[i][rookCol] == 'p')
            {
                result++;
                break;
            }
        }

        for (var i = rookRow + 1; i < 8; i++)
        {
            if (board[i][rookCol] == 'B')
            {
                break;
            }

            if (board[i][rookCol] == 'p')
            {
                result++;
                break;
            }
        }

        for (var j = rookCol - 1; j >= 0; j--)
        {
            if (board[rookRow][j] == 'B')
            {
                break;
            }

            if (board[rookRow][j] == 'p')
            {
                result++;
                break;
            }
        }

        for (var j = rookCol + 1; j < 8; j++)
        {
            if (board[rookRow][j] == 'B')
            {
                break;
            }

            if (board[rookRow][j] == 'p')
            {
                result++;
                break;
            }
        }

        return result;
    }
}
