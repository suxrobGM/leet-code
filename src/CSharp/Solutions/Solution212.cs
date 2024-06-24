namespace LeetCode.Solutions;

public class Solution212
{
    /// <summary>
    /// 212. Word Search II - Hard
    /// <a href="https://leetcode.com/problems/word-search-ii">See the problem</a>
    /// </summary>
    public IList<string> FindWords(char[][] board, string[] words) 
    {
        var result = new List<string>();
        var trie = new Trie();
        
        foreach (var word in words)
        {
            trie.Insert(word);
        }
        
        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[0].Length; j++)
            {
                DFS(board, i, j, trie.Root, result);
            }
        }
        
        return result;
    }

    private void DFS(char[][] board, int i, int j, TrieNode node, List<string> result)
    {
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length)
        {
            return;
        }
        
        var c = board[i][j];
        if (c == '#' || !node.Children.ContainsKey(c))
        {
            return;
        }
        
        node = node.Children[c];
        if (node.Word != null)
        {
            result.Add(node.Word);
            node.Word = null;
        }
        
        board[i][j] = '#';
        DFS(board, i + 1, j, node, result);
        DFS(board, i - 1, j, node, result);
        DFS(board, i, j + 1, node, result);
        DFS(board, i, j - 1, node, result);
        board[i][j] = c;
    }

    public class Trie
    {
        public TrieNode Root { get; } = new();

        public void Insert(string word)
        {
            var node = Root;
            foreach (var c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.Word = word;
        }
    }

    public class TrieNode
    {
        public string Word { get; set; }
        public Dictionary<char, TrieNode> Children { get; } = [];
    }
}
