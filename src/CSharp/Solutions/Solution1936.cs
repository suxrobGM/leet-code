using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1936
{
    /// <summary>
    /// 1936. Add Minimum Number of Rungs - Medium
    /// <a href="https://leetcode.com/problems/add-minimum-number-of-rungs">See the problem</a>
    /// </summary>
    public int AddRungs(int[] rungs, int dist)
    {
        int addedRungs = 0;
        int currentHeight = 0;

        foreach (var rung in rungs)
        {
            int gap = rung - currentHeight;
            if (gap > dist)
            {
                addedRungs += (gap - 1) / dist;
            }
            currentHeight = rung;
        }

        return addedRungs;
    }
}
