using System.Numerics;
using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution973
{
    /// <summary>
    /// 973. K Closest Points to Origin - Medium
    /// <a href="https://leetcode.com/problems/k-closest-points-to-origin">See the problem</a>
    /// </summary>
    public int[][] KClosest(int[][] points, int k)
    {
        Array.Sort(points, (a, b) => a[0] * a[0] + a[1] * a[1] - b[0] * b[0] - b[1] * b[1]);
        return [.. points.Take(k)];
    }
}
