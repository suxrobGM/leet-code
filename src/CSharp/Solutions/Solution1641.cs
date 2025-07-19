using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1641
{
    /// <summary>
    /// 1641. Count Sorted Vowel Strings - Medium
    /// <a href="https://leetcode.com/problems/count-sorted-vowel-strings">See the problem</a>
    /// </summary>
    public int CountVowelStrings(int n)
    {
        return (int)Combination(n + 4, 4);
    }

    private long Combination(int n, int k)
    {
        long res = 1;
        for (int i = 1; i <= k; i++)
        {
            res = res * (n - i + 1) / i;
        }
        return res;
    }
}
