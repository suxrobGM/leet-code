namespace LeetCode.Solutions;

public class Solution2223
{
    /// <summary>
    /// 2223. Sum of Scores of Built Strings - Hard
    /// <a href="https://leetcode.com/problems/sum-of-scores-of-built-strings">See the problem</a>
    /// </summary>
    public long SumScores(string s)
    {
        // Each built string is a suffix of s, and its score is the length of the
        // longest common prefix between that suffix and s - exactly the Z-array.
        int n = s.Length;
        var z = new int[n];
        z[0] = n;
        long result = n;

        for (int i = 1, left = 0, right = 0; i < n; i++)
        {
            if (i < right)
            {
                z[i] = Math.Min(right - i, z[i - left]);
            }

            while (i + z[i] < n && s[z[i]] == s[i + z[i]])
            {
                z[i]++;
            }

            if (i + z[i] > right)
            {
                left = i;
                right = i + z[i];
            }

            result += z[i];
        }

        return result;
    }
}
