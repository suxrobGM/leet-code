using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution661
{
    /// <summary>
    /// 661. Image Smoother - Easy
    /// <a href="https://leetcode.com/problems/image-smoother">See the problem</a>
    /// </summary>
    public int[][] ImageSmoother(int[][] img)
    {
        var rows = img.Length;
        var cols = img[0].Length;
        var result = new int[rows][];

        for (var i = 0; i < rows; i++)
        {
            result[i] = new int[cols];
            for (var j = 0; j < cols; j++)
            {
                var sum = 0;
                var count = 0;

                for (var r = i - 1; r <= i + 1; r++)
                {
                    for (var c = j - 1; c <= j + 1; c++)
                    {
                        if (r >= 0 && r < rows && c >= 0 && c < cols)
                        {
                            sum += img[r][c];
                            count++;
                        }
                    }
                }

                result[i][j] = sum / count;
            }
        }

        return result;
    }
}
