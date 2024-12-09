using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution885
{
    /// <summary>
    /// 885. Spiral Matrix III - Medium
    /// <a href="https://leetcode.com/problems/spiral-matrix-iii">See the problem</a>
    /// </summary>
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        var result = new List<int[]>();
        int r = rStart;
        int c = cStart;
        int step = 1;
        int steps = 1;
        int direction = 0;
        int[][] directions =
        [
            [0, 1],
            [1, 0],
            [0, -1],
            [-1, 0]
        ];

        while (result.Count < rows * cols)
        {
            for (int i = 0; i < steps; i++)
            {
                if (r >= 0 && r < rows && c >= 0 && c < cols)
                {
                    result.Add([r, c]);
                }

                r += directions[direction][0];
                c += directions[direction][1];
            }

            if (step % 2 == 0)
            {
                steps++;
            }

            direction = (direction + 1) % 4;
            step++;
        }

        return [.. result];
    }
}
