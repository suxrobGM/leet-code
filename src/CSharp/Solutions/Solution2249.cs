namespace LeetCode.Solutions;

public class Solution2249
{
    /// <summary>
    /// 2249. Count Lattice Points Inside a Circle - Medium
    /// <a href="https://leetcode.com/problems/count-lattice-points-inside-a-circle">See the problem</a>
    /// </summary>
    public int CountLatticePoints(int[][] circles)
    {
        // Centers and radii are bounded by 100, so every reachable lattice
        // point lies in [0, 200] on both axes and fits in a fixed grid
        var covered = new bool[201, 201];
        var count = 0;

        foreach (var circle in circles)
        {
            int cx = circle[0], cy = circle[1], r = circle[2];

            for (var x = cx - r; x <= cx + r; x++)
            {
                for (var y = cy - r; y <= cy + r; y++)
                {
                    var dx = x - cx;
                    var dy = y - cy;

                    if (dx * dx + dy * dy > r * r || covered[x, y])
                    {
                        continue;
                    }

                    covered[x, y] = true;
                    count++;
                }
            }
        }

        return count;
    }
}
