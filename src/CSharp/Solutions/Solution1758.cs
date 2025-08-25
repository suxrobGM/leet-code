using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1758
{
    /// <summary>
    /// 1758. Minimum Changes To Make Alternating Binary String - Easy
    /// <a href="https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string">See the problem</a>
    /// </summary>
    public int MinOperations(string s)
    {
        int n = s.Length;
        int count1 = 0, count2 = 0;

        for (int i = 0; i < n; i++)
        {
            if (s[i] == '0')
            {
                if (i % 2 == 0) count1++;
                else count2++;
            }
            else
            {
                if (i % 2 == 0) count2++;
                else count1++;
            }
        }

        return Math.Min(count1, count2);
    }
}
