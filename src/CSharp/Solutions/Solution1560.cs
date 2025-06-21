using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1560
{
    /// <summary>
    /// 1560. Most Visited Sector in a Circular Track - Easy
    /// <a href="https://leetcode.com/problems/most-visited-sector-in-a-circular-track">See the problem</a>
    /// </summary>
    public IList<int> MostVisited(int n, int[] rounds)
    {
        var result = new List<int>();
        int start = rounds[0];
        int end = rounds[rounds.Length - 1];

        if (start <= end)
        {
            for (int i = start; i <= end; i++)
            {
                result.Add(i);
            }
        }
        else
        {
            for (int i = start; i <= n; i++)
            {
                result.Add(i);
            }
            for (int i = 1; i <= end; i++)
            {
                result.Add(i);
            }
        }

        result.Sort();
        return result;
    }
}
