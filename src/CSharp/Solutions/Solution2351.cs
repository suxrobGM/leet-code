namespace LeetCode.Solutions;

public class Solution2351
{
    /// <summary>
    /// 2351. First Letter to Appear Twice - Easy
    /// <a href="https://leetcode.com/problems/first-letter-to-appear-twice">See the problem</a>
    /// </summary>
    public char RepeatedCharacter(string s)
    {
        var seen = new bool[26];

        foreach (char letter in s)
        {
            int index = letter - 'a';
            if (seen[index])
            {
                return letter;
            }

            seen[index] = true;
        }

        // The problem guarantees that at least one letter appears twice.
        return '\0';
    }
}
