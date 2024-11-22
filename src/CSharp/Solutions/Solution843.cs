using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution843
{
    /// <summary>
    /// 843. Guess the Word - Hard
    /// <a href="https://leetcode.com/problems/guess-the-word">See the problem</a>
    /// </summary>
    public void FindSecretWord(string[] words, Master master)
    {
        int n = words.Length;

        // Function to calculate the number of exact matches between two words
        int Match(string word1, string word2)
        {
            int matches = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] == word2[i])
                {
                    matches++;
                }
            }
            return matches;
        }

        var candidates = new List<string>(words);

        for (int attempts = 0; attempts < 10; attempts++)
        {
            // Choose a random word (or apply heuristics for better selection)
            var guess = candidates[new Random().Next(candidates.Count)];

            // Call Master.guess and get feedback
            var matches = master.Guess(guess);

            if (matches == 6)
            {
                return; // Found the secret word
            }

            // Filter candidates based on feedback
            var nextCandidates = new List<string>();
            foreach (string word in candidates)
            {
                if (Match(word, guess) == matches)
                {
                    nextCandidates.Add(word);
                }
            }

            candidates = nextCandidates;
        }
    }

    public class Master
    {
        public int Guess(string word)
        {
            return 0;
        }
    }
}
