using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1007
{
    /// <summary>
    /// 1007. Minimum Domino Rotations For Equal Row - Medium
    /// <a href="https://leetcode.com/problems/minimum-domino-rotations-for-equal-row</a>
    /// </summary>
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        var n = tops.Length;
        var top = new int[7];
        var bottom = new int[7];
        var same = new int[7];

        for (var i = 0; i < n; i++)
        {
            top[tops[i]]++;
            bottom[bottoms[i]]++;

            if (tops[i] == bottoms[i])
            {
                same[tops[i]]++;
            }
        }

        for (var i = 1; i < 7; i++)
        {
            if (top[i] + bottom[i] - same[i] == n)
            {
                return n - Math.Max(top[i], bottom[i]);
            }
        }

        return -1;
    }
}
