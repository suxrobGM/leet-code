namespace LeetCode.Solutions;

public class Solution2280
{
    /// <summary>
    /// 2280. Minimum Lines to Represent a Line Chart - Medium
    /// <a href="https://leetcode.com/problems/minimum-lines-to-represent-a-line-chart">See the problem</a>
    /// </summary>
    public int MinimumLines(int[][] stockPrices)
    {
        if (stockPrices.Length < 2)
        {
            return 0;
        }

        Array.Sort(stockPrices, (a, b) => a[0].CompareTo(b[0]));

        var lines = 1;

        for (var i = 2; i < stockPrices.Length; i++)
        {
            long x1 = stockPrices[i - 2][0], y1 = stockPrices[i - 2][1];
            long x2 = stockPrices[i - 1][0], y2 = stockPrices[i - 1][1];
            long x3 = stockPrices[i][0], y3 = stockPrices[i][1];

            // The slopes differ when the cross product of the two segments is not zero.
            if ((y2 - y1) * (x3 - x2) != (y3 - y2) * (x2 - x1))
            {
                lines++;
            }
        }

        return lines;
    }
}
