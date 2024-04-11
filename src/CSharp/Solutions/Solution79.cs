namespace LeetCode.Solutions;

public class Solution79
{
    /// <summary>
    /// 79. Word Search - Medium
    /// <a href="https://leetcode.com/problems/word-search">See the problem</a>
    /// </summary>
    public bool Exist(char[][] board, string word)
    {
        var rows = board.Length;
        var cols = board[0].Length;
        var visited = new bool[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (board[i][j] == word[0] && Backtrack(i, j, 0))
                {
                    return true;
                }
            }
        }

        return false;

        bool Backtrack(int i, int j, int index)
        {
            if (index == word.Length)
            {
                return true;
            }

            if (i < 0 || i >= rows || j < 0 || j >= cols || visited[i, j] || board[i][j] != word[index])
            {
                return false;
            }

            visited[i, j] = true;

            if (Backtrack(i + 1, j, index + 1) ||
                Backtrack(i - 1, j, index + 1) ||
                Backtrack(i, j + 1, index + 1) ||
                Backtrack(i, j - 1, index + 1))
            {
                return true;
            }

            visited[i, j] = false;

            return false;
        }
    }
}
