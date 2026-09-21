namespace LeetCode.Solutions;

public class Solution2285
{
    /// <summary>
    /// 2285. Maximum Total Importance of Roads - Medium
    /// <a href="https://leetcode.com/problems/maximum-total-importance-of-roads">See the problem</a>
    /// </summary>
    public long MaximumImportance(int n, int[][] roads)
    {
        var degrees = new long[n];

        foreach (var road in roads)
        {
            degrees[road[0]]++;
            degrees[road[1]]++;
        }

        Array.Sort(degrees);

        long result = 0;

        for (var i = 0; i < n; i++)
        {
            result += degrees[i] * (i + 1);
        }

        return result;
    }
}
