using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1453
{
    /// <summary>
    /// 1453. Maximum Number of Darts Inside of a Circular Dartboard - Hard
    /// <a href="https://leetcode.com/problems/maximum-number-of-darts-inside-of-a-circular-dartboard">See the problem</a>
    /// </summary>
    public int NumPoints(int[][] darts, int r)
    {
        int n = darts.Length;
        int result = 1;
        double radius = r;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var centers = GetCircleCenters(darts[i], darts[j], radius);
                foreach (var center in centers)
                {
                    int count = 0;
                    foreach (var dart in darts)
                    {
                        double dx = dart[0] - center.Item1;
                        double dy = dart[1] - center.Item2;
                        if (dx * dx + dy * dy <= radius * radius + 1e-7) // small tolerance
                            count++;
                    }
                    result = Math.Max(result, count);
                }
            }
        }

        return result;
    }

    private List<(double, double)> GetCircleCenters(int[] p1, int[] p2, double r)
    {
        var res = new List<(double, double)>();

        double x1 = p1[0], y1 = p1[1];
        double x2 = p2[0], y2 = p2[1];
        double dx = x2 - x1;
        double dy = y2 - y1;
        double distSq = dx * dx + dy * dy;
        double d = Math.Sqrt(distSq);

        if (d > 2 * r) return res; // too far apart

        double midX = (x1 + x2) / 2.0;
        double midY = (y1 + y2) / 2.0;
        double h = Math.Sqrt(r * r - (d / 2) * (d / 2));

        // (dx, dy) perpendicular vector
        double offsetX = -dy * h / d;
        double offsetY = dx * h / d;

        res.Add((midX + offsetX, midY + offsetY));
        res.Add((midX - offsetX, midY - offsetY));

        return res;
    }
}
