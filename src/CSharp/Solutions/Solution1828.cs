using System.Text;

namespace LeetCode.Solutions;

public class Solution1828
{
    /// <summary>
    /// 1828. Queries on Number of Points Inside a Circle - Medium
    /// <a href="https://leetcode.com/problems/queries-on-number-of-points-inside-a-circle">See the problem</a>
    /// </summary>
    public int[] CountPoints(int[][] points, int[][] queries)
    {
        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int count = 0;
            int xCenter = queries[i][0];
            int yCenter = queries[i][1];
            int radius = queries[i][2];
            int radiusSquared = radius * radius;

            foreach (var point in points)
            {
                int x = point[0];
                int y = point[1];
                int dx = x - xCenter;
                int dy = y - yCenter;
                if (dx * dx + dy * dy <= radiusSquared)
                {
                    count++;
                }
            }
            result[i] = count;
        }
        return result;
    }
}
