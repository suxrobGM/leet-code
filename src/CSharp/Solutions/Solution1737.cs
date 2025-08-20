using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1737
{
    const int MOD = 1_000_000_007;

    /// <summary>
    /// 1737. Change Minimum Characters to Satisfy One of Three Conditions - Medium
    /// <a href="https://leetcode.com/problems/change-minimum-characters-to-satisfy-one-of-three-conditions">See the problem</a>
    /// </summary>
    public int MinCharacters(string a, string b)
    {
        int nA = a.Length, nB = b.Length;

        int[] cntA = new int[26];
        int[] cntB = new int[26];

        foreach (char ch in a) cntA[ch - 'a']++;
        foreach (char ch in b) cntB[ch - 'a']++;

        // Prefix sums
        int[] preA = new int[26];
        int[] preB = new int[26];
        preA[0] = cntA[0]; preB[0] = cntB[0];
        for (int i = 1; i < 26; i++)
        {
            preA[i] = preA[i - 1] + cntA[i];
            preB[i] = preB[i - 1] + cntB[i];
        }

        int ans = int.MaxValue;

        // Condition 1: all(a) < all(b)
        for (int t = 1; t < 26; t++)
        {
            int changeA = nA - preA[t - 1]; // A letters >= t
            int changeB = preB[t - 1];      // B letters <  t
            ans = Math.Min(ans, changeA + changeB);
        }

        // Condition 2: all(b) < all(a)
        for (int t = 1; t < 26; t++)
        {
            int changeB = nB - preB[t - 1]; // B letters >= t
            int changeA = preA[t - 1];      // A letters <  t
            ans = Math.Min(ans, changeA + changeB);
        }

        // Condition 3: both become a single letter
        for (int L = 0; L < 26; L++)
        {
            int ops = (nA - cntA[L]) + (nB - cntB[L]);
            ans = Math.Min(ans, ops);
        }

        return ans;
    }
}

