using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution782
{
    /// <summary>
    /// 782. Transform to Chessboard - Hard
    /// <a href="https://leetcode.com/problems/transform-to-chessboard">See the problem</a>
    /// </summary>
    public int MovesToChessboard(int[][] board)
    {
        int n = board.Length;
        int rowSum = 0, colSum = 0, rowSwap = 0, colSwap = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if ((board[0][0] ^ board[i][0] ^ board[0][j] ^ board[i][j]) == 1)
                {
                    return -1;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            rowSum += board[0][i];
            colSum += board[i][0];
            rowSwap += board[i][0] == i % 2 ? 1 : 0;
            colSwap += board[0][i] == i % 2 ? 1 : 0;
        }

        if (rowSum < n / 2 || rowSum > (n + 1) / 2) return -1;
        if (colSum < n / 2 || colSum > (n + 1) / 2) return -1;

        if (n % 2 == 1)
        {
            if (colSwap % 2 == 1) colSwap = n - colSwap;
            if (rowSwap % 2 == 1) rowSwap = n - rowSwap;
        }
        else
        {
            colSwap = Math.Min(n - colSwap, colSwap);
            rowSwap = Math.Min(n - rowSwap, rowSwap);
        }

        return (colSwap + rowSwap) / 2;
    }
}
