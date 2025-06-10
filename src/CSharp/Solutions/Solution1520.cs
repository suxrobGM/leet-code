using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1520
{
    /// <summary>
    /// 1520. Maximum Number of Non-Overlapping Substrings - Hard
    /// <a href="https://leetcode.com/problems/maximum-number-of-non-overlapping-substrings">See the problem</a>
    /// </summary>
    public IList<string> MaxNumOfSubstrings(string s)
    {
        int n = s.Length;
        int[] left = new int[26];
        int[] right = new int[26];

        // Initialize left and right boundaries for each character
        for (int i = 0; i < n; i++)
        {
            int idx = s[i] - 'a';
            if (left[idx] == 0) left[idx] = i + 1; // 1-based index
            right[idx] = i + 1; // 1-based index
        }

        // Adjust boundaries to ensure they cover the entire substring
        for (int i = 0; i < 26; i++)
        {
            if (left[i] > 0)
            {
                int l = left[i] - 1;
                int r = right[i] - 1;
                for (int j = l; j <= r; j++)
                {
                    int idx = s[j] - 'a';
                    left[i] = Math.Min(left[i], left[idx]);
                    right[i] = Math.Max(right[i], right[idx]);
                }
            }
        }

        // Collect valid substrings
        List<string> result = new();
        for (int i = 0; i < 26; i++)
        {
            if (left[i] > 0)
            {
                result.Add(s.Substring(left[i] - 1, right[i] - left[i] + 1));
            }
        }

        return result;
    }
}
