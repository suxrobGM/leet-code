namespace LeetCode.Solutions;

public class Solution391
{
    /// <summary>
    /// 391. Perfect Rectangle - Hard
    /// <a href="https://leetcode.com/problems/perfect-rectangle">See the problem</a>
    /// </summary>
    public bool IsRectangleCover(int[][] rectangles)
    {
        var corners = new HashSet<string>();
        var area = 0;

        foreach (var rect in rectangles)
        {
            var bottomLeft = $"{rect[0]} {rect[1]}";
            var bottomRight = $"{rect[2]} {rect[1]}";
            var topLeft = $"{rect[0]} {rect[3]}";
            var topRight = $"{rect[2]} {rect[3]}";

            area += (rect[2] - rect[0]) * (rect[3] - rect[1]);

            if (!corners.Add(bottomLeft))
            {
                corners.Remove(bottomLeft);
            }

            if (!corners.Add(bottomRight))
            {
                corners.Remove(bottomRight);
            }

            if (!corners.Add(topLeft))
            {
                corners.Remove(topLeft);
            }

            if (!corners.Add(topRight))
            {
                corners.Remove(topRight);
            }
        }

        if (corners.Count != 4 ||
            !corners.Contains($"{rectangles.Min(r => r[0])} {rectangles.Min(r => r[1])}") ||
            !corners.Contains($"{rectangles.Min(r => r[0])} {rectangles.Max(r => r[3])}") ||
            !corners.Contains($"{rectangles.Max(r => r[2])} {rectangles.Min(r => r[1])}") ||
            !corners.Contains($"{rectangles.Max(r => r[2])} {rectangles.Max(r => r[3])}"))
        {
            return false;
        }

        return area == (rectangles.Max(r => r[2]) - rectangles.Min(r => r[0])) * (rectangles.Max(r => r[3]) - rectangles.Min(r => r[1]));
    }
}
