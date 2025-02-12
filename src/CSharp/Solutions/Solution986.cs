using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution986
{
    /// <summary>
    /// 986. Interval List Intersections - Medium
    /// <a href="https://leetcode.com/problems/interval-list-intersections">See the problem</a>
    /// </summary>
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        var result = new List<int[]>();
        var i = 0;
        var j = 0;

        while (i < firstList.Length && j < secondList.Length)
        {
            var start = Math.Max(firstList[i][0], secondList[j][0]);
            var end = Math.Min(firstList[i][1], secondList[j][1]);

            if (start <= end)
            {
                result.Add(new int[] { start, end });
            }

            if (firstList[i][1] < secondList[j][1])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return [.. result];
    }
}
