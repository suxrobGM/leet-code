using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1745
{
    /// <summary>
    /// 1745. Palindrome Partitioning IV - Hard
    /// <a href="https://leetcode.com/problems/palindrome-partitioning-iv">See the problem</a>
    /// </summary>
    public bool CheckPartitioning(string s)
    {
        int n = s.Length;
        bool[,] isPal = new bool[n, n];

        // Precompute palindrome substrings
        for (int len = 1; len <= n; len++)
        {
            for (int i = 0; i + len - 1 < n; i++)
            {
                int j = i + len - 1;
                if (s[i] == s[j])
                {
                    if (len <= 2)
                    {
                        isPal[i, j] = true;
                    }
                    else
                    {
                        isPal[i, j] = isPal[i + 1, j - 1];
                    }
                }
            }
        }

        // Try all partitions into 3 palindromic substrings
        for (int i = 0; i < n - 2; i++)
        {
            if (!isPal[0, i]) continue;
            for (int j = i + 1; j < n - 1; j++)
            {
                if (isPal[i + 1, j] && isPal[j + 1, n - 1])
                {
                    return true;
                }
            }
        }

        return false;
    }
}

