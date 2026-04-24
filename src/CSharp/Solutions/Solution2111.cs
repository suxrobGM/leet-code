using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2111
{
    /// <summary>
    /// 2111. Minimum Operations to Make the Array K-Increasing - Hard
    /// <a href="https://leetcode.com/problems/minimum-operations-to-make-the-array-k-increasing">See the problem</a>
    /// </summary>
    public int KIncreasing(int[] arr, int k)
    {
        var ops = 0;
        var sub = new List<int>();
        var tails = new List<int>();

        for (var r = 0; r < k; r++)
        {
            sub.Clear();
            for (var i = r; i < arr.Length; i += k)
            {
                sub.Add(arr[i]);
            }
            ops += sub.Count - LongestNonDecreasing(sub, tails);
        }

        return ops;
    }

    private static int LongestNonDecreasing(List<int> a, List<int> tails)
    {
        tails.Clear();
        foreach (var x in a)
        {
            int lo = 0, hi = tails.Count;
            while (lo < hi)
            {
                var mid = (lo + hi) >> 1;
                if (tails[mid] <= x) lo = mid + 1;
                else hi = mid;
            }
            if (lo == tails.Count) tails.Add(x);
            else tails[lo] = x;
        }
        return tails.Count;
    }
}
