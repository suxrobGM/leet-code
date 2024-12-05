using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution869
{
    /// <summary>
    /// 869. Reordered Power of 2 - Medium
    /// <a href="https://leetcode.com/problems/reordered-power-of-2">See the problem</a>
    /// </summary>
    public bool ReorderedPowerOf2(int n)
    {
        var s = new StringBuilder();
        s.Append(n);
        var nCount = new int[10];

        foreach (var c in s.ToString())
        {
            nCount[c - '0']++;
        }

        for (int i = 0; i < 31; i++)
        {
            var powerOf2 = new StringBuilder();
            powerOf2.Append(1 << i);
            var powerOf2Count = new int[10];

            foreach (var c in powerOf2.ToString())
            {
                powerOf2Count[c - '0']++;
            }

            if (nCount.SequenceEqual(powerOf2Count))
            {
                return true;
            }
        }

        return false;
    }
}
