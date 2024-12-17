using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution906
{
    /// <summary>
    /// 906. Super Palindromes - Hard
    /// <a href="https://leetcode.com/problems/super-palindromes">See the problem</a>
    /// </summary>
    public int SuperpalindromesInRange(string left, string right)
    {
        long L = long.Parse(left);
        long R = long.Parse(right);
        var superPalindromes = new List<long>();

        // Generate palindromes up to 10^9 as base numbers
        for (long i = 1; i <= 100000; i++)
        {
            GeneratePalindrome(i, superPalindromes);
        }

        // Count valid super-palindromes within the range
        int count = 0;
        foreach (long sp in superPalindromes)
        {
            if (sp >= L && sp <= R)
            {
                count++;
            }
        }
        return count;
    }

    private void GeneratePalindrome(long num, List<long> superPalindromes)
    {
        // Generate odd-length palindrome
        string odd = num.ToString() + Reverse(num.ToString().Substring(0, num.ToString().Length - 1));
        CheckAndAddPalindrome(odd, superPalindromes);

        // Generate even-length palindrome
        string even = num.ToString() + Reverse(num.ToString());
        CheckAndAddPalindrome(even, superPalindromes);
    }

    private void CheckAndAddPalindrome(string palindromeStr, List<long> superPalindromes)
    {
        long palindrome = long.Parse(palindromeStr);
        long square = palindrome * palindrome;
        if (IsPalindrome(square.ToString()))
        {
            superPalindromes.Add(square);
        }
    }

    private string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private bool IsPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (s[left++] != s[right--]) return false;
        }
        return true;
    }
}
