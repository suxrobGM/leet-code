using System.Text;

namespace LeetCode.Solutions;

public class Solution804
{
    /// <summary>
    /// 804. Unique Morse Code Words - Easy
    /// <a href="https://leetcode.com/problems/unique-morse-code-words">See the problem</a>
    /// </summary>
    public int UniqueMorseRepresentations(string[] words)
    {
        var morseCodes = new string[]
        {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..",
            "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-",
            "-.--", "--.."
        };

        var set = new HashSet<string>();

        foreach (var word in words)
        {
            var sb = new StringBuilder();

            foreach (var c in word)
            {
                sb.Append(morseCodes[c - 'a']);
            }

            set.Add(sb.ToString());
        }

        return set.Count;
    }
}
