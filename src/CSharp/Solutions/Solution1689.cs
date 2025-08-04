using System.Text;


namespace LeetCode.Solutions;

public class Solution1689
{
    /// <summary>
    /// 1689. Partitioning Into Minimum Number Of Deci-Binary Numbers - Medium
    /// <a href="https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers">See the problem</a>
    /// </summary>
    public int MinPartitions(string n)
    {
        // The minimum number of deci-binary numbers needed is the maximum digit in the string.
        int maxDigit = 0;
        foreach (char c in n)
        {
            maxDigit = Math.Max(maxDigit, c - '0');
        }
        return maxDigit;
    }
}
