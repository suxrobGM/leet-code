using System.Text;


namespace LeetCode.Solutions;

public class Solution1684
{
    /// <summary>
    /// 1684. Count the Number of Consistent Strings - Easy
    /// <a href="https://leetcode.com/problems/count-the-number-of-consistent-strings">See the problem</a>
    /// </summary>
    public int CountConsistentStrings(string allowed, string[] words)
    {
        int allowedMask = 0;
        foreach (char c in allowed)
        {
            allowedMask |= 1 << (c - 'a');
        }

        int consistentCount = 0;
        foreach (string word in words)
        {
            int wordMask = 0;
            foreach (char c in word)
            {
                wordMask |= 1 << (c - 'a');
            }
            if ((wordMask & ~allowedMask) == 0)
            {
                consistentCount++;
            }
        }
        return consistentCount;
    }
}
