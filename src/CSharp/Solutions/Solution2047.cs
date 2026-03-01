namespace LeetCode.Solutions;

public class Solution2047
{
    /// <summary>
    /// 2047. Number of Valid Words in a Sentence - Easy
    /// <a href="https://leetcode.com/problems/number-of-valid-words-in-a-sentence">See the problem</a>
    /// </summary>
    public int CountValidWords(string sentence)
    {
        var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var validCount = 0;

        foreach (var word in words)
        {
            if (IsValid(word))
                validCount++;
        }

        return validCount;
    }

    private bool IsValid(string word)
    {
        var hyphenCount = 0;
        for (var i = 0; i < word.Length; i++)
        {
            var c = word[i];
            if (char.IsDigit(c))
                return false;

            if (c == '-')
            {
                hyphenCount++;
                if (hyphenCount > 1 || i == 0 || i == word.Length - 1 || !char.IsLetter(word[i - 1]) || !char.IsLetter(word[i + 1]))
                    return false;
            }
            else if (c is '!' or '.' or ',')
            {
                if (i != word.Length - 1)
                    return false;
            }
            else if (!char.IsLetter(c))
                return false;
        }

        return true;
    }
}
