namespace LeetCode.Solutions;

public class Solution54
{
    /// <summary>
    /// 54. Spiral Matrix
    /// <a href="https://leetcode.com/problems/spiral-matrix">See the problem</a>
    /// </summary>
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();
        var top = 0;
        var bottom = matrix.Length - 1;
        var left = 0;
        var right = matrix[0].Length - 1;

        while (top <= bottom && left <= right)
        {
            // Traverse Right
            for (var i = left; i <= right; i++)
            {
                result.Add(matrix[top][i]);
            }

            top++;

            // Traverse Down
            for (var i = top; i <= bottom; i++)
            {
                result.Add(matrix[i][right]);
            }

            right--;

            // Traverse Left (check if top <= bottom to avoid double counting)
            if (top <= bottom)
            {
                for (var i = right; i >= left; i--)
                {
                    result.Add(matrix[bottom][i]);
                }
            }

            bottom--;

            // Traverse Up (check if left <= right to avoid double counting)
            if (left <= right)
            {
                for (var i = bottom; i >= top; i--)
                {
                    result.Add(matrix[i][left]);
                }
            }

            left++;
        }

        return result;
    }
}
