using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1079
{
    /// <summary>
    /// 1079. Letter Tile Possibilities - Medium
    /// <a href="https://leetcode.com/problems/letter-tile-possibilities"</a>
    /// </summary>
    public int NumTilePossibilities(string tiles)
    {
        var count = new int[26];
        foreach (var c in tiles)
        {
            count[c - 'A']++;
        }

        return Dfs(count);
    }

    private int Dfs(int[] count)
    {
        int sum = 0;
        for (int i = 0; i < 26; i++)
        {
            if (count[i] == 0)
            {
                continue;
            }

            sum++;
            count[i]--;

            sum += Dfs(count);

            count[i]++;
        }

        return sum;
    }
}
