namespace LeetCode.Solutions;

public class Solution2156
{
    /// <summary>
    /// 2156. Find Substring With Given Hash Value - Hard
    /// <a href="https://leetcode.com/problems/find-substring-with-given-hash-value">See the problem</a>
    /// </summary>
    public string SubStrHash(string s, int power, int modulo, int k, int hashValue)
    {
        int n = s.Length;
        long p = power, m = modulo;

        long pk = 1;
        for (int i = 0; i < k; i++) pk = pk * p % m;

        long h = 0;
        for (int i = n - 1; i >= n - k; i--)
        {
            h = (h * p + (s[i] - 'a' + 1)) % m;
        }

        int answer = h == hashValue ? n - k : -1;

        for (int i = n - k - 1; i >= 0; i--)
        {
            h = (h * p + (s[i] - 'a' + 1) - (s[i + k] - 'a' + 1) * pk) % m;
            if (h < 0) h += m;
            if (h == hashValue) answer = i;
        }

        return s.Substring(answer, k);
    }
}
