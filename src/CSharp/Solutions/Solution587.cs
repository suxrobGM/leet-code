using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution587
{
    /// <summary>
    /// 587. Erect the Fence - Hard
    /// <a href="https://leetcode.com/problems/erect-the-fence">See the problem</a>
    /// </summary>
    public int[][] OuterTrees(int[][] trees)
    {
        var n = trees.Length;
        if (n <= 3)
        {
            return trees;
        }

        Array.Sort(trees, (a, b) =>
        {
            if (a[0] == b[0])
            {
                return a[1] - b[1];
            }
            return a[0] - b[0];
        });

        var hull = new List<int[]>();
        for (var i = 0; i < n; i++)
        {
            while (hull.Count >= 2 && Orientation(hull[^2], hull[^1], trees[i]) > 0)
            {
                hull.RemoveAt(hull.Count - 1);
            }
            hull.Add(trees[i]);
        }

        hull.RemoveAt(hull.Count - 1);
        for (var i = n - 1; i >= 0; i--)
        {
            while (hull.Count >= 2 && Orientation(hull[^2], hull[^1], trees[i]) > 0)
            {
                hull.RemoveAt(hull.Count - 1);
            }
            hull.Add(trees[i]);
        }

        return hull.Distinct().ToArray();
    }

    private int Orientation(int[] p, int[] q, int[] r)
    {
        return (q[1] - p[1]) * (r[0] - q[0]) - (q[0] - p[0]) * (r[1] - q[1]);
    }
}
