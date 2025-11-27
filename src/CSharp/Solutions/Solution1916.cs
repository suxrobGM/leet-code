using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1916
{
    const long MOD = 1_000_000_007;

    /// <summary>
    /// 1916. Count Ways to Build Rooms in an Ant Colony - Hard
    /// <a href="https://leetcode.com/problems/count-ways-to-build-rooms-in-an-ant-colony">See the problem</a>
    /// </summary>
    public int WaysToBuildRooms(int[] prevRoom)
    {
        int n = prevRoom.Length;

        // Build tree: children list for each node
        var children = new List<int>[n];
        for (int i = 0; i < n; i++)
            children[i] = new List<int>();

        for (int i = 1; i < n; i++)
        {
            int parent = prevRoom[i];
            children[parent].Add(i);
        }

        // Precompute factorials and inverse factorials
        long[] fact = new long[n + 1];
        long[] invFact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
            fact[i] = fact[i - 1] * i % MOD;

        invFact[n] = ModPow(fact[n], MOD - 2);
        for (int i = n - 1; i >= 0; i--)
            invFact[i] = invFact[i + 1] * (i + 1) % MOD;

        // Postorder traversal (iterative) to process children before parent
        var stack = new Stack<int>();
        var order = new List<int>();
        stack.Push(0);

        while (stack.Count > 0)
        {
            int u = stack.Pop();
            order.Add(u);
            foreach (int v in children[u])
                stack.Push(v);
        }

        order.Reverse(); // Now children appear before their parent

        long[] ways = new long[n]; // ways[u]: ways to build subtree rooted at u
        int[] size = new int[n];   // size[u]: number of nodes in subtree rooted at u

        foreach (int u in order)
        {
            long w = 1;
            int sumChildrenSize = 0;

            // Multiply ways of children and accumulate their sizes
            foreach (int v in children[u])
            {
                w = w * ways[v] % MOD;
                sumChildrenSize += size[v];
            }

            // Interleave children subtrees: multinomial coefficient
            // (sumChildrenSize)! / Π (size[child])!
            w = w * fact[sumChildrenSize] % MOD;
            foreach (int v in children[u])
            {
                w = w * invFact[size[v]] % MOD;
            }

            ways[u] = w;
            size[u] = sumChildrenSize + 1; // include node u itself
        }

        return (int)ways[0];
    }

    private long ModPow(long baseVal, long exp)
    {
        long result = 1;
        long x = baseVal % MOD;

        while (exp > 0)
        {
            if ((exp & 1) == 1)
                result = result * x % MOD;

            x = x * x % MOD;
            exp >>= 1;
        }

        return result;
    }
}
