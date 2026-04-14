using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2100
{
    /// <summary>
    /// 2100. Find Good Days to Rob the Bank - Medium
    /// <a href="https://leetcode.com/problems/find-good-days-to-rob-the-bank">See the problem</a>
    /// </summary>
    public IList<int> GoodDaysToRobBank(int[] security, int time)
    {
        var n = security.Length;
        var nonIncreasing = new int[n]; // consecutive non-increasing days ending at i
        var nonDecreasing = new int[n]; // consecutive non-decreasing days starting at i

        for (var i = 1; i < n; i++)
            if (security[i] <= security[i - 1])
                nonIncreasing[i] = nonIncreasing[i - 1] + 1;

        for (var i = n - 2; i >= 0; i--)
            if (security[i] <= security[i + 1])
                nonDecreasing[i] = nonDecreasing[i + 1] + 1;

        var result = new List<int>();
        for (var i = time; i < n - time; i++)
            if (nonIncreasing[i] >= time && nonDecreasing[i] >= time)
                result.Add(i);

        return result;
    }
}
