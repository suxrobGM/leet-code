using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1177
{
    /// <summary>
    /// 1177. Can Make Palindrome from Substring - Medium
    /// <a href="https://leetcode.com/problems/prime-arrangements">See the problem</a>
    /// </summary>
    public IList<bool> CanMakePaliQueries(string s, int[][] queries)
    {
        int n = s.Length;
        var prefixCount = new int[n + 1][];
        for (int i = 0; i <= n; i++)
            prefixCount[i] = new int[26];

        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            for (int j = 0; j < 26; j++)
                prefixCount[i + 1][j] = prefixCount[i][j];
            prefixCount[i + 1][c - 'a']++;
        }

        var result = new List<bool>();
        foreach (var query in queries)
        {
            int left = query[0], right = query[1], k = query[2];
            int oddCount = 0;
            for (int j = 0; j < 26; j++)
            {
                if ((prefixCount[right + 1][j] - prefixCount[left][j]) % 2 == 1)
                    oddCount++;
            }
            result.Add(oddCount / 2 <= k);
        }

        return result;
    }
}
