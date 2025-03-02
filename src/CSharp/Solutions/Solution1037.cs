using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1037
{
    /// <summary>
    /// 1037. Valid Boomerang - Easy
    /// <a href="https://leetcode.com/problems/valid-boomerang</a>
    /// </summary>
    public bool IsBoomerang(int[][] points)
    {
        return (points[0][0] - points[1][0]) * (points[0][1] - points[2][1]) != (points[0][0] - points[2][0]) * (points[0][1] - points[1][1]);
    }
}
