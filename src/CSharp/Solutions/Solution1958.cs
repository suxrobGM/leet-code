using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1958
{
    /// <summary>
    /// 1958. Check if Move is Legal - Medium
    /// <a href="https://leetcode.com/problems/check-if-move-is-legal">See the problem</a>
    /// </summary>
    public bool CheckMove(char[][] board, int rMove, int cMove, char color)
    {
        int[][] directions =
        [
            [-1, -1], [-1, 0], [-1, 1],
            [0, -1], [0, 1],
            [1, -1], [1, 0], [1, 1]
        ];

        foreach (var dir in directions)
        {
            int x = rMove + dir[0];
            int y = cMove + dir[1];
            bool hasOppositeColor = false;

            while (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                if (board[x][y] == '.')
                {
                    break;
                }
                else if (board[x][y] != color)
                {
                    hasOppositeColor = true;
                }
                else
                {
                    if (hasOppositeColor)
                    {
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }

                x += dir[0];
                y += dir[1];
            }
        }

        return false;
    }
}
