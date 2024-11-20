using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution832
{
    /// <summary>
    /// 832. Flipping an Image - Easy
    /// <a href="https://leetcode.com/problems/flipping-an-image">See the problem</a>
    /// </summary>
    public int[][] FlipAndInvertImage(int[][] image)
    {
        var n = image.Length;
        var result = new int[n][];

        for (var i = 0; i < n; i++)
        {
            var m = image[i].Length;
            result[i] = new int[m];

            for (var j = 0; j < m; j++)
            {
                result[i][m - j - 1] = image[i][j] ^ 1;
            }
        }

        return result;
    }
}
