using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1566
{
    /// <summary>
    /// 1566. Detect Pattern of Length M Repeated K or More Times - Easy
    /// <a href="https://leetcode.com/problems/detect-pattern-of-length-m-repeated-k-or-more-times">See the problem</a>
    /// </summary>
    public bool ContainsPattern(int[] arr, int m, int k)
    {
        int n = arr.Length;
        if (m * k > n) return false;

        for (int i = 0; i <= n - m * k; i++)
        {
            bool found = true;
            for (int j = 1; j < k; j++)
            {
                for (int l = 0; l < m; l++)
                {
                    if (arr[i + l] != arr[i + j * m + l])
                    {
                        found = false;
                        break;
                    }
                }
                if (!found) break;
            }
            if (found) return true;
        }

        return false;
    }
}
