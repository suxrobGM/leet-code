namespace LeetCode.Solutions;

public class Solution2147
{
    /// <summary>
    /// 2147. Number of Ways to Divide a Long Corridor - Medium
    /// <a href="https://leetcode.com/problems/number-of-ways-to-divide-a-long-corridor">See the problem</a>
    /// </summary>
    public int NumberOfWays(string corridor)
    {
        const int MOD = 1_000_000_007;
        var seats = new List<int>();
        for (int i = 0; i < corridor.Length; i++)
        {
            if (corridor[i] == 'S') seats.Add(i);
        }

        if (seats.Count == 0 || seats.Count % 2 != 0) return 0;

        long ways = 1;
        for (int i = 2; i < seats.Count; i += 2)
        {
            ways = ways * (seats[i] - seats[i - 1]) % MOD;
        }
        return (int)ways;
    }
}
