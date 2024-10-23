using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution677
{
    /// <summary>
    /// 677. Map Sum Pairs - Medium
    /// <a href="https://leetcode.com/problems/map-sum-pairs">See the problem</a>
    /// </summary>
    public class MapSum
    {
        private TrieNode root = new();
        private Dictionary<string, int> map = [];

        /** Insert key-val pair into the Trie */
        public void Insert(string key, int val)
        {
            var delta = val;
            if (map.ContainsKey(key))
            {
                delta -= map[key]; // If key already exists, adjust by the old value
            }
            map[key] = val; // Update the key-value pair

            var node = root;
            foreach (var c in key)
            {
                if (!node.children.ContainsKey(c))
                {
                    node.children[c] = new();
                }
                node = node.children[c];
                node.value += delta;  // Update the cumulative sum for this node
            }
        }

        /** Returns the sum of all keys with the given prefix */
        public int Sum(string prefix)
        {
            var node = root;
            foreach (var c in prefix)
            {
                if (!node.children.ContainsKey(c))
                {
                    return 0;  // If the prefix doesn't exist, return 0
                }
                node = node.children[c];
            }
            return node.value;  // Return the cumulative sum for this prefix
        }

        // Trie Node structure
        class TrieNode
        {
            public Dictionary<char, TrieNode> children = [];
            public int value;  // Cumulative sum for this node
        }
    }
}
