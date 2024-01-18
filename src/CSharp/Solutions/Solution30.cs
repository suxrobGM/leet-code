namespace LeetCode.Solutions;

public class Solution30
{
    /// <summary>
    /// 30. Substring with Concatenation of All Words
    /// <a href="https://leetcode.com/problems/substring-with-concatenation-of-all-words/">See the problem</a>
    /// </summary>
    public IList<int> FindSubstring(string s, string[] words)
    {
        var result = new List<int>();
        
        if (string.IsNullOrEmpty(s) || words.Length == 0) 
        {
            return result;
        }

        var wordLength = words[0].Length;
        var wordCount = new Dictionary<string, int>();

        // Build the word count hash map
        foreach (var word in words)
        {
            wordCount.TryAdd(word, 0);
            wordCount[word]++;
        }

        // Iterate over each possible starting position in the string s
        // (up to the length of a single word)
        for (var i = 0; i < wordLength; i++) 
        {
            int left = i, right = i, count = 0;
            var seenWords = new Dictionary<string, int>();

            // Sliding window: move 'right' pointer to check each word
            while (right + wordLength <= s.Length) 
            {
                var word = s.Substring(right, wordLength);
                right += wordLength;

                // Check if the word is part of the given words
                if (wordCount.ContainsKey(word)) 
                {
                    seenWords.TryAdd(word, 0);
                    seenWords[word]++;

                    // If the current word has not exceeded its count in wordCount
                    if (seenWords[word] <= wordCount[word]) 
                    {
                        count++;
                    } 
                    else 
                    {
                        // Move 'left' pointer to decrease the count of 'leftWord'
                        while (seenWords[word] > wordCount[word]) 
                        {
                            var leftWord = s.Substring(left, wordLength);
                            seenWords[leftWord]--;
                            if (seenWords[leftWord] < wordCount[leftWord]) 
                            {
                                count--;
                            }
                            left += wordLength;
                        }
                    }

                    // If all words match, add the start index to the result
                    if (count == words.Length) 
                    {
                        result.Add(left);
                    }
                }
                else 
                {
                    // If word not found, reset seenWords and start after this word
                    seenWords.Clear();
                    count = 0;
                    left = right;
                }
            }
        }

        return result;
    }
}
