using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1663
{
    /// <summary>
    /// 1663. Smallest String With A Given Numeric Value - Medium
    /// <a href="https://leetcode.com/problems/smallest-string-with-a-given-numeric-value">See the problem</a>
    /// </summary>
    public string GetSmallestString(int n, int k)
    {
        char[] result = new char[n];

        for (int i = n - 1; i >= 0; i--)
        {
            int val = Math.Min(26, k - i); // leave at least 1 for each of remaining i characters
            result[i] = (char)('a' + val - 1);
            k -= val;
        }

        return new string(result);
    }
}
