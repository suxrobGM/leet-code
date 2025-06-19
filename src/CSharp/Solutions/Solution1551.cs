using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1551
{
    /// <summary>
    /// 1551. Minimum Operations to Make Array Equal - Medium
    /// <a href="https://leetcode.com/problems/minimum-operations-to-make-array-equal">See the problem</a>
    /// </summary>
    public int MinOperations(int n)
    {
        int m = n / 2;
        return m * (n - m);
    }
}
