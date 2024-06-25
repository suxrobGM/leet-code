namespace LeetCode.Solutions;

public class Solution214
{
    /// <summary>
    /// 214. Shortest Palindrome - Hard
    /// <a href="https://leetcode.com/problems/shortest-palindrome">See the problem</a>
    /// </summary>
    public string ShortestPalindrome(string s)
    {
        var n = s.Length;
        var rev = new string(s.Reverse().ToArray()); // reversed s
        var newS = s + "#" + rev; // string containing s and reversed s separated by #
        var pi = new int[newS.Length]; // array of prefix function values
        
        for (var i = 1; i < newS.Length; i++)
        {
            var j = pi[i - 1]; // previous prefix function value

            // find the longest prefix of the string ending at i that is also a suffix
            while (j > 0 && newS[i] != newS[j])
            {
                j = pi[j - 1];
            }
            
            // if the next character is the same, increment the prefix function value
            if (newS[i] == newS[j])
            {
                j++;
            }
            
            // store the prefix function value
            pi[i] = j;
        }
        
        return rev.Substring(0, n - pi[newS.Length - 1]) + s; // add the missing characters to the beginning of s
    }
}
