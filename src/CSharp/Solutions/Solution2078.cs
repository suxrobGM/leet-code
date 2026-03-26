namespace LeetCode.Solutions;

public class Solution2078
{
    /// <summary>
    /// 2078. Two Furthest Houses With Different Colors - Easy
    /// <a href="https://leetcode.com/problems/two-furthest-houses-with-different-colors">See the problem</a>
    /// </summary>
    public int MaxDistance(int[] colors)
    {
        var n = colors.Length;
        var result = 0;

        for (var i = n - 1; i >= 0; i--)
        {
            if (colors[i] != colors[0])
            {
                result = Math.Max(result, i);
                break;
            }
        }

        for (var i = 0; i < n; i++)
        {
            if (colors[i] != colors[n - 1])
            {
                result = Math.Max(result, n - 1 - i);
                break;
            }
        }

        return result;
    }
}
