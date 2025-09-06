using System.Text;

namespace LeetCode.Solutions;

public class Solution1803
{
    const int MAX_BIT = 15;

    /// <summary>
    /// 1803. Count Pairs With XOR in a Range - Hard
    /// <a href="https://leetcode.com/problems/count-pairs-with-xor-in-a-range">See the problem</a>
    /// </summary>
    public int CountPairs(int[] nums, int low, int high)
    {
        return (int)(CountUpTo(nums, high) - CountUpTo(nums, low - 1));
    }

    private long CountUpTo(int[] nums, int k)
    {
        if (k < 0) return 0;

        var root = new TrieNode();
        long total = 0;

        foreach (int num in nums)
        {
            total += Query(root, num, k);
            Insert(root, num);
        }

        return total;
    }

    private void Insert(TrieNode root, int num)
    {
        TrieNode node = root;
        for (int i = MAX_BIT; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.child[bit] == null) node.child[bit] = new TrieNode();
            node = node.child[bit];
            node.count++; // count numbers passing through this node
        }
    }

    private long Query(TrieNode root, int num, int k)
    {
        TrieNode node = root;
        long res = 0;

        for (int i = MAX_BIT; i >= 0; i--)
        {
            if (node == null) break;

            int nb = (num >> i) & 1; // bit of num
            int kb = (k >> i) & 1; // bit of k

            if (kb == 1)
            {
                // add all numbers in the branch where XOR bit = 0 (same bit as nb)
                TrieNode same = node.child[nb];
                if (same != null) res += same.count;

                // continue on the branch where XOR bit = 1 (opposite of nb)
                node = node.child[1 - nb];
            }
            else
            {
                // must keep XOR bit = 0 → stay on same bit branch
                node = node.child[nb];
            }
        }

        // include exact-prefix matches (needed when remaining K bits are zeros)
        if (node != null) res += node.count;

        return res;
    }

    private class TrieNode
    {
        public TrieNode[] child = new TrieNode[2];
        public int count = 0;
    }
}

