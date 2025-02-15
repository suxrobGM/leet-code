﻿using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution780
{
    /// <summary>
    /// 780. Reaching Points - Hard
    /// <a href="https://leetcode.com/problems/reaching-points">See the problem</a>
    /// </summary>
    public bool ReachingPoints(int sx, int sy, int tx, int ty)
    {
        while (tx >= sx && ty >= sy)
        {
            if (tx == ty) break;

            if (tx > ty)
            {
                if (ty > sy)
                {
                    tx %= ty;
                }
                else
                {
                    return (tx - sx) % ty == 0;
                }
            }
            else
            {
                if (tx > sx)
                {
                    ty %= tx;
                }
                else
                {
                    return (ty - sy) % tx == 0;
                }
            }
        }

        return tx == sx && ty == sy;
    }
}
