namespace LeetCode.Solutions;

public class Solution409
{
    /// <summary>
    /// 409. Longest Palindrome - Easy
    /// <a href="https://leetcode.com/problems/longest-palindrome">See the problem</a>
    /// </summary>
    public int LongestPalindrome(string s)
    {
        var dict = new Dictionary<char, int>();
        var length = 0;
        var hasOdd = false;

        foreach (var c in s)
        {
            if (dict.ContainsKey(c))
            {
                dict[c]++;
            }
            else
            {
                dict[c] = 1;
            }
        }

        foreach (var count in dict.Values)
        {
            if (count % 2 == 0)
            {
                length += count;
            }
            else
            {
                length += count - 1;
                hasOdd = true;
            }
        }

        return hasOdd ? length + 1 : length;
    }
}
