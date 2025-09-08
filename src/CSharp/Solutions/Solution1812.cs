using System.Text;

namespace LeetCode.Solutions;

public class Solution1812
{
    /// <summary>
    /// 1812. Determine Color of a Chessboard Square - Easy
    /// <a href="https://leetcode.com/determine-color-of-a-chessboard-square">See the problem</a>
    /// </summary>
    public bool SquareIsWhite(string coordinates)
    {
        char col = coordinates[0];
        char row = coordinates[1];
        return (col - 'a') % 2 != (row - '1') % 2;
    }
}

