namespace LeetCode.Solutions;

public class Solution2262
{
    /// <summary>
    /// 2262. Total Appeal of A String - Hard
    /// <a href="https://leetcode.com/problems/total-appeal-of-a-string">See the problem</a>
    /// </summary>
    public long AppealSum(string s)
    {
        var lastSeen = new int[26];
        Array.Fill(lastSeen, -1);

        long total = 0;
        long current = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var index = s[i] - 'a';

            // Substrings ending at i gain one appeal point for every start
            // after the previous occurrence of this character.
            current += i - lastSeen[index];
            lastSeen[index] = i;
            total += current;
        }

        return total;
    }
}
