using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1032
{
    /// <summary>
    /// 1032. Stream of Characters - Hard
    /// <a href="https://leetcode.com/problems/stream-of-characters</a>
    /// </summary>
    public class StreamChecker
    {
        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children = [];
            public bool IsEnd = false;
        }

        private TrieNode root;
        private Queue<char> stream;
        private int maxWordLength;

        public StreamChecker(string[] words)
        {
            root = new TrieNode();
            stream = new Queue<char>();
            maxWordLength = 0;

            // Insert words in reverse order into Trie
            foreach (var word in words)
            {
                InsertWord(word);
                maxWordLength = Math.Max(maxWordLength, word.Length);
            }
        }

        private void InsertWord(string word)
        {
            TrieNode node = root;
            for (int i = word.Length - 1; i >= 0; i--) // Reverse insert
            {
                char c = word[i];
                if (!node.Children.ContainsKey(c))
                    node.Children[c] = new TrieNode();

                node = node.Children[c];
            }
            node.IsEnd = true; // Mark end of word
        }

        public bool Query(char letter)
        {
            stream.Enqueue(letter);
            if (stream.Count > maxWordLength)
                stream.Dequeue(); // Maintain only last maxWordLength chars

            TrieNode node = root;
            var streamArray = stream.ToArray();

            // Traverse the Trie using the recent characters (from latest to oldest)
            for (int i = streamArray.Length - 1; i >= 0; i--)
            {
                char c = streamArray[i];
                if (!node.Children.ContainsKey(c)) return false; // No match

                node = node.Children[c];
                if (node.IsEnd) return true; // Found a valid word
            }

            return false;
        }
    }
}
