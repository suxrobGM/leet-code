namespace LeetCode.Solutions;

public class Solution2273
{
    /// <summary>
    /// 2273. Find Resultant Array After Removing Anagrams - Easy
    /// <a href="https://leetcode.com/problems/find-resultant-array-after-removing-anagrams">See the problem</a>
    /// </summary>
    public IList<string> RemoveAnagrams(string[] words)
    {
        var result = new List<string>();
        int[]? previous = null;

        foreach (var word in words)
        {
            var counts = new int[26];

            foreach (var letter in word)
            {
                counts[letter - 'a']++;
            }

            if (previous is not null && counts.SequenceEqual(previous))
            {
                // Anagram of the word already kept, so it is deleted.
                continue;
            }

            result.Add(word);
            previous = counts;
        }

        return result;
    }
}
