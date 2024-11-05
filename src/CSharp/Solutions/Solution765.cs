using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution765
{
    /// <summary>
    /// 765. Couples Holding Hands - Hard
    /// <a href="https://leetcode.com/problems/couples-holding-hands">See the problem</a>
    /// </summary>
    public int MinSwapsCouples(int[] row)
    {
        var n = row.Length;
        var pos = new int[n];
        for (var i = 0; i < n; i++)
        {
            pos[row[i]] = i;
        }

        var result = 0;
        for (var i = 0; i < n; i += 2)
        {
            var pair = row[i] % 2 == 0 ? row[i] + 1 : row[i] - 1;
            if (row[i + 1] != pair)
            {
                result++;
                var tmp = row[i + 1];
                row[i + 1] = pair;
                row[pos[pair]] = tmp;
                pos[tmp] = pos[pair];
            }
        }

        return result;
    }
}
