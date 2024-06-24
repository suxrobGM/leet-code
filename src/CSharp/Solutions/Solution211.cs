namespace LeetCode.Solutions;

public class Solution211
{
    /// <summary>
    /// 211. Design Add and Search Words Data Structure - Medium
    /// <a href="https://leetcode.com/problems/design-add-and-search-words-data-structure">See the problem</a>
    /// </summary>
    public class WordDictionary 
    {
        private readonly TrieNode _root;

        public WordDictionary() 
        {
            _root = new TrieNode();
        }

        public void AddWord(string word) 
        {
            var node = _root;
            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.IsEnd = true;
        }

        public bool Search(string word) 
        {
            return Search(word, _root);
        }

        private bool Search(string word, TrieNode node) 
        {
            for (var i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (c == '.')
                {
                    foreach (var child in node.Children.Values)
                    {
                        if (Search(word[(i + 1)..], child))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                if (!node.Children.ContainsKey(c))
                {
                    return false;
                }
                node = node.Children[c];
            }
            return node.IsEnd;
        }

        /// <summary>
        /// Trie node, which contains children nodes and a flag to indicate the end of a word.
        /// </summary>
        private class TrieNode
        {
            /// <summary>
            /// Children nodes. The key is a character, and the value is a trie node.
            /// </summary>
            public Dictionary<char, TrieNode> Children { get; } = [];

            /// <summary>
            /// Indicates the end of a word.
            /// </summary>
            public bool IsEnd { get; set; }
        }
    }
}
