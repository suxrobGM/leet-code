namespace LeetCode.Solutions;

public class Solution126
{
    /// <summary>
    /// 126. Word Ladder II - Hard
    /// <a href="https://leetcode.com/problems/word-ladder-ii">See the problem</a>
    /// </summary>
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        var wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord))
        {
            return new List<IList<string>>();
        }

        var beginSet = new HashSet<string> { beginWord };
        var endSet = new HashSet<string> { endWord };
        var children = new Dictionary<string, List<string>>();
        var found = BidirectionalBFS(beginSet, endSet, wordSet, children, true);

        IList<IList<string>> result = new List<IList<string>>();
        if (found)
        {
            var path = new List<string> { beginWord };
            Backtrack(beginWord, endWord, children, path, result);
        }
        return result;
    }
    
    private bool BidirectionalBFS(HashSet<string> beginSet, HashSet<string> endSet, HashSet<string> wordSet,
                                  Dictionary<string, List<string>> children, bool forward)
    {
        if (beginSet.Count == 0)
        {
            return false;
        }

        if (beginSet.Count > endSet.Count)
        {
            return BidirectionalBFS(endSet, beginSet, wordSet, children, !forward);
        }

        var nextLevel = new HashSet<string>();
        foreach (var word in beginSet)
        {
            wordSet.Remove(word);
        }
        foreach (var word in endSet)
        {
            wordSet.Remove(word);
        }

        var found = false;
        foreach (var word in beginSet)
        {
            var wordArray = word.ToCharArray();
            for (var i = 0; i < wordArray.Length; i++)
            {
                var originalChar = wordArray[i];
                for (var c = 'a'; c <= 'z'; c++)
                {
                    wordArray[i] = c;
                    var newWord = new string(wordArray);

                    if (!wordSet.Contains(newWord))
                    {
                        continue;
                    }

                    if (endSet.Contains(newWord))
                    {
                        found = true;
                    }
                    else
                    {
                        nextLevel.Add(newWord);
                    }

                    var key = forward ? word : newWord;
                    var value = forward ? newWord : word;

                    if (!children.ContainsKey(key))
                    {
                        children[key] = new List<string>();
                    }
                    children[key].Add(value);
                }
                wordArray[i] = originalChar;
            }
        }

        if (found)
        {
            return true;
        }

        return BidirectionalBFS(nextLevel, endSet, wordSet, children, forward);
    }

    private void Backtrack(string beginWord, string endWord, Dictionary<string, List<string>> children,
                           List<string> path, IList<IList<string>> result)
    {
        if (beginWord == endWord)
        {
            result.Add(new List<string>(path));
            return;
        }

        if (!children.ContainsKey(beginWord))
        {
            return;
        }

        foreach (var child in children[beginWord])
        {
            path.Add(child);
            Backtrack(child, endWord, children, path, result);
            path.RemoveAt(path.Count - 1);
        }
    }
}
