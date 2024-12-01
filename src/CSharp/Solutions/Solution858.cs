using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution858
{
    /// <summary>
    /// 858. Mirror Reflection - Medium
    /// <a href="https://leetcode.com/problems/mirror-reflection">See the problem</a>
    /// </summary>
    public int MirrorReflection(int p, int q)
    {
        int g = Gcd(p, q);
        p /= g;
        p %= 2;
        q /= g;
        q %= 2;

        if (p == 1 && q == 1)
        {
            return 1;
        }

        return p == 1 ? 0 : 2;
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}
