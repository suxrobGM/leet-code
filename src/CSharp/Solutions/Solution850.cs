using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution850
{
    /// <summary>
    /// 850. Rectangle Area II - Hard
    /// <a href="https://leetcode.com/problems/rectangle-area-ii">See the problem</a>
    /// </summary>
    public int RectangleArea(int[][] rectangles)
    {
        const int MOD = 1_000_000_007;

        // Event list: (x, y1, y2, type)
        var events = new List<(int x, int y1, int y2, int type)>();
        foreach (var rect in rectangles)
        {
            events.Add((rect[0], rect[1], rect[3], 1)); // Start of a rectangle
            events.Add((rect[2], rect[1], rect[3], -1)); // End of a rectangle
        }

        // Sort events by x. If x is the same, process start (-1) before end (+1)
        events.Sort((a, b) => a.x != b.x ? a.x.CompareTo(b.x) : a.type.CompareTo(b.type));

        // Sweep line variables
        int prevX = 0;
        long totalArea = 0;
        var activeIntervals = new List<(int y1, int y2)>();

        // Function to calculate vertical coverage
        long CalculateVerticalCoverage()
        {
            activeIntervals.Sort((a, b) => a.y1.CompareTo(b.y1)); // Sort by y1
            long coverage = 0;
            int prevY = -1;
            foreach (var (y1, y2) in activeIntervals)
            {
                prevY = Math.Max(prevY, y1);
                if (y2 > prevY)
                {
                    coverage += y2 - prevY;
                    prevY = y2;
                }
            }
            return coverage;
        }

        // Process each event
        foreach (var (x, y1, y2, type) in events)
        {
            // Add area from previous x to current x
            totalArea += CalculateVerticalCoverage() * (x - prevX);
            totalArea %= MOD;
            prevX = x;

            // Update active intervals
            if (type == 1)
            { // Start of a rectangle
                activeIntervals.Add((y1, y2));
            }
            else
            { // End of a rectangle
                activeIntervals.Remove((y1, y2));
            }
        }

        return (int)totalArea;
    }
}
