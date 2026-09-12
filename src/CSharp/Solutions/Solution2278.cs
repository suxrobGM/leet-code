namespace LeetCode.Solutions;

public class Solution2278
{
    /// <summary>
    /// 2278. Percentage of Letter in String - Easy
    /// <a href="https://leetcode.com/problems/percentage-of-letter-in-string">See the problem</a>
    /// </summary>
    public int PercentageLetter(string s, char letter)
    {
        var letterCount = 0;

        foreach (var c in s)
        {
            if (c == letter)
            {
                letterCount++;
            }
        }

        return (int)((double)letterCount / s.Length * 100);
    }
}
