using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution943
{
    /// <summary>
    /// 943. Find the Shortest Superstring - Hard
    /// <a href="https://leetcode.com/problems/find-the-shortest-superstring">See the problem</a>
    /// </summary>
    public string ShortestSuperstring(string[] words)
    {
        int n = words.Length;

        // Step 1: Precompute pairwise overlaps
        var overlap = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    overlap[i, j] = ComputeOverlap(words[i], words[j]);
                }
            }
        }

        // Step 2: Initialize DP table
        var dp = new int[1 << n, n];
        var parent = new int[1 << n, n];
        for (int mask = 0; mask < (1 << n); mask++)
        {
            for (int i = 0; i < n; i++)
            {
                dp[mask, i] = int.MaxValue; // Initialize to a large value
                parent[mask, i] = -1;
            }
        }

        // Base case: Starting with each word
        for (int i = 0; i < n; i++)
        {
            dp[1 << i, i] = words[i].Length;
        }

        // Step 3: Fill DP table
        for (int mask = 1; mask < (1 << n); mask++)
        {
            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) > 0)
                { // If i is in the current subset
                    for (int j = 0; j < n; j++)
                    {
                        if ((mask & (1 << j)) == 0)
                        { // If j is not in the subset
                            int nextMask = mask | (1 << j);
                            int val = dp[mask, i] + words[j].Length - overlap[i, j];
                            if (val < dp[nextMask, j])
                            {
                                dp[nextMask, j] = val;
                                parent[nextMask, j] = i;
                            }
                        }
                    }
                }
            }
        }

        // Step 4: Reconstruct the superstring
        int bestLength = int.MaxValue;
        int lastWord = -1;
        int finalMask = (1 << n) - 1;

        for (int i = 0; i < n; i++)
        {
            if (dp[finalMask, i] < bestLength)
            {
                bestLength = dp[finalMask, i];
                lastWord = i;
            }
        }

        // Build the result using parent array
        var result = ReconstructSuperstring(words, parent, overlap, lastWord, finalMask);
        return result;
    }

    private int ComputeOverlap(string a, string b)
    {
        int maxOverlap = 0;
        for (int len = 1; len <= Math.Min(a.Length, b.Length); len++)
        {
            if (a.Substring(a.Length - len).Equals(b.Substring(0, len)))
            {
                maxOverlap = len;
            }
        }
        return maxOverlap;
    }

    private string ReconstructSuperstring(string[] words, int[,] parent, int[,] overlap, int lastWord, int finalMask)
    {
        var result = new List<string>();
        int mask = finalMask;
        int curWord = lastWord;

        while (curWord != -1)
        {
            int prevWord = parent[mask, curWord];
            if (prevWord == -1)
            {
                result.Insert(0, words[curWord]);
            }
            else
            {
                int len = overlap[prevWord, curWord];
                result.Insert(0, words[curWord].Substring(len));
            }
            mask ^= (1 << curWord);
            curWord = prevWord;
        }

        return string.Join("", result);
    }
}
