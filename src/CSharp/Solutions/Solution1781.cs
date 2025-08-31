using System.Text;

namespace LeetCode.Solutions;

public class Solution1781
{
    /// <summary>
    /// 1781. Sum of Beauty of All Substrings - Medium
    /// <a href="https://leetcode.com/problems/sum-of-beauty-of-all-substrings">See the problem</a>
    /// </summary>
    public int BeautySum(string s)
    {
        int totalBeauty = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int[] freq = new int[26];
            int maxFreq = 0;
            int minFreq = int.MaxValue;
            for (int j = i; j < s.Length; j++)
            {
                freq[s[j] - 'a']++;
                maxFreq = Math.Max(maxFreq, freq[s[j] - 'a']);
                minFreq = Math.Min(minFreq, freq[s[j] - 'a']);
                if (minFreq != 0)
                {
                    totalBeauty += maxFreq - minFreq;
                }
            }
        }
        return totalBeauty;
    }
}
