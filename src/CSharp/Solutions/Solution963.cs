using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution963
{
    /// <summary>
    /// 963. Minimum Area Rectangle II - Medium
    /// <a href="https://leetcode.com/problems/minimum-area-rectangle-ii">See the problem</a>
    /// </summary>
    public double MinAreaFreeRect(int[][] points)
    {
        int n = points.Length;
        if (n < 4) return 0.0;  // Cannot form a rectangle with fewer than 4 points

        // Dictionary: (xSum, ySum) -> list of (i, j) pairs
        var dict = new Dictionary<(long, long), List<(int, int)>>();

        // Populate the dictionary with all pairs
        for (int i = 0; i < n; i++) {
            long x1 = points[i][0];
            long y1 = points[i][1];
            for (int j = i + 1; j < n; j++) {
                long x2 = points[j][0];
                long y2 = points[j][1];
                
                // Key is just the sum of coordinates (to avoid floating issues).
                long sumX = x1 + x2;
                long sumY = y1 + y2;

                var key = (sumX, sumY);
                if (!dict.ContainsKey(key)) {
                    dict[key] = new List<(int, int)>();
                }
                dict[key].Add((i, j));
            }
        }

        double minArea = double.MaxValue;
        bool foundRectangle = false;

        // For each sum key, examine all distinct pairs that share it
        foreach (var kvp in dict) {
            var pairList = kvp.Value;
            // If fewer than 2 pairs, cannot form a parallelogram
            if (pairList.Count < 2) continue;

            // Check every combination of two pairs
            for (int idx1 = 0; idx1 < pairList.Count; idx1++) {
                var (i, j) = pairList[idx1];
                // Coordinates of points i and j
                long xi = points[i][0], yi = points[i][1];
                long xj = points[j][0], yj = points[j][1];

                for (int idx2 = idx1 + 1; idx2 < pairList.Count; idx2++) {
                    var (k, l) = pairList[idx2];

                    // Ensure all indices are distinct
                    if (i == k || i == l || j == k || j == l) {
                        continue;
                    }

                    // Coordinates of points k and l
                    long xk = points[k][0], yk = points[k][1];
                    long xl = points[l][0], yl = points[l][1];

                    // We'll treat:
                    //   A = (xi, yi)
                    //   B = (xk, yk)   // 2nd pair's first point
                    //   D = (xl, yl)   // 2nd pair's second point
                    // so we want AB dot AD = 0 for a rectangle

                    long ABx = xk - xi;
                    long ABy = yk - yi;
                    long ADx = xl - xi;
                    long ADy = yl - yi;

                    long dot = ABx * ADx + ABy * ADy; 
                    if (dot == 0) {
                        // It's a rectangle
                        // Area = |AB x AD|
                        long cross = ABx * ADy - ABy * ADx;
                        double area = Math.Abs((double) cross);
                        if (area < minArea && area > 0) {
                            minArea = area;
                            foundRectangle = true;
                        }
                    }
                }
            }
        }

        return foundRectangle ? minArea : 0.0;
    }
}
