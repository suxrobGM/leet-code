using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1626
{
    /// <summary>
    /// 1626. Best Team With No Conflicts - Medium
    /// <a href="https://leetcode.com/problems/best-team-with-no-conflicts">See the problem</a>
    /// </summary>
    public int BestTeamScore(int[] scores, int[] ages)
    {
        int n = scores.Length;
        int[] dp = new int[n];
        (int score, int age)[] players = new (int, int)[n];

        for (int i = 0; i < n; ++i)
            players[i] = (scores[i], ages[i]);

        Array.Sort(players, (x, y) => x.age == y.age ? x.score - y.score : x.age - y.age);

        for (int i = 0; i < n; ++i)
        {
            dp[i] = players[i].score;
            for (int j = 0; j < i; ++j)
            {
                if (players[j].score <= players[i].score)
                    dp[i] = Math.Max(dp[i], dp[j] + players[i].score);
            }
        }

        return dp.Max();
    }
}
