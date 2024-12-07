using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution873
{
    /// <summary>
    /// 873. Length of Longest Fibonacci Subsequence - Medium
    /// <a href="https://leetcode.com/problems/length-of-longest-fibonacci-subsequence">See the problem</a>
    /// </summary>
    public int LenLongestFibSubseq(int[] arr)
    {
        var n = arr.Length;
        var set = new HashSet<int>(arr);
        var dp = new Dictionary<(int, int), int>();

        int result = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int a = arr[i];
                int b = arr[j];
                int count = 2;

                while (set.Contains(a + b))
                {
                    count++;
                    int temp = a;
                    a = b;
                    b = temp + b;
                }

                result = Math.Max(result, count);
            }
        }

        return result > 2 ? result : 0;
    }
}
