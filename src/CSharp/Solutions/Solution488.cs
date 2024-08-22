namespace LeetCode.Solutions;

public class Solution488
{
    /// <summary>
    /// 488. Zuma Game - Hard
    /// <a href="https://leetcode.com/problems/zuma-game">See the problem</a>
    /// </summary>
    public int FindMinStep(string board, string hand)
    {

        Dictionary<string, int> memo = new Dictionary<string, int>();
        int result = Helper(board, hand, memo);
        return result == int.MaxValue ? -1 : result;
    }

    private int Helper(string board, string hand, Dictionary<string, int> memo)
    {
        if (board.Length == 0) return 0;
        if (hand.Length == 0) return int.MaxValue;
        string key = board + " " + hand;
        if (memo.ContainsKey(key)) return memo[key];

        int minSteps = int.MaxValue;

        for (int i = 0; i <= board.Length; i++)
        {
            for (int j = 0; j < hand.Length; j++)
            {
                if (i > 0 && board[i - 1] == hand[j]) continue; // avoid duplicates
                string newBoard = InsertAndRemove(board, hand[j], i);
                if (newBoard.Length < board.Length)
                {
                    string newHand = hand.Remove(j, 1);
                    int nextSteps = Helper(newBoard, newHand, memo);
                    if (nextSteps != int.MaxValue)
                    {
                        minSteps = Math.Min(minSteps, 1 + nextSteps);
                    }
                }
            }
        }

        memo[key] = minSteps;
        return minSteps;
    }

    private string InsertAndRemove(string board, char ball, int pos)
    {
        board = board.Insert(pos, ball.ToString());
        return RemoveConsecutive(board);
    }

    private string RemoveConsecutive(string board)
    {
        int i = 0;
        while (i < board.Length)
        {
            int j = i;
            while (j < board.Length && board[j] == board[i]) j++;
            if (j - i >= 3)
            {
                board = board.Remove(i, j - i);
                i = 0; // reset to start checking from the beginning
            }
            else
            {
                i++;
            }
        }
        return board;
    }
}
