using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution957
{
    /// <summary>
    /// 957. Prison Cells After N Days - Medium
    /// <a href="https://leetcode.com/problems/prison-cells-after-n-days">See the problem</a>
    /// </summary>
    public int[] PrisonAfterNDays(int[] cells, int n)
    {
        var seen = new Dictionary<string, int>();
        
        for (int i = 0; i < n; i++)
        {
            var nextDayCells = NextDay(cells);

            var key = string.Join(",", nextDayCells);

            if (!seen.ContainsKey(key))
            {
                seen[key] = i;
                cells = nextDayCells;
            }
            else
            {
                var loopLength = i - seen[key];
                var remainingDays = (n - i) % loopLength;
                return PrisonAfterNDays(cells, remainingDays);
            }
        }

        return cells;
    }

    private int[] NextDay(int[] cells)
    {
        var next = new int[cells.Length];

        for (int i = 1; i < cells.Length - 1; i++)
        {
            next[i] = cells[i - 1] == cells[i + 1] ? 1 : 0;
        }

        return next;
    }
}
