using System.Text;

namespace LeetCode.Solutions;

public class Solution403
{
    /// <summary>
    /// 403. Frog Jump - Hard
    /// <a href="https://leetcode.com/problems/frog-jump">See the problem</a>
    /// </summary>
    public bool CanCross(int[] stones)
    {
        var dp = new Dictionary<int, HashSet<int>>();

        foreach (var stone in stones)
        {
            dp[stone] = new HashSet<int>();
        }

        dp[0].Add(0);

        for (var i = 0; i < stones.Length; i++)
        {
            foreach (var k in dp[stones[i]])
            {
                for (var step = k - 1; step <= k + 1; step++)
                {
                    if (step > 0 && dp.ContainsKey(stones[i] + step))
                    {
                        dp[stones[i] + step].Add(step);
                    }
                }
            }
        }

        return dp[stones[^1]].Count > 0;
    }
}
