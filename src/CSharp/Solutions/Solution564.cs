using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution564
{
    /// <summary>
    /// 564. Find the Closest Palindrome - Hard
    /// <a href="https://leetcode.com/problems/find-the-closest-palindrome">See the problem</a>
    /// </summary>
    public string NearestPalindromic(string n)
    {
        long num = long.Parse(n);
        int len = n.Length;

        // Edge cases for small numbers
        if (num <= 10) return (num - 1).ToString();
        if (num == 11) return "9";

        // Special cases for numbers like 100..000 or 999..999
        long lowerBound = (long)Math.Pow(10, len - 1) - 1; // 999...999 for input like 1000
        long upperBound = (long)Math.Pow(10, len) + 1;     // 100...001 for input like 999

        // Create candidates by mirroring and changing the first half
        List<long> candidates = new List<long>();
        candidates.Add(lowerBound);  // Add lower boundary candidate
        candidates.Add(upperBound);  // Add upper boundary candidate

        // Add candidate by mirroring the first half
        long firstHalf = long.Parse(n.Substring(0, (len + 1) / 2)); // Get the first half
        candidates.Add(MakePalindrome(firstHalf, len));            // Mirror the first half as is
        candidates.Add(MakePalindrome(firstHalf + 1, len));        // Mirror first half + 1
        candidates.Add(MakePalindrome(firstHalf - 1, len));        // Mirror first half - 1

        // Find the closest palindrome
        long closest = -1;
        foreach (long candidate in candidates)
        {
            if (candidate != num)
            {
                if (closest == -1 || Math.Abs(candidate - num) < Math.Abs(closest - num) ||
                    (Math.Abs(candidate - num) == Math.Abs(closest - num) && candidate < closest))
                {
                    closest = candidate;
                }
            }
        }

        return closest.ToString();
    }

    // Function to mirror the first half to create a palindrome
    private long MakePalindrome(long firstHalf, int len)
    {
        string firstHalfStr = firstHalf.ToString();
        string secondHalfStr = new string(firstHalfStr.Substring(0, len / 2).ToCharArray());
        char[] secondHalfArr = secondHalfStr.ToCharArray();
        Array.Reverse(secondHalfArr);
        secondHalfStr = new string(secondHalfArr);
        return long.Parse(firstHalfStr + secondHalfStr);
    }
}
