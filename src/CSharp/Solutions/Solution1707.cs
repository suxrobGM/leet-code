using System.Text;


namespace LeetCode.Solutions;

public class Solution1707
{
    /// <summary>
    /// 1707. Maximum XOR With an Element From Array - Hard
    /// <a href="https://leetcode.com/problems/maximum-xor-with-an-element-from-array">See the problem</a>
    /// </summary>
    public int[] MaximizeXor(int[] nums, int[][] queries)
    {
        Array.Sort(nums);

        int q = queries.Length;
        var qs = new (int mi, int xi, int idx)[q];
        for (int i = 0; i < q; i++)
            qs[i] = (queries[i][1], queries[i][0], i);

        Array.Sort(qs, (a, b) => a.mi.CompareTo(b.mi));

        const int BITS = 31; // enough for values up to 1e9 (bits 30..0)

        // Preallocate trie for worst case: (#nums * BITS) + 1 root
        int maxNodes = nums.Length * BITS + 5;
        var next0 = new int[maxNodes];
        var next1 = new int[maxNodes];
        Array.Fill(next0, -1);
        Array.Fill(next1, -1);
        int nodes = 1;  // node 0 is root

        int Insert(int val)
        {
            int cur = 0;
            for (int b = BITS - 1; b >= 0; b--)
            {
                int bit = (val >> b) & 1;
                if (bit == 0)
                {
                    if (next0[cur] == -1)
                    {
                        next0[cur] = nodes;
                        next0[nodes] = -1;
                        next1[nodes] = -1;
                        nodes++;
                    }
                    cur = next0[cur];
                }
                else
                {
                    if (next1[cur] == -1)
                    {
                        next1[cur] = nodes;
                        next0[nodes] = -1;
                        next1[nodes] = -1;
                        nodes++;
                    }
                    cur = next1[cur];
                }
            }
            return cur;
        }

        int QueryMaxXor(int x)
        {
            int cur = 0, res = 0;
            for (int b = BITS - 1; b >= 0; b--)
            {
                int bit = (x >> b) & 1;
                // prefer opposite bit if it exists to maximize XOR
                if (bit == 0)
                {
                    if (next1[cur] != -1) { res |= (1 << b); cur = next1[cur]; }
                    else if (next0[cur] != -1) cur = next0[cur];
                    else return -1; // empty trie (shouldn't happen if guarded)
                }
                else
                {
                    if (next0[cur] != -1) { res |= (1 << b); cur = next0[cur]; }
                    else if (next1[cur] != -1) cur = next1[cur];
                    else return -1;
                }
            }
            return res;
        }

        var ans = new int[q];
        int iNums = 0;

        foreach (var (mi, xi, idx) in qs)
        {
            // insert all nums <= mi
            while (iNums < nums.Length && nums[iNums] <= mi)
            {
                Insert(nums[iNums]);
                iNums++;
            }

            ans[idx] = (iNums == 0) ? -1 : QueryMaxXor(xi);
        }

        return ans;
    }
}
