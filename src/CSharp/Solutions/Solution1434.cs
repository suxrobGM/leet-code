namespace LeetCode.Solutions;

public class Solution1434
{
    /// <summary>
    /// 1434. Number of Ways to Wear Different Hats to Each Other - Hard
    /// <a href="https://leetcode.com/problems/number-of-ways-to-wear-different-hats-to-each-other">See the problem</a>
    /// </summary>
    public int NumberWays(IList<IList<int>> hats)
    {
        const int MOD = 1000000007;
        int n = hats.Count;
        var hatToPeople = new List<int>[41];

        for (int i = 1; i <= 40; i++)
            hatToPeople[i] = [];

        for (int person = 0; person < n; person++)
        {
            foreach (var hat in hats[person])
                hatToPeople[hat].Add(person);
        }

        int maxMask = 1 << n;
        int[] dp = new int[maxMask];
        dp[0] = 1;

        for (int hat = 1; hat <= 40; hat++)
        {
            int[] next = new int[maxMask];
            Array.Copy(dp, next, maxMask);

            foreach (int mask in Enumerable.Range(0, maxMask))
            {
                if (dp[mask] == 0) continue;

                foreach (int person in hatToPeople[hat])
                {
                    if ((mask & (1 << person)) == 0)
                    {
                        int newMask = mask | (1 << person);
                        next[newMask] = (next[newMask] + dp[mask]) % MOD;
                    }
                }
            }

            dp = next;
        }

        return dp[maxMask - 1];
    }
}
