using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution822
{
    /// <summary>
    /// 822. Card Flipping Game - Medium
    /// <a href="https://leetcode.com/problems/card-flipping-game">See the problem</a>
    /// </summary>
    public int Flipgame(int[] fronts, int[] backs)
    {
        var n = fronts.Length;
        var same = new HashSet<int>();

        for (var i = 0; i < n; i++)
        {
            if (fronts[i] == backs[i])
            {
                same.Add(fronts[i]);
            }
        }

        var result = int.MaxValue;
        for (var i = 0; i < n; i++)
        {
            if (!same.Contains(fronts[i]))
            {
                result = Math.Min(result, fronts[i]);
            }

            if (!same.Contains(backs[i]))
            {
                result = Math.Min(result, backs[i]);
            }
        }

        return result == int.MaxValue ? 0 : result;
    }
}
