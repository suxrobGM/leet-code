using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1521
{
    /// <summary>
    /// 1521. Find a Value of a Mysterious Function Closest to Target - Hard
    /// <a href="https://leetcode.com/problems/find-a-value-of-a-mysterious-function-closest-to-target">See the problem</a>
    /// </summary>
    public int ClosestToTarget(int[] arr, int target)
    {
        var root = new TrieNode();
        Insert(root, 0); // prefix[0] = 0

        int prefix = 0;
        int result = int.MaxValue;

        foreach (int num in arr)
        {
            prefix ^= num;
            int closest = Query(root, prefix ^ target);
            result = Math.Min(result, Math.Abs((prefix ^ closest) - target));
            Insert(root, prefix);
        }

        return result;
    }

    class TrieNode
    {
        public TrieNode[] children = new TrieNode[2];
    }

    void Insert(TrieNode root, int num)
    {
        TrieNode node = root;
        for (int i = 20; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.children[bit] == null)
                node.children[bit] = new TrieNode();
            node = node.children[bit];
        }
    }

    int Query(TrieNode root, int num)
    {
        TrieNode node = root;
        int result = 0;
        for (int i = 20; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            if (node.children[bit] != null)
            {
                node = node.children[bit];
            }
            else
            {
                bit ^= 1;
                node = node.children[bit];
                result |= (1 << i);
            }
        }
        return result;
    }
}
