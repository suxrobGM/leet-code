using System.Text;

namespace LeetCode.Solutions;

public class Solution1779
{
    /// <summary>
    /// 1779. Find Nearest Point That Has the Same X or Y Coordinate - Easy
    /// <a href="https://leetcode.com/problems/find-nearest-point-that-has-the-same-x-or-y-coordinate">See the problem</a>
    /// </summary>
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        int minDistance = int.MaxValue;
        int resultIndex = -1;

        for (int i = 0; i < points.Length; i++)
        {
            int[] point = points[i];
            if (point[0] == x || point[1] == y)
            {
                int distance = Math.Abs(point[0] - x) + Math.Abs(point[1] - y);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    resultIndex = i;
                }
            }
        }

        return resultIndex;
    }
}
