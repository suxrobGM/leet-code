using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1851
{
    /// <summary>
    /// 1851. Minimum Interval to Include Each Query - Hard
    /// <a href="https://leetcode.com/problems/minimum-interval-to-include-each-query">See the problem</a>
    /// </summary>
    public int[] MinInterval(int[][] intervals, int[] queries)
    {
        // Sort intervals by left ascending
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // Pair queries with original indices, sort by value
        int m = queries.Length;
        var qpairs = new (int val, int idx)[m];
        for (int i = 0; i < m; i++) qpairs[i] = (queries[i], i);
        Array.Sort(qpairs, (a, b) => a.val.CompareTo(b.val));

        var ans = new int[m];
        Array.Fill(ans, -1);

        var heap = new MinHeap(); // stores (len, right)
        int p = 0; // pointer over intervals

        foreach (var (q, qi) in qpairs)
        {
            // add all intervals with left <= q
            while (p < intervals.Length && intervals[p][0] <= q)
            {
                int left = intervals[p][0];
                int right = intervals[p][1];
                int len = right - left + 1;
                heap.Push(len, right);
                p++;
            }

            // remove intervals that end before q
            while (heap.Count > 0 && heap.Peek().right < q)
                heap.Pop();

            if (heap.Count > 0)
                ans[qi] = heap.Peek().len; // smallest length covering q
        }

        return ans;
    }

    // --------- Lightweight min-heap (binary heap) by length ----------
    private sealed class MinHeap
    {
        private List<(int len, int right)> a = new();

        public int Count => a.Count;

        public (int len, int right) Peek() => a[0];

        public void Push(int len, int right)
        {
            a.Add((len, right));
            SiftUp(a.Count - 1);
        }

        public (int len, int right) Pop()
        {
            var top = a[0];
            int last = a.Count - 1;
            a[0] = a[last];
            a.RemoveAt(last);
            if (a.Count > 0) SiftDown(0);
            return top;
        }

        private void SiftUp(int i)
        {
            while (i > 0)
            {
                int p = (i - 1) >> 1;
                if (Cmp(a[i], a[p]) >= 0) break;
                (a[i], a[p]) = (a[p], a[i]);
                i = p;
            }
        }

        private void SiftDown(int i)
        {
            int n = a.Count;
            while (true)
            {
                int l = (i << 1) + 1, r = l + 1, s = i;
                if (l < n && Cmp(a[l], a[s]) < 0) s = l;
                if (r < n && Cmp(a[r], a[s]) < 0) s = r;
                if (s == i) break;
                (a[i], a[s]) = (a[s], a[i]);
                i = s;
            }
        }

        // Primary key: len asc; tie-breaker: right asc (optional, stable)
        private static int Cmp((int len, int right) x, (int len, int right) y)
        {
            int c = x.len.CompareTo(y.len);
            return c != 0 ? c : x.right.CompareTo(y.right);
        }
    }
}
