using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1547
{
    /// <summary>
    /// 1547. Minimum Cost to Cut a Stick - Hard
    /// <a href="https://leetcode.com/problems/minimum-cost-to-cut-a-stick">See the problem</a>
    /// </summary>
    public int MinCost(int n, int[] cuts)
    {
        Array.Sort(cuts);
        var dp = new int[cuts.Length + 2, cuts.Length + 2];
        var cutsWithEnds = new int[cuts.Length + 2];
        cutsWithEnds[0] = 0;
        cutsWithEnds[cuts.Length + 1] = n;

        for (int i = 1; i <= cuts.Length; i++)
        {
            cutsWithEnds[i] = cuts[i - 1];
        }

        for (int length = 2; length < cutsWithEnds.Length; length++)
        {
            for (int left = 0; left < cutsWithEnds.Length - length; left++)
            {
                int right = left + length;
                dp[left, right] = int.MaxValue;

                for (int cut = left + 1; cut < right; cut++)
                {
                    dp[left, right] = Math.Min(dp[left, right], dp[left, cut] + dp[cut, right] + cutsWithEnds[right] - cutsWithEnds[left]);
                }
            }
        }

        return dp[0, cutsWithEnds.Length - 1];
    }
}
