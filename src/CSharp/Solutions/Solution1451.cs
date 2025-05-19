using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1451
{
    /// <summary>
    /// 1451. Rearrange Words in a Sentence - Medium
    /// <a href="https://leetcode.com/problems/rearrange-words-in-a-sentence">See the problem</a>
    /// </summary>
    public string ArrangeWords(string text)
    {
        // Step 1: Convert first letter to lowercase for uniform sorting
        text = char.ToLower(text[0]) + text.Substring(1);

        // Step 2: Split and sort words by length (stable)
        var words = text.Split(' ');
        var sorted = words.OrderBy(w => w.Length).ToArray();

        // Step 3: Capitalize the first word, rest lowercase
        sorted[0] = char.ToUpper(sorted[0][0]) + sorted[0].Substring(1);

        return string.Join(" ", sorted);
    }
}
