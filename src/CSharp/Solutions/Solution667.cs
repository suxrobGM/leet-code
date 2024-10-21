using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution667
{
    /// <summary>
    /// 667. Beautiful Arrangement II - Medium
    /// <a href="https://leetcode.com/problems/beautiful-arrangement-ii">See the problem</a>
    /// </summary>
    public int[] ConstructArray(int n, int k)
    {
        var result = new int[n];
        var left = 1;
        var right = n;

        for (var i = 0; i < n; i++)
        {
            result[i] = k % 2 == 0 ? left++ : right--;
            if (k > 1)
            {
                k--;
            }
        }

        return result;
    }
}
