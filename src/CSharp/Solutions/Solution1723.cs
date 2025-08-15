using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1723
{
    /// <summary>
    /// 1723. Find Minimum Time to Finish All Jobs - Medium
    /// <a href="https://leetcode.com/problems/find-minimum-time-to-finish-all-jobs">See the problem</a>
    /// </summary>
    public int MinimumTimeRequired(int[] jobs, int k)
    {
        Array.Sort(jobs);
        Array.Reverse(jobs);                 // big jobs first → strong pruning

        int lo = jobs[0];                    // at least the largest job
        long sum = 0;
        foreach (var j in jobs) sum += j;
        int hi = (int)sum;                   // at most all jobs on one worker

        int ans = hi;
        var loads = new int[k];

        while (lo <= hi)
        {
            int mid = lo + ((hi - lo) >> 1);
            Array.Clear(loads, 0, loads.Length);
            if (CanAssign(jobs, 0, loads, mid))
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

    // Try to assign jobs[idx..] under limit per worker
    private bool CanAssign(int[] jobs, int idx, int[] loads, int limit)
    {
        if (idx == jobs.Length) return true;

        int curJob = jobs[idx];
        var seen = new HashSet<int>();       // avoid trying identical load states

        for (int i = 0; i < loads.Length; i++)
        {
            if (loads[i] + curJob > limit) continue;
            if (seen.Contains(loads[i])) continue; // symmetry pruning
            seen.Add(loads[i]);

            loads[i] += curJob;
            if (CanAssign(jobs, idx + 1, loads, limit)) return true;
            loads[i] -= curJob;

            if (loads[i] == 0) break;       // putting the job into any empty worker failed → no need to try other empties
        }
        return false;
    }
}
