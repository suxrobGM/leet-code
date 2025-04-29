using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1307
{
    private string[] words;
    private string result;
    private List<char> uniqueChars;
    private Dictionary<char, int> charToDigit;
    private bool[] usedDigits;

    /// <summar
    /// 1307. Verbal Arithmetic Puzzle - Hard
    /// <a href="https://leetcode.com/problems/verbal-arithmetic-puzzle">See the problem</a>
    /// </summary>
    public bool IsSolvable(string[] words, string result)
    {
        this.words = words;
        this.result = result;
        uniqueChars = [];
        charToDigit = [];
        usedDigits = new bool[10];

        var seen = new HashSet<char>();
        foreach (var word in words)
            foreach (var c in word)
                if (seen.Add(c))
                    uniqueChars.Add(c);

        foreach (var c in result)
            if (seen.Add(c))
                uniqueChars.Add(c);

        if (uniqueChars.Count > 10)
            return false; // can't map more than 10 different letters to digits

        return Dfs(0);
    }

    private bool Dfs(int pos)
    {
        if (pos == uniqueChars.Count)
            return Check();

        for (int d = 0; d <= 9; d++)
        {
            if (usedDigits[d])
                continue;

            char c = uniqueChars[pos];

            // No leading zero
            if (d == 0 && IsLeadingChar(c))
                continue;

            usedDigits[d] = true;
            charToDigit[c] = d;

            if (Dfs(pos + 1))
                return true;

            usedDigits[d] = false;
            charToDigit.Remove(c);
        }

        return false;
    }

    private bool IsLeadingChar(char c)
    {
        foreach (var word in words)
            if (word[0] == c && word.Length > 1)
                return true;

        if (result[0] == c && result.Length > 1)
            return true;

        return false;
    }

    private bool Check()
    {
        long sum = 0;
        foreach (var word in words)
        {
            long val = WordToNumber(word);
            if (val == -1) return false; // leading zero
            sum += val;
        }

        long resultVal = WordToNumber(result);
        if (resultVal == -1) return false;

        return sum == resultVal;
    }

    private long WordToNumber(string word)
    {
        if (word.Length > 1 && charToDigit[word[0]] == 0)
            return -1; // invalid leading zero

        long val = 0;
        foreach (var c in word)
        {
            val = val * 10 + charToDigit[c];
        }
        return val;
    }
}
