namespace LeetCode.Solutions;

public class Solution1975
{
    /// <summary>
    /// 1975. Maximum Matrix Sum - Medium
    /// <a href="https://leetcode.com/problems/maximum-matrix-sum">See the problem</a>
    /// </summary>
    public long MaxMatrixSum(int[][] matrix)
    {
        long totalSum = 0;
        int negativeCount = 0;
        int minAbsValue = int.MaxValue;

        foreach (var row in matrix)
        {
            foreach (var value in row)
            {
                totalSum += Math.Abs(value);
                if (value < 0)
                {
                    negativeCount++;
                }
                minAbsValue = Math.Min(minAbsValue, Math.Abs(value));
            }
        }

        // If there's an odd number of negative values, we need to subtract twice the smallest absolute value
        if (negativeCount % 2 != 0)
        {
            totalSum -= 2 * minAbsValue;
        }

        return totalSum;
    }
}
