namespace LeetCode.Solutions;

public class Solution2141
{
    /// <summary>
    /// 2141. Maximum Running Time of N Computers - Hard
    /// <a href="https://leetcode.com/problems/maximum-running-time-of-n-computers">See the problem</a>
    /// </summary>
    public long MaxRunTime(int n, int[] batteries)
    {
        long sum = 0;
        foreach (int b in batteries) sum += b;

        long lo = 1, hi = sum / n;
        while (lo < hi)
        {
            long mid = lo + (hi - lo + 1) / 2;
            long total = 0;
            foreach (int b in batteries)
            {
                total += Math.Min(b, mid);
                if (total >= n * mid) break;
            }
            if (total >= n * mid) lo = mid;
            else hi = mid - 1;
        }
        return lo;
    }
}
