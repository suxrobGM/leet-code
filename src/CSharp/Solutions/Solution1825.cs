using System.Text;

namespace LeetCode.Solutions;

public class Solution1825
{
    /// <summary>
    /// 1825. Finding MK Average - Medium
    /// <a href="https://leetcode.com/problems/finding-mk-average">See the problem</a>
    /// </summary>
    public class MKAverage
    {
        private readonly int m, k;
        private readonly Queue<int> window = new();

        private readonly MultiSet low = new();   // smallest k
        private readonly MultiSet mid = new();   // middle m-2k
        private readonly MultiSet high = new();  // largest k

        private long sumMid = 0;

        public MKAverage(int m, int k)
        {
            this.m = m;
            this.k = k;
        }

        public void AddElement(int num)
        {
            window.Enqueue(num);

            // Insert into a bucket
            if (low.Count > 0 && num <= low.Max())
            {
                low.Add(num);
            }
            else if (high.Count > 0 && num >= high.Min())
            {
                high.Add(num);
            }
            else
            {
                mid.Add(num);
                sumMid += num;
            }

            // Evict if window too large
            if (window.Count > m)
            {
                int old = window.Dequeue();
                if (low.RemoveOne(old))
                {
                    // removed from low
                }
                else if (high.RemoveOne(old))
                {
                    // removed from high
                }
                else
                {
                    // removed from mid
                    if (mid.RemoveOne(old)) sumMid -= old;
                }
            }

            Rebalance();
        }

        public int CalculateMKAverage()
        {
            if (window.Count < m) return -1;
            int denom = m - 2 * k;
            return (int)(sumMid / denom);
        }

        private void Rebalance()
        {
            // Push extras from low/high into mid
            while (low.Count > k)
            {
                int v = low.PopMax();
                mid.Add(v);
                sumMid += v;
            }
            while (high.Count > k)
            {
                int v = high.PopMin();
                mid.Add(v);
                sumMid += v;
            }

            // Only enforce exact sizes when we have at least m elements
            if (window.Count >= m)
            {
                while (low.Count < k)
                {
                    int v = mid.PopMin();
                    sumMid -= v;
                    low.Add(v);
                }
                while (high.Count < k)
                {
                    int v = mid.PopMax();
                    sumMid -= v;
                    high.Add(v);
                }
            }
        }

        // --- Multiset backed by SortedDictionary<int,int> ---
        private class MultiSet
        {
            private readonly SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            public int Count { get; private set; } = 0;

            public void Add(int x)
            {
                if (!dict.ContainsKey(x)) dict[x] = 0;
                dict[x]++;
                Count++;
            }

            public bool RemoveOne(int x)
            {
                if (!dict.TryGetValue(x, out int c)) return false;
                if (c == 1) dict.Remove(x);
                else dict[x] = c - 1;
                Count--;                  // <-- FIX: properly decrement
                return true;
            }

            public int PopMin()
            {
                var kv = dict.First();
                int x = kv.Key;
                RemoveOne(x);
                return x;
            }

            public int PopMax()
            {
                var kv = dict.Last();
                int x = kv.Key;
                RemoveOne(x);
                return x;
            }

            public int Min()
            {
                if (dict.Count == 0) throw new InvalidOperationException("Min on empty multiset");
                return dict.First().Key;
            }

            public int Max()
            {
                if (dict.Count == 0) throw new InvalidOperationException("Max on empty multiset");
                return dict.Last().Key;
            }
        }
    }
}
