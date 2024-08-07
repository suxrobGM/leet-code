using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution447
{
    /// <summary>
    /// 447. Number of Boomerangs - Medium
    /// <a href="https://leetcode.com/problems/number-of-boomerangs">See the problem</a>
    /// </summary>
    public int NumberOfBoomerangs(int[][] points)
    {
        var result = 0;

        for (var i = 0; i < points.Length; i++)
        {
            var map = new Dictionary<int, int>();

            for (var j = 0; j < points.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var distance = GetDistance(points[i], points[j]);

                if (map.ContainsKey(distance))
                {
                    result += map[distance] * 2;
                    map[distance]++;
                }
                else
                {
                    map[distance] = 1;
                }
            }
        }

        return result;
    }

    private int GetDistance(int[] p1, int[] p2)
    {
        var dx = p1[0] - p2[0];
        var dy = p1[1] - p2[1];

        return dx * dx + dy * dy;
    }
}
