using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1649
{
    const int MOD = 1_000_000_007;
    const int MAX = 100_001; // Since instructions[i] <= 1e5

    /// <summary>
    /// 1649. Create Sorted Array through Instructions - Hard
    /// <a href="https://leetcode.com/problems/create-sorted-array-through-instructions">See the problem</a>
    /// </summary>
    public int CreateSortedArray(int[] instructions)
    {
        var bit = new FenwickTree(MAX);
        long cost = 0;

        for (int i = 0; i < instructions.Length; i++)
        {
            int x = instructions[i];
            int less = bit.Query(x - 1);
            int greater = i - bit.Query(x);
            cost = (cost + Math.Min(less, greater)) % MOD;
            bit.Update(x, 1);
        }

        return (int)cost;
    }

    class FenwickTree
    {
        private readonly int[] tree;
        private readonly int size;

        public FenwickTree(int size)
        {
            this.size = size;
            tree = new int[size + 2];
        }

        public void Update(int index, int delta)
        {
            while (index < tree.Length)
            {
                tree[index] += delta;
                index += index & -index;
            }
        }

        public int Query(int index)
        {
            int sum = 0;
            while (index > 0)
            {
                sum += tree[index];
                index -= index & -index;
            }
            return sum;
        }
    }
}
