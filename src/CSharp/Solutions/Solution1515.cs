using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1515
{
    /// <summary>
    /// 1515. Best Position for a Service Centre - Hard
    /// <a href="https://leetcode.com/problems/best-position-for-a-service-centre">See the problem</a>
    /// </summary>
    public double GetMinDistSum(int[][] positions)
    {
        const double eps = 1e-7;
        const int maxIter = 1000;

        int n = positions.Length;
        double x = 0, y = 0;

        // Start from centroid
        foreach (var pos in positions)
        {
            x += pos[0];
            y += pos[1];
        }
        x /= n;
        y /= n;

        for (int iter = 0; iter < maxIter; iter++)
        {
            double numX = 0, numY = 0, denom = 0;
            bool hasZeroDist = false;

            for (int i = 0; i < n; i++)
            {
                double dx = x - positions[i][0];
                double dy = y - positions[i][1];
                double dist = Math.Sqrt(dx * dx + dy * dy);

                if (dist < eps)
                {
                    hasZeroDist = true;
                    break;
                }

                double w = 1 / dist;
                numX += positions[i][0] * w;
                numY += positions[i][1] * w;
                denom += w;
            }

            if (hasZeroDist) break;

            double newX = numX / denom;
            double newY = numY / denom;

            if (Math.Abs(newX - x) < eps && Math.Abs(newY - y) < eps)
                break;

            x = newX;
            y = newY;
        }

        double result = 0;
        foreach (var pos in positions)
        {
            double dx = x - pos[0];
            double dy = y - pos[1];
            result += Math.Sqrt(dx * dx + dy * dy);
        }

        return result;
    }
}
