using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1128
{
    /// <summary>
    /// 1128. Number of Equivalent Domino Pairs - Easy
    /// <a href="https://leetcode.com/problems/number-of-equivalent-domino-pairs">See the problem</a>
    /// </summary>
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        var count = 0;
        var map = new Dictionary<int, int>();

        foreach (var domino in dominoes)
        {
            var key = domino[0] < domino[1] ? domino[0] * 10 + domino[1] : domino[1] * 10 + domino[0];

            if (map.ContainsKey(key))
            {
                count += map[key];
                map[key]++;
            }
            else
            {
                map[key] = 1;
            }
        }

        return count;
    }
}
