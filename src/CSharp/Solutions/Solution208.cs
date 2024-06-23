using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution208
{
    /// <summary>
    /// 208. Implement Trie (Prefix Tree) - Medium
    /// <a href="https://leetcode.com/problems/implement-trie-prefix-tree">See the problem</a>
    /// </summary>
    public class Trie 
    {
        private readonly TrieNode _root = new TrieNode();

        public void Insert(string word) 
        {
            var node = _root;
            
            foreach (var c in word)
            {
                var index = c - 'a';
                
                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }
                
                node = node.Children[index];
            }
            
            node.IsEnd = true;
        }
        
        public bool Search(string word) 
        {
            var node = _root;
            
            foreach (var c in word)
            {
                var index = c - 'a';
                
                if (node.Children[index] == null)
                {
                    return false;
                }
                
                node = node.Children[index];
            }
            
            return node.IsEnd;
        }
        
        public bool StartsWith(string prefix) 
        {
            var node = _root;
            
            foreach (var c in prefix)
            {
                var index = c - 'a';
                
                if (node.Children[index] == null)
                {
                    return false;
                }
                
                node = node.Children[index];
            }
            
            return true;
        }

        private class TrieNode 
        {
            public TrieNode[] Children { get; } = new TrieNode[26];
            public bool IsEnd { get; set; }
        }
    }
}
