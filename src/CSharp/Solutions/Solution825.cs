using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution825
{
    /// <summary>
    /// 825. Friends Of Appropriate Ages - Medium
    /// <a href="https://leetcode.com/problems/friends-of-appropriate-ages">See the problem</a>
    /// </summary>
    public int NumFriendRequests(int[] ages)
    {
        var count = new int[121];
        foreach (var age in ages)
        {
            count[age]++;
        }

        var result = 0;
        for (var i = 1; i <= 120; i++)
        {
            for (var j = 1; j <= 120; j++)
            {
                if (j <= 0.5 * i + 7 || j > i || (j > 100 && i < 100))
                {
                    continue;
                }

                result += count[i] * count[j];
                if (i == j)
                {
                    result -= count[i];
                }
            }
        }

        return result;
    }
}
