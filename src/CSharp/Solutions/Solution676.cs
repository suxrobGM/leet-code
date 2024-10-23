using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution676
{
    /// <summary>
    /// 676. Implement Magic Dictionary - Medium
    /// <a href="https://leetcode.com/problems/implement-magic-dictionary">See the problem</a>
    /// </summary>
    public class MagicDictionary
    {
        private readonly HashSet<string> dict = [];

        public void BuildDict(string[] dictionary)
        {
            foreach (var word in dictionary)
            {
                dict.Add(word);
            }
        }

        public bool Search(string searchWord)
        {
            foreach (var word in dict)
            {
                if (word.Length == searchWord.Length && IsOneCharDiff(word, searchWord))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsOneCharDiff(string word, string searchWord)
        {
            int diffCount = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != searchWord[i])
                {
                    diffCount++;
                    if (diffCount > 1) return false;
                }
            }

            return diffCount == 1;
        }
    }
}
