using System.Text;


namespace LeetCode.Solutions;

public class Solution1702
{
    /// <summary>
    /// 1702. Maximum Binary String After Change - Medium
    /// <a href="https://leetcode.com/problems/maximum-binary-string-after-change">See the problem</a>
    /// </summary>
    public string MaximumBinaryString(string binary)
    {
        int n = binary.Length;
        int zeros = 0;
        int firstZero = -1;

        for (int i = 0; i < n; i++)
        {
            if (binary[i] == '0')
            {
                zeros++;
                if (firstZero == -1) firstZero = i;
            }
        }

        if (zeros <= 1) return binary; // either no zero or already stuck single zero

        // All '1's except a single '0' at index firstZero + zeros - 1
        char[] ans = new string('1', n).ToCharArray();
        ans[firstZero + zeros - 1] = '0';
        return new string(ans);
    }
}
