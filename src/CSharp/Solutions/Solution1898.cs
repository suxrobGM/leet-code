using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1898
{
    /// <summary>
    /// 1898. Maximum Number of Removable Characters - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-removable-characters">See the problem</a>
    /// </summary>
    public int MaximumRemovals(string s, string p, int[] removable)
    {
        int left = 0, right = removable.Length;

        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;

            if (CanFormSubsequenceAfterRemovals(s, p, removable, mid))
            {
                left = mid;
            }
            else
            {
                right = mid - 1;
            }
        }

        return left;
    }

    private bool CanFormSubsequenceAfterRemovals(string s, string p, int[] removable, int k)
    {
        var removedIndices = new HashSet<int>();
        for (int i = 0; i < k; i++)
        {
            removedIndices.Add(removable[i]);
        }

        int pIndex = 0;
        for (int sIndex = 0; sIndex < s.Length; sIndex++)
        {
            if (removedIndices.Contains(sIndex))
                continue;

            if (s[sIndex] == p[pIndex])
            {
                pIndex++;
                if (pIndex == p.Length)
                    return true;
            }
        }

        return pIndex == p.Length;
    }
}
