using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1759
{
    /// <summary>
    /// 1759. Count Number of Homogenous Substrings - Medium
    /// <a href="https://leetcode.com/problems/count-number-of-homogenous-substrings">See the problem</a>
    /// </summary>
    public int CountHomogenous(string s)
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
