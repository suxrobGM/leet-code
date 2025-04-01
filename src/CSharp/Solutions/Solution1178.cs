using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1178
{
    /// <summary>
    /// 1178. Number of Valid Words for Each Puzzle - Hard
    /// <a href="https://leetcode.com/problems/number-of-valid-words-for-each-puzzle">See the problem</a>
    /// </summary>
    public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
    {
        var wordCount = new Dictionary<int, int>();
        foreach (var word in words)
        {
            int mask = 0;
            foreach (var c in word)
                mask |= 1 << (c - 'a');
            wordCount[mask] = wordCount.GetValueOrDefault(mask, 0) + 1;
        }

        var result = new List<int>();
        foreach (var puzzle in puzzles)
        {
            int firstCharMask = 1 << (puzzle[0] - 'a');
            int puzzleMask = 0;
            foreach (var c in puzzle)
                puzzleMask |= 1 << (c - 'a');

            int count = 0;
            for (int submask = puzzleMask; submask > 0; submask = (submask - 1) & puzzleMask)
            {
                if ((submask & firstCharMask) != 0 && wordCount.ContainsKey(submask))
                    count += wordCount[submask];
            }
            result.Add(count);
        }

        return result;
    }
}
