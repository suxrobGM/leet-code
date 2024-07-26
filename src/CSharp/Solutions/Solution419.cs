using System.Text;

namespace LeetCode.Solutions;

public class Solution419
{
    /// <summary>
    /// 419. Battleships in a Board - Medium
    /// <a href="https://leetcode.com/problems/battleships-in-a-board">See the problem</a>
    /// </summary>
    public int CountBattleships(char[][] board)
    {
        var rows = board.Length;
        var cols = board[0].Length;
        var count = 0;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (board[i][j] == 'X' && (i == 0 || board[i - 1][j] == '.') && (j == 0 || board[i][j - 1] == '.'))
                {
                    count++;
                }
            }
        }

        return count;
    }
}
