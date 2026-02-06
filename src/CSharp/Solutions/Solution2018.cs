namespace LeetCode.Solutions;

public class Solution2018
{
    /// <summary>
    /// 2018. Check if Word Can Be Placed In Crossword - Medium
    /// <a href="https://leetcode.com/problems/check-if-word-can-be-placed-in-crossword">See the problem</a>
    /// </summary>
    public bool PlaceWordInCrossword(char[][] board, string word)
    {
        int rows = board.Length;
        int cols = board[0].Length;
        int len = word.Length;

        bool Matches(string segment, string target)
        {
            for (int i = 0; i < segment.Length; i++)
            {
                if (segment[i] != ' ' && segment[i] != target[i])
                    return false;
            }

            return true;
        }

        string reversed = new([.. word.Reverse()]);

        // Check horizontal segments
        for (int r = 0; r < rows; r++)
        {
            int c = 0;
            while (c < cols)
            {
                if (board[r][c] == '#') { c++; continue; }

                int start = c;
                while (c < cols && board[r][c] != '#') c++;

                if (c - start == len)
                {
                    string segment = new string(board[r], start, len);
                    if (Matches(segment, word) || Matches(segment, reversed))
                        return true;
                }
            }
        }

        // Check vertical segments
        for (int c = 0; c < cols; c++)
        {
            int r = 0;
            while (r < rows)
            {
                if (board[r][c] == '#') { r++; continue; }

                int start = r;
                while (r < rows && board[r][c] != '#') r++;

                if (r - start == len)
                {
                    char[] chars = new char[len];
                    for (int k = 0; k < len; k++)
                        chars[k] = board[start + k][c];

                    string segment = new(chars);
                    if (Matches(segment, word) || Matches(segment, reversed))
                        return true;
                }
            }
        }

        return false;
    }
}
