namespace LeetCode.Solutions;

public class Solution36
{
    /// <summary>
    /// 36. Valid Sudoku
    /// <a href="https://leetcode.com/problems/valid-sudoku">See the problem</a>
    /// </summary>
    public bool IsValidSudoku(char[][] board)
    {
        var rows = new HashSet<char>[9];
        var cols = new HashSet<char>[9];
        var boxes = new HashSet<char>[9];

        for (var i = 0; i < 9; i++)
        {
            rows[i] = [];
            cols[i] = [];
            boxes[i] = [];
        }

        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                var num = board[i][j];

                if (num == '.')
                {
                    continue;
                }

                var boxIndex = 3 * (i / 3) + j / 3;
                if (rows[i].Contains(num) || cols[j].Contains(num) || boxes[boxIndex].Contains(num))
                {
                    return false;
                }

                rows[i].Add(num);
                cols[j].Add(num);
                boxes[boxIndex].Add(num);
            }
        }

        return true;
    }
}
