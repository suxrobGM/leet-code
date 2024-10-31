using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution733
{
    /// <summary>
    /// 733. Flood Fill - Easy
    /// <a href="https://leetcode.com/problems/flood-fill">See the problem</a>
    /// </summary>

    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var rows = image.Length;
        var cols = image[0].Length;
        var startColor = image[sr][sc];

        if (startColor == color)
        {
            return image;
        }

        FloodFill(image, sr, sc, rows, cols, startColor, color);
        return image;
    }

    private void FloodFill(int[][] image, int sr, int sc, int rows, int cols, int startColor, int color)
    {
        if (sr < 0 || sr >= rows || sc < 0 || sc >= cols || image[sr][sc] != startColor)
        {
            return;
        }

        image[sr][sc] = color;

        FloodFill(image, sr + 1, sc, rows, cols, startColor, color);
        FloodFill(image, sr - 1, sc, rows, cols, startColor, color);
        FloodFill(image, sr, sc + 1, rows, cols, startColor, color);
        FloodFill(image, sr, sc - 1, rows, cols, startColor, color);
    }
}
