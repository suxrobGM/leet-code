namespace LeetCode.Solutions;

public class Solution2286
{
    /// <summary>
    /// 2286. Booking Concert Tickets in Groups - Hard
    /// <a href="https://leetcode.com/problems/booking-concert-tickets-in-groups">See the problem</a>
    /// </summary>
    public class BookMyShow
    {
        private readonly int _n;
        private readonly int _m;
        private readonly long[] _max;
        private readonly long[] _sum;
        private int _firstNonFull;

        public BookMyShow(int n, int m)
        {
            _n = n;
            _m = m;
            _max = new long[4 * n];
            _sum = new long[4 * n];
            Build(1, 0, n - 1);
        }

        public int[] Gather(int k, int maxRow)
        {
            var row = FindFirst(1, 0, _n - 1, k, maxRow);

            if (row == -1)
            {
                return [];
            }

            var free = QuerySum(1, 0, _n - 1, row, row);
            var seat = (int)(_m - free);
            Update(1, 0, _n - 1, row, free - k);
            return [row, seat];
        }

        public bool Scatter(int k, int maxRow)
        {
            if (QuerySum(1, 0, _n - 1, 0, maxRow) < k)
            {
                return false;
            }

            long remaining = k;

            while (remaining > 0)
            {
                var free = QuerySum(1, 0, _n - 1, _firstNonFull, _firstNonFull);
                var take = Math.Min(free, remaining);
                Update(1, 0, _n - 1, _firstNonFull, free - take);
                remaining -= take;

                if (free == take)
                {
                    _firstNonFull++;
                }
            }

            return true;
        }

        private void Build(int node, int left, int right)
        {
            if (left == right)
            {
                _max[node] = _m;
                _sum[node] = _m;
                return;
            }

            var mid = (left + right) / 2;
            Build(2 * node, left, mid);
            Build(2 * node + 1, mid + 1, right);
            _max[node] = Math.Max(_max[2 * node], _max[2 * node + 1]);
            _sum[node] = _sum[2 * node] + _sum[2 * node + 1];
        }

        private void Update(int node, int left, int right, int index, long value)
        {
            if (left == right)
            {
                _max[node] = value;
                _sum[node] = value;
                return;
            }

            var mid = (left + right) / 2;

            if (index <= mid)
            {
                Update(2 * node, left, mid, index, value);
            }
            else
            {
                Update(2 * node + 1, mid + 1, right, index, value);
            }

            _max[node] = Math.Max(_max[2 * node], _max[2 * node + 1]);
            _sum[node] = _sum[2 * node] + _sum[2 * node + 1];
        }

        private long QuerySum(int node, int left, int right, int from, int to)
        {
            if (to < left || right < from)
            {
                return 0;
            }

            if (from <= left && right <= to)
            {
                return _sum[node];
            }

            var mid = (left + right) / 2;
            return QuerySum(2 * node, left, mid, from, to) + QuerySum(2 * node + 1, mid + 1, right, from, to);
        }

        private int FindFirst(int node, int left, int right, int k, int maxRow)
        {
            if (left > maxRow || _max[node] < k)
            {
                return -1;
            }

            if (left == right)
            {
                return left;
            }

            var mid = (left + right) / 2;
            var result = FindFirst(2 * node, left, mid, k, maxRow);
            return result != -1 ? result : FindFirst(2 * node + 1, mid + 1, right, k, maxRow);
        }
    }
}
