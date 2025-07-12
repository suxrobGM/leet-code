using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1620
{
    /// <summary>
    /// 1620. Coordinate With Maximum Network Quality - Medium
    /// <a href="https://leetcode.com/problems/coordinate-with-maximum-network-quality">See the problem</a>
    /// </summary>
    public int[] BestCoordinate(int[][] towers, int radius)
    {
        int maxQuality = 0;
        int[] bestCoordinate = new int[2];

        for (int x = 0; x <= 50; x++)
        {
            for (int y = 0; y <= 50; y++)
            {
                int totalQuality = 0;

                foreach (var tower in towers)
                {
                    int tx = tower[0], ty = tower[1], quality = tower[2];
                    double distance = Math.Sqrt((tx - x) * (tx - x) + (ty - y) * (ty - y));

                    if (distance <= radius)
                    {
                        totalQuality += (int)(quality / (1 + distance));
                    }
                }

                if (totalQuality > maxQuality)
                {
                    maxQuality = totalQuality;
                    bestCoordinate[0] = x;
                    bestCoordinate[1] = y;
                }
            }
        }

        return bestCoordinate;
    }
}
