using System.Text;

namespace LeetCode.Solutions;

public class Solution699
{
    /// <summary>
    /// 699. Falling Squares - Hard
    /// <a href="https://leetcode.com/problems/falling-squares">See the problem</a>
    /// </summary>
    public IList<int> FallingSquares(int[][] positions)
    {
        var ans = new List<int>();
        var squares = new List<(int left, int right, int height)>();
        var maxHeight = 0;

        foreach (var pos in positions)
        {
            var left = pos[0];
            var size = pos[1];
            var right = left + size;
            var baseHeight = 0;

            // Check for overlapping intervals
            foreach (var square in squares)
            {
                if (square.right > left && square.left < right)
                {  // There is overlap
                    baseHeight = Math.Max(baseHeight, square.height);
                }
            }

            // Height of the new square when it lands
            var newHeight = baseHeight + size;
            squares.Add((left, right, newHeight));

            // Update the maximum height
            maxHeight = Math.Max(maxHeight, newHeight);
            ans.Add(maxHeight);
        }

        return ans;
    }
}
