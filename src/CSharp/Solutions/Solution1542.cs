using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1542
{
    /// <summary>
    /// 1542. Find Longest Awesome Substring - Hard
    /// <a href="https://leetcode.com/problems/find-longest-awesome-substring">See the problem</a>
    /// </summary>
    public int LongestAwesome(string s)
    {
        int maxLength = 0;
        int mask = 0;
        Dictionary<int, int> firstOccurrence = new() { { 0, -1 } };

        for (int i = 0; i < s.Length; i++)
        {
            // Toggle the bit corresponding to the current digit
            mask ^= 1 << (s[i] - '0');

            // Check if this mask has been seen before
            if (firstOccurrence.TryGetValue(mask, out int firstIndex))
            {
                maxLength = Math.Max(maxLength, i - firstIndex);
            }
            else
            {
                firstOccurrence[mask] = i;
            }

            // Check for masks with one bit flipped (to allow for one odd digit)
            for (int j = 0; j < 10; j++)
            {
                int toggledMask = mask ^ (1 << j);
                if (firstOccurrence.TryGetValue(toggledMask, out firstIndex))
                {
                    maxLength = Math.Max(maxLength, i - firstIndex);
                }
            }
        }

        return maxLength;
    }
}
