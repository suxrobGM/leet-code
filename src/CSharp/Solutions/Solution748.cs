using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution748
{
    /// <summary>
    /// 748. Shortest Completing Word - Easy
    /// <a href="https://leetcode.com/problems/shortest-completing-word">See the problem</a>
    /// </summary>
    public string ShortestCompletingWord(string licensePlate, string[] words)
    {
        var licensePlateChars = licensePlate.ToLower().Where(char.IsLetter).ToArray();
        var licensePlateCharCount = new Dictionary<char, int>();

        foreach (var c in licensePlateChars)
        {
            if (licensePlateCharCount.ContainsKey(c))
            {
                licensePlateCharCount[c]++;
            }
            else
            {
                licensePlateCharCount[c] = 1;
            }
        }

        var shortestWord = string.Empty;
        var shortestWordLength = int.MaxValue;

        foreach (var word in words)
        {
            var wordCharCount = new Dictionary<char, int>();

            foreach (var c in word)
            {
                if (wordCharCount.ContainsKey(c))
                {
                    wordCharCount[c]++;
                }
                else
                {
                    wordCharCount[c] = 1;
                }
            }

            var isCompletingWord = true;

            foreach (var (key, value) in licensePlateCharCount)
            {
                if (!wordCharCount.ContainsKey(key) || wordCharCount[key] < value)
                {
                    isCompletingWord = false;
                    break;
                }
            }

            if (isCompletingWord && word.Length < shortestWordLength)
            {
                shortestWord = word;
                shortestWordLength = word.Length;
            }
        }

        return shortestWord;
    }
}
