using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution745
{
    /// <summary>
    /// 745. Prefix and Suffix Search - Hard
    /// <a href="https://leetcode.com/problems/prefix-and-suffix-search">See the problem</a>
    /// </summary>
    public class WordFilter
    {
        private TrieNode root;

        public WordFilter(string[] words)
        {
            root = new TrieNode();

            for (int index = 0; index < words.Length; index++)
            {
                var word = words[index];
                var len = word.Length;

                // Insert each possible prefix and suffix combination
                for (int i = 0; i <= len; i++)
                {
                    string prefix = word.Substring(0, i);
                    for (int j = 0; j <= len; j++)
                    {
                        string suffix = word.Substring(j);
                        string key = prefix + "#" + suffix;
                        Insert(key, index);
                    }
                }
            }
        }

        private void Insert(string word, int index)
        {
            var node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
                node.Indices.Add(index);  // Store the index at this node
            }
        }

        public int F(string pref, string suff)
        {
            var key = pref + "#" + suff;
            var node = root;

            // Traverse the Trie to find the node representing this prefix-suffix combination
            foreach (char c in key)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return -1;
                }
                node = node.Children[c];
            }

            // Return the largest index from the indices list
            return node.Indices.Count > 0 ? node.Indices[node.Indices.Count - 1] : -1;
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; } = [];
            public List<int> Indices { get; set; } = [];
        }
    }
}
