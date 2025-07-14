using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1625
{
    /// <summary>
    /// 1625. Lexicographically Smallest String After Applying Operations - Medium
    /// <a href="https://leetcode.com/problems/lexicographically-smallest-string-after-applying-operations">See the problem</a>
    /// </summary>
    public string FindLexSmallestString(string s, int a, int b)
    {
        int n = s.Length;
        int g = Gcd(n, b);                 // distinct reachable rotations
        string best = s;

        // enumerate all reachable right-rotations
        for (int shift = 0; shift < n; shift += g)
        {
            string rotated = RotateRight(s, shift);

            // try every possible increment on odd indices
            for (int oddStep = 0; oddStep < 10; ++oddStep)
            {
                int incOdd = (oddStep * a) % 10;
                char[] oddApplied = rotated.ToCharArray();

                for (int i = 1; i < n; i += 2)
                    oddApplied[i] = (char)('0' + ((oddApplied[i] - '0' + incOdd) % 10));

                if (b % 2 == 0)                       // even indices can never change
                {
                    string candidate = new(oddApplied);
                    if (string.CompareOrdinal(candidate, best) < 0) best = candidate;
                }
                else                                   // we can also modify even indices
                {
                    for (int evenStep = 0; evenStep < 10; ++evenStep)
                    {
                        int incEven = (evenStep * a) % 10;
                        char[] allApplied = (char[])oddApplied.Clone();

                        for (int i = 0; i < n; i += 2)
                            allApplied[i] = (char)('0' + ((allApplied[i] - '0' + incEven) % 10));

                        string candidate = new(allApplied);
                        if (string.CompareOrdinal(candidate, best) < 0) best = candidate;
                    }
                }
            }
        }

        return best;
    }

    /* ---------- helpers ---------- */

    private static int Gcd(int x, int y)
    {
        while (y != 0)
        {
            int tmp = x % y;
            x = y;
            y = tmp;
        }
        return x;
    }

    private static string RotateRight(string s, int k)
    {
        int n = s.Length;
        k %= n;
        if (k == 0) return s;
        return s[^k..] + s[..^k];       // suffix + prefix
    }
}
