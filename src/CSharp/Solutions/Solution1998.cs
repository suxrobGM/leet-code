namespace LeetCode.Solutions;

public class Solution1998
{
    /// <summary>
    /// 1998. GCD Sort of an Array - Hard
    /// <a href="https://leetcode.com/problems/gcd-sort-of-an-array">See the problem</a>
    /// </summary>
    public bool GcdSort(int[] nums)
    {
        int n = nums.Length;
        int[] sorted = new int[n];
        Array.Copy(nums, sorted, n);
        Array.Sort(sorted);

        // Build Union-Find structure
        var uf = new UnionFind(n);

        // Map prime factors to positions that contain them
        var primeToPos = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            var primes = GetPrimeFactors(nums[i]);

            // Union positions that share prime factors
            foreach (int prime in primes)
            {
                if (primeToPos.ContainsKey(prime))
                {
                    uf.Union(i, primeToPos[prime]);
                }
                else
                {
                    primeToPos[prime] = i;
                }
            }
        }

        // Group positions by their root component
        var components = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            int root = uf.Find(i);
            if (!components.ContainsKey(root))
            {
                components[root] = new List<int>();
            }
            components[root].Add(i);
        }

        // Verify each component can be sorted correctly
        foreach (var positions in components.Values)
        {
            var values = new List<int>();
            var targets = new List<int>();

            foreach (int pos in positions)
            {
                values.Add(nums[pos]);
                targets.Add(sorted[pos]);
            }

            values.Sort();
            targets.Sort();

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] != targets[i])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private HashSet<int> GetPrimeFactors(int num)
    {
        var factors = new HashSet<int>();

        // Check for factor 2
        if (num % 2 == 0)
        {
            factors.Add(2);
            while (num % 2 == 0) num /= 2;
        }

        // Check odd factors up to sqrt(num)
        for (int i = 3; i * i <= num; i += 2)
        {
            if (num % i == 0)
            {
                factors.Add(i);
                while (num % i == 0) num /= i;
            }
        }

        // Remaining number is a prime factor
        if (num > 1) factors.Add(num);

        return factors;
    }

    class UnionFind
    {
        int[] parent;
        int[] rank;

        public UnionFind(int n)
        {
            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]); // Path compression
            }
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int px = Find(x);
            int py = Find(y);

            if (px == py) return;

            // Union by rank
            if (rank[px] < rank[py])
            {
                parent[px] = py;
            }
            else if (rank[px] > rank[py])
            {
                parent[py] = px;
            }
            else
            {
                parent[py] = px;
                rank[px]++;
            }
        }
    }
}
