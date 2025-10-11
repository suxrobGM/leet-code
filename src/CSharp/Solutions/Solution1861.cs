using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1861
{
    /// <summary>
    /// 1861. Rotating the Box - Medium
    /// <a href="https://leetcode.com/problems/rotating-the-box">See the problem</a>
    /// </summary>
    public char[][] RotateTheBox(char[][] boxGrid)
    {
        int rows = boxGrid.Length;
        int cols = boxGrid[0].Length;

        char[][] rotatedBox = new char[cols][];

        for (int c = 0; c < cols; c++)
        {
            rotatedBox[c] = new char[rows];
            for (int r = 0; r < rows; r++)
            {
                rotatedBox[c][r] = boxGrid[rows - 1 - r][c];
            }
        }

        for (int r = 0; r < cols; r++)
        {
            int emptySpot = rows - 1;
            for (int c = rows - 1; c >= 0; c--)
            {
                if (rotatedBox[r][c] == '*')
                {
                    emptySpot = c - 1;
                }
                else if (rotatedBox[r][c] == '#')
                {
                    if (emptySpot != c)
                    {
                        rotatedBox[r][emptySpot] = '#';
                        rotatedBox[r][c] = '.';
                    }
                    emptySpot--;
                }
            }
        }

        return rotatedBox;
    }
}
