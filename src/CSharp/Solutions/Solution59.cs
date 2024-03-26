namespace LeetCode.Solutions;

public class Solution59
{
    /// <summary>
    /// 59. Spiral Matrix II - Medium
    /// <a href="https://leetcode.com/problems/length-of-last-word/">See the problem</a>
    /// </summary>
    public int[][] GenerateMatrix(int n)
    {
        var matrix = new int[n][];
        
        for (var i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }
        
        var top = 0;
        var bottom = n - 1;
        var left = 0;
        var right = n - 1;
        var num = 1;
        
        while (top <= bottom && left <= right)
        {
            for (var i = left; i <= right; i++)
            {
                matrix[top][i] = num++;
            }
            
            top++;
            
            for (var i = top; i <= bottom; i++)
            {
                matrix[i][right] = num++;
            }
            
            right--;
            
            if (top <= bottom)
            {
                for (var i = right; i >= left; i--)
                {
                    matrix[bottom][i] = num++;
                }
                
                bottom--;
            }
            
            if (left <= right)
            {
                for (var i = bottom; i >= top; i--)
                {
                    matrix[i][left] = num++;
                }
                
                left++;
            }
        }
        
        return matrix;
    }
}
