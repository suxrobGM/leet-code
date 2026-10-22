namespace LeetCode.Solutions;

public class Solution2325
{
    /// <summary>
    /// 2325. Decode the Message - Easy
    /// <a href="https://leetcode.com/problems/decode-the-message">See the problem</a>
    /// </summary>
    public string DecodeMessage(string key, string message)
    {
        var mapping = new char[26];
        var nextLetter = 'a';

        foreach (var letter in key)
        {
            if (letter != ' ' && mapping[letter - 'a'] == '\0')
            {
                mapping[letter - 'a'] = nextLetter++;
            }
        }

        var decoded = message.ToCharArray();
        for (var i = 0; i < decoded.Length; i++)
        {
            if (decoded[i] != ' ')
            {
                decoded[i] = mapping[decoded[i] - 'a'];
            }
        }

        return new string(decoded);
    }
}
