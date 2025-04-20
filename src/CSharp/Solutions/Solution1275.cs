using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1275
{
    /// <summary>
    /// 1275. Find Winner on a Tic Tac Toe Game - Easy
    /// <a href="https://leetcode.com/problems/find-winner-on-a-tic-tac-toe-game">See the problem</a>
    /// </summary>
    public string Tictactoe(int[][] moves)
    {
        // 0 => player A, 1 => player B
        var rows = new int[2, 3];
        var cols = new int[2, 3];
        var diag = new int[2];
        var anti = new int[2];

        for (int i = 0; i < moves.Length; ++i)
        {
            var player = i & 1;               // even index = A, odd = B
            var r = moves[i][0];
            var c = moves[i][1];

            if (++rows[player, r] == 3 ||
                ++cols[player, c] == 3 ||
                (r == c && ++diag[player] == 3) ||
                (r + c == 2 && ++anti[player] == 3))
            {
                return player == 0 ? "A" : "B";
            }
        }

        return moves.Length == 9 ? "Draw" : "Pending";
    }
}
