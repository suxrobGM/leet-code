using System.Text;

namespace LeetCode.Solutions;

public class Solution1847
{
    /// <summary>
    /// 1847. Closest Room - Hard
    /// <a href="https://leetcode.com/problems/closest-room">See the problem</a>
    /// </summary>
    public int[] ClosestRoom(int[][] rooms, int[][] queries)
    {
        int n = rooms.Length, k = queries.Length;

        // Sort rooms by size desc, id asc (tiebreak doesn't matter)
        Array.Sort(rooms, (a, b) =>
        {
            int c = b[1].CompareTo(a[1]);
            return c != 0 ? c : a[0].CompareTo(b[0]);
        });

        // Sort queries by minSize desc, but remember original index
        var order = new int[k];
        for (int i = 0; i < k; i++) order[i] = i;
        Array.Sort(order, (i, j) => queries[j][1].CompareTo(queries[i][1]));

        var ans = new int[k];
        Array.Fill(ans, -1);

        var treap = new Treap();
        int p = 0; // rooms pointer

        foreach (int qi in order)
        {
            int pref = queries[qi][0];
            int minSize = queries[qi][1];

            // add all rooms that satisfy current minSize
            while (p < n && rooms[p][1] >= minSize)
            {
                treap.Insert(rooms[p][0]);
                p++;
            }

            if (treap.Count == 0)
            {
                ans[qi] = -1;
                continue;
            }

            // find nearest id to preferred
            int ceil = treap.Ceiling(pref); // smallest >= pref, or int.MaxValue if none
            int floor = treap.Floor(pref);  // largest <= pref, or int.MinValue if none

            if (ceil == int.MaxValue && floor == int.MinValue)
            {
                ans[qi] = -1;
            }
            else if (ceil == int.MaxValue)
            {
                ans[qi] = floor;
            }
            else if (floor == int.MinValue)
            {
                ans[qi] = ceil;
            }
            else
            {
                int d1 = Math.Abs(pref - floor);
                int d2 = Math.Abs(ceil - pref);
                ans[qi] = (d1 <= d2) ? floor : ceil; // tie -> smaller id (floor)
            }
        }

        return ans;
    }


    // --- Treap (randomized balanced BST) for ints (unique keys) ---
    private class Treap
    {
        private class Node
        {
            public int Key;
            public int Pri;
            public Node L, R;
            public Node(int key, int pri) { Key = key; Pri = pri; }
        }

        private Node root;
        private readonly Random rng = new Random(1337);
        public int Count { get; private set; }

        public void Insert(int key)
        {
            root = Insert(root, new Node(key, rng.Next()));
            Count++;
        }

        private Node Insert(Node t, Node it)
        {
            if (t == null) return it;
            if (it.Key < t.Key)
            {
                t.L = Insert(t.L, it);
                if (t.L.Pri < t.Pri) t = RotateRight(t);
            }
            else if (it.Key > t.Key)
            {
                t.R = Insert(t.R, it);
                if (t.R.Pri < t.Pri) t = RotateLeft(t);
            }
            else
            {
                // keys are unique per problem; no duplicate insert
                Count--; // undo increment if equal (defensive)
            }
            return t;
        }

        private static Node RotateRight(Node t)
        {
            var x = t.L;
            t.L = x.R;
            x.R = t;
            return x;
        }

        private static Node RotateLeft(Node t)
        {
            var x = t.R;
            t.R = x.L;
            x.L = t;
            return x;
        }

        // Largest key <= x; returns int.MinValue if none
        public int Floor(int x)
        {
            int best = int.MinValue;
            var t = root;
            while (t != null)
            {
                if (t.Key == x) return x;
                if (t.Key < x) { best = t.Key; t = t.R; }
                else t = t.L;
            }
            return best;
        }

        // Smallest key >= x; returns int.MaxValue if none
        public int Ceiling(int x)
        {
            int best = int.MaxValue;
            var t = root;
            while (t != null)
            {
                if (t.Key == x) return x;
                if (t.Key > x) { best = t.Key; t = t.L; }
                else t = t.R;
            }
            return best;
        }
    }
}
