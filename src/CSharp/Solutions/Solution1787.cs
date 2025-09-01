using System.Text;

namespace LeetCode.Solutions;

public class Solution1787
{
    private const int MOD = 1_000_000_007;

    /// <summary>
    /// 1787. Make the XOR of All Segments Equal to Zero - Hard
    /// <a href="https://leetcode.com/problems/make-the-xor-of-all-segments-equal-to-zero">See the problem</a>
    /// </summary>
    public int MinChanges(int[] nums, int k)
    {
        int n = nums.Length;
        int maxXor = 1 << 10; // since nums[i] < 2^10 = 1024
        int INF = 1000000000;

        // Build frequency per group
        var freq = new Dictionary<int, int>[k];
        var size = new int[k];
        for (int i = 0; i < k; i++)
        {
            freq[i] = new Dictionary<int, int>();
        }
        for (int i = 0; i < n; i++)
        {
            int g = i % k;
            size[g]++;
            if (!freq[g].ContainsKey(nums[i])) freq[g][nums[i]] = 0;
            freq[g][nums[i]]++;
        }

        // dp[x] = min cost to achieve xor=x after processing some groups
        int[] dp = new int[maxXor];
        Array.Fill(dp, INF);
        dp[0] = 0;

        foreach (int g in Enumerable.Range(0, k))
        {
            int[] next = new int[maxXor];
            Array.Fill(next, INF);

            // For efficiency: baseline if we change all numbers in this group
            int minPrev = dp.Min();
            foreach (int x in Enumerable.Range(0, maxXor))
            {
                // Case 1: change all in this group to something
                next[x] = Math.Min(next[x], minPrev + size[g]);

                // Case 2: use existing numbers
                foreach (var kv in freq[g])
                {
                    int val = kv.Key;
                    int count = kv.Value;
                    int cost = size[g] - count; // change rest to val
                    next[x] = Math.Min(next[x], dp[x ^ val] + cost);
                }
            }
            dp = next;
        }

        return dp[0];
    }
}

