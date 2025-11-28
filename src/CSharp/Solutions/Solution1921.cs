using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1921
{
    /// <summary>
    /// 1921. Eliminate Maximum Number of Monsters - Medium
    /// <a href="https://leetcode.com/problems/eliminate-maximum-number-of-monsters">See the problem</a>
    /// </summary>
    public int EliminateMaximum(int[] dist, int[] speed)
    {
        var n = dist.Length;
        var arrivalTimes = new int[n];

        for (var i = 0; i < n; i++)
        {
            arrivalTimes[i] = (dist[i] + speed[i] - 1) / speed[i];
        }

        Array.Sort(arrivalTimes);

        for (var i = 0; i < n; i++)
        {
            if (arrivalTimes[i] <= i)
            {
                return i;
            }
        }

        return n;
    }
}
