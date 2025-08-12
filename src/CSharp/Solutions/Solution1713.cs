using System.Text;


namespace LeetCode.Solutions;

public class Solution1713
{
    /// <summary>
    /// 1713. Minimum Operations to Make a Subsequence - Hard
    /// <a href="https://leetcode.com/problems/minimum-operations-to-make-a-subsequence">See the problem</a>
    /// </summary>
    public int MinOperations(int[] target, int[] arr)
    {
        // Map each target value -> its position
        var pos = new Dictionary<int, int>(target.Length);
        for (int i = 0; i < target.Length; i++) pos[target[i]] = i;

        // Build sequence of positions from arr, skipping values not in target
        var seq = new List<int>();
        foreach (var v in arr)
            if (pos.TryGetValue(v, out int idx))
                seq.Add(idx);

        // LIS (strictly increasing) on seq via patience sorting
        var tails = new List<int>(); // tails[len-1] = smallest tail for LIS length len
        foreach (var x in seq)
        {
            int i = LowerBound(tails, x);
            if (i == tails.Count) tails.Add(x);
            else tails[i] = x;
        }

        int lis = tails.Count;
        return target.Length - lis;
    }

    // first index i where list[i] >= x
    private int LowerBound(List<int> a, int x)
    {
        int l = 0, r = a.Count - 1, ans = a.Count;
        while (l <= r)
        {
            int m = l + ((r - l) >> 1);
            if (a[m] >= x) { ans = m; r = m - 1; }
            else l = m + 1;
        }
        return ans;
    }
}
