using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1255
{
    /// <summary>
    /// 1255. Maximum Score Words Formed by Letters - Hard
    /// <a href="https://leetcode.com/problems/maximum-score-words-formed-by-letters">See the problem</a>
    /// </summary>
    public int MaxScoreWords(string[] words, char[] letters, int[] score)
    {
        var letterCount = new int[26];
        foreach (var letter in letters)
        {
            letterCount[letter - 'a']++;
        }

        return MaxScoreWordsHelper(words, letterCount, score, 0, 0);
    }

    private int MaxScoreWordsHelper(string[] words, int[] letterCount, int[] score, int index, int currentScore)
    {
        if (index == words.Length)
        {
            return currentScore;
        }

        // Skip the current word
        int maxScore = MaxScoreWordsHelper(words, letterCount, score, index + 1, currentScore);

        // Try to include the current word
        var word = words[index];
        var wordCount = new int[26];
        foreach (var c in word)
        {
            wordCount[c - 'a']++;
        }

        bool canInclude = true;
        for (int i = 0; i < 26; i++)
        {
            if (wordCount[i] > letterCount[i])
            {
                canInclude = false;
                break;
            }
        }

        if (canInclude)
        {
            for (int i = 0; i < 26; i++)
            {
                letterCount[i] -= wordCount[i];
            }

            maxScore = Math.Max(maxScore, MaxScoreWordsHelper(words, letterCount, score, index + 1, currentScore + CalculateWordScore(word, score)));

            for (int i = 0; i < 26; i++)
            {
                letterCount[i] += wordCount[i];
            }
        }

        return maxScore;
    }

    private int CalculateWordScore(string word, int[] score)
    {
        int totalScore = 0;
        foreach (var c in word)
        {
            totalScore += score[c - 'a'];
        }
        return totalScore;
    }
}
