using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1893
{
    /// <summary>
    /// 1893. Check if All the Integers in a Range Are Covered - Easy
    /// <a href="https://leetcode.com/problems/check-if-all-the-integers-in-a-range-are-covered">See the problem</a>
    /// </summary>
    public bool IsCovered(int[][] ranges, int left, int right)
    {
        var covered = new bool[right - left + 1];

        foreach (var range in ranges)
        {
            int start = Math.Max(range[0], left);
            int end = Math.Min(range[1], right);

            for (int i = start; i <= end; i++)
            {
                covered[i - left] = true;
            }
        }

        foreach (var isCovered in covered)
        {
            if (!isCovered) return false;
        }

        return true;
    }
}
