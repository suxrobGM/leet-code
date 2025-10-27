using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1882
{
    /// <summary>
    /// 1882. Process Tasks Using Servers - Medium
    /// <a href="https://leetcode.com/problems/process-tasks-using-servers">See the problem</a>
    /// </summary>
    public int[] AssignTasks(int[] servers, int[] tasks)
    {
        int n = servers.Length, m = tasks.Length;
        var ans = new int[m];

        var available = new AvailHeap();
        for (int i = 0; i < n; i++)
            available.Push(new Avail(servers[i], i));

        var busy = new BusyHeap();

        long time = 0;

        for (int i = 0; i < m; i++)
        {
            time = Math.Max(time, (long)i);

            // Free all servers whose jobs finished by 'time'
            while (busy.Count > 0 && busy.Peek().freeTime <= time)
            {
                var b = busy.Pop();
                available.Push(new Avail(b.weight, b.index));
            }

            // If still none available, jump to earliest server free time
            if (available.Count == 0)
            {
                time = busy.Peek().freeTime;
                while (busy.Count > 0 && busy.Peek().freeTime <= time)
                {
                    var b = busy.Pop();
                    available.Push(new Avail(b.weight, b.index));
                }
            }

            // Assign current task i
            var s = available.Pop();
            ans[i] = s.index;
            busy.Push(new Busy(time + tasks[i], s.weight, s.index));
        }

        return ans;
    }

    // ---------- Heaps ----------
    private readonly struct Avail
    {
        public readonly int weight, index;
        public Avail(int w, int i) { weight = w; index = i; }
    }

    private sealed class AvailHeap
    {
        private readonly List<Avail> a = new();
        public int Count => a.Count;

        public void Push(Avail v)
        {
            a.Add(v);
            SiftUp(a.Count - 1);
        }

        public Avail Pop()
        {
            var top = a[0];
            int last = a.Count - 1;
            a[0] = a[last];
            a.RemoveAt(last);
            if (a.Count > 0) SiftDown(0);
            return top;
        }

        public Avail Peek() => a[0];

        private static int Cmp(Avail x, Avail y)
        {
            int c = x.weight.CompareTo(y.weight);
            return c != 0 ? c : x.index.CompareTo(y.index);
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
    }

    private readonly struct Busy
    {
        public readonly long freeTime;
        public readonly int weight, index;
        public Busy(long t, int w, int i) { freeTime = t; weight = w; index = i; }
    }

    private sealed class BusyHeap
    {
        private readonly List<Busy> a = new();
        public int Count => a.Count;

        public void Push(Busy v)
        {
            a.Add(v);
            SiftUp(a.Count - 1);
        }

        public Busy Pop()
        {
            var top = a[0];
            int last = a.Count - 1;
            a[0] = a[last];
            a.RemoveAt(last);
            if (a.Count > 0) SiftDown(0);
            return top;
        }

        public Busy Peek() => a[0];

        private static int Cmp(Busy x, Busy y)
        {
            int c = x.freeTime.CompareTo(y.freeTime);
            if (c != 0) return c;
            c = x.weight.CompareTo(y.weight);
            if (c != 0) return c;
            return x.index.CompareTo(y.index);
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
    }
}
