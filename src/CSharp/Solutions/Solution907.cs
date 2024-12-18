using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution907
{
    /// <summary>
    /// 907. Sum of Subarray Minimums - Medium
    /// <a href="https://leetcode.com/problems/sum-of-subarray-minimums">See the problem</a>
    /// </summary>
    public int SumSubarrayMins(int[] arr)
    {
        var n = arr.Length;
        var left = new int[n];
        var right = new int[n];
        var stack = new Stack<int[]>();

        // Calculate left
        for (int i = 0; i < n; i++)
        {
            int count = 1;
            while (stack.Count > 0 && stack.Peek()[0] > arr[i])
            {
                count += stack.Pop()[1];
            }
            stack.Push(new int[] { arr[i], count });
            left[i] = count;
        }

        // Clear the stack
        stack.Clear();

        // Calculate right
        for (int i = n - 1; i >= 0; i--)
        {
            int count = 1;
            while (stack.Count > 0 && stack.Peek()[0] >= arr[i])
            {
                count += stack.Pop()[1];
            }
            stack.Push(new int[] { arr[i], count });
            right[i] = count;
        }

        // Calculate the result
        long result = 0;
        for (int i = 0; i < n; i++)
        {
            result += (long)arr[i] * left[i] * right[i];
        }
        return (int)(result % 1000000007);
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
