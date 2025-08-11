using System.Text;


namespace LeetCode.Solutions;

public class Solution1711
{
    /// <summary>
    /// 1711. Count Good Meals - Medium
    /// <a href="https://leetcode.com/problems/count-good-meals">See the problem</a>
    /// </summary>
    public int CountPairs(int[] deliciousness)
    {
        const int MOD = 1_000_000_007;
        var freq = new Dictionary<int, int>();
        long ans = 0;

        // Precompute powers of two up to 2^21
        int[] powers = new int[22];
        powers[0] = 1;
        for (int i = 1; i < powers.Length; i++) powers[i] = powers[i - 1] << 1;

        foreach (int x in deliciousness)
        {
            foreach (int p in powers)
            {
                int need = p - x;
                if (freq.TryGetValue(need, out int cnt))
                    ans += cnt;
            }

            // record current x
            if (freq.TryGetValue(x, out int cur))
                freq[x] = cur + 1;
            else
                freq[x] = 1;
        }

        return (int)(ans % MOD);
    }
}
