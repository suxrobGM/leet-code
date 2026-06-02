namespace LeetCode.Solutions;

public class Solution2157
{
    /// <summary>
    /// 2157. Groups of Strings - Hard
    /// <a href="https://leetcode.com/problems/groups-of-strings">See the problem</a>
    /// </summary>
    public int[] GroupStrings(string[] words)
    {
        int n = words.Length;
        int[] parent = new int[n];
        int[] size = new int[n];
        for (int i = 0; i < n; i++) { parent[i] = i; size[i] = 1; }

        int Find(int x)
        {
            while (parent[x] != x) { parent[x] = parent[parent[x]]; x = parent[x]; }
            return x;
        }
        void Union(int a, int b)
        {
            a = Find(a); b = Find(b);
            if (a == b) return;
            if (size[a] < size[b]) (a, b) = (b, a);
            parent[b] = a;
            size[a] += size[b];
        }

        var first = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            int mask = 0;
            foreach (char c in words[i]) mask |= 1 << (c - 'a');
            if (first.TryGetValue(mask, out int j)) Union(i, j);
            else first[mask] = i;
        }

        foreach (var kv in first)
        {
            int mask = kv.Key, idx = kv.Value;
            for (int b = 0; b < 26; b++)
            {
                int nm = mask ^ (1 << b);
                if (first.TryGetValue(nm, out int j)) Union(idx, j);
            }
            for (int i = 0; i < 26; i++)
            {
                if ((mask & (1 << i)) == 0) continue;
                for (int j = 0; j < 26; j++)
                {
                    if ((mask & (1 << j)) != 0) continue;
                    int nm = mask ^ (1 << i) ^ (1 << j);
                    if (first.TryGetValue(nm, out int kk)) Union(idx, kk);
                }
            }
        }

        int groups = 0, largest = 0;
        for (int i = 0; i < n; i++)
        {
            if (parent[i] == i)
            {
                groups++;
                largest = Math.Max(largest, size[i]);
            }
        }
        return [groups, largest];
    }
}
