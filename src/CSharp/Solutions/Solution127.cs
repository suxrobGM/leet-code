namespace LeetCode.Solutions;

public class Solution127
{
    /// <summary>
    /// 127. Word Ladder - Hard
    /// <a href="https://leetcode.com/problems/word-ladder">See the problem</a>
    /// </summary>
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord))
        {
            return 0;
        }

        var queue = new Queue<string>();
        queue.Enqueue(beginWord);

        var visited = new HashSet<string>
        {
            beginWord
        };

        var level = 1;

        // BFS
        while (queue.Count > 0)
        {
            var size = queue.Count;

            for (var i = 0; i < size; i++)
            {
                var currentWord = queue.Dequeue();

                if (currentWord == endWord)
                {
                    return level;
                }

                var charArray = currentWord.ToCharArray();

                for (var j = 0; j < charArray.Length; j++)
                {
                    var originalChar = charArray[j];

                    for (var k = 0; k < 26; k++)
                    {
                        charArray[j] = (char)('a' + k);
                        var newWord = new string(charArray);

                        if (wordSet.Contains(newWord) && visited.Add(newWord))
                        {
                            queue.Enqueue(newWord);
                        }
                    }

                    charArray[j] = originalChar;
                }
            }

            level++;
        }

        return 0;
    }
}
