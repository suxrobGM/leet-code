using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1734
{
    /// <summary>
    /// 1734. Decode XORed Permutation - Medium
    /// <a href="https://leetcode.com/problems/decode-xored-permutation">See the problem</a>
    /// </summary>
    public int[] Decode(int[] encoded)
    {
        int n = encoded.Length + 1;
        int[] perm = new int[n];
        int[] prefixXor = new int[n + 1];
        for (int i = 1; i < n; i += 2)
        {
            prefixXor[i + 1] = prefixXor[i] ^ encoded[i - 1];
        }
        for (int i = 0; i < n; i++)
        {
            perm[i] = prefixXor[i] ^ prefixXor[n];
        }
        return perm;
    }
}
