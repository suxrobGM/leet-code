using System.Text;


namespace LeetCode.Solutions;

public class Solution1720
{
    /// <summary>
    /// 1720. Decode XORed Array - Easy
    /// <a href="https://leetcode.com/problems/decode-xored-array">See the problem</a>
    /// </summary>
    public int[] Decode(int[] encoded, int first)
    {
        int n = encoded.Length + 1;
        int[] decoded = new int[n];
        decoded[0] = first;
        for (int i = 1; i < n; i++)
        {
            decoded[i] = encoded[i - 1] ^ decoded[i - 1];
        }
        return decoded;
    }
}
