using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1505
{
    /// <summary>
    /// 1505. Minimum Possible Integer After at Most K Adjacent Swaps On Digits - Hard
    /// <a href="https://leetcode.com/problems/minimum-possible-integer-after-at-most-k-adjacent-swaps-on-digits">See the problem</a>
    /// </summary>
    public string MinInteger(string num, int k)
    {
        int n = num.Length;
        if (k <= 0 || n <= 1) return num;

        // Create a list of characters from the string
        var chars = num.ToCharArray();

        // Use a greedy approach to find the minimum possible integer
        for (int i = 0; i < n && k > 0; i++)
        {
            // Find the smallest digit within the range of k swaps
            int minIndex = i;
            for (int j = i + 1; j < n && j <= i + k; j++)
            {
                if (chars[j] < chars[minIndex])
                {
                    minIndex = j;
                }
            }

            // If we found a smaller digit, perform the swaps
            if (minIndex != i)
            {
                char temp = chars[minIndex];
                for (int j = minIndex; j > i; j--)
                {
                    chars[j] = chars[j - 1];
                }
                chars[i] = temp;

                // Reduce k by the number of swaps made
                k -= (minIndex - i);
            }
        }

        return new string(chars);
    }
}
