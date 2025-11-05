using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1894
{
    /// <summary>
    /// 1894. Find the Student that Will Replace the Chalk - Medium
    /// <a href="https://leetcode.com/problems/find-the-student-that-will-replace-the-chalk">See the problem</a>
    /// </summary>
    public int ChalkReplacer(int[] chalk, int k)
    {
        int n = chalk.Length;
        var prefix = new long[n];
        prefix[0] = chalk[0];
        for (int i = 1; i < n; i++)
            prefix[i] = prefix[i - 1] + chalk[i];

        long r = k % prefix[n - 1]; // remaining chalk after full rounds

        // Find the smallest index i with prefix[i] > r
        int lo = 0, hi = n - 1, ans = n - 1;
        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (prefix[mid] > r)
            {
                ans = mid;
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }
        }
        return ans;
    }
}
