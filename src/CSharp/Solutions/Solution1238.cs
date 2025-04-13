using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1238
{
    /// <summary>
    /// 1238. Circular Permutation in Binary Representation - Medium
    /// <a href="https://leetcode.com/problems/circular-permutation-in-binary-representation">See the problem</a>
    /// </summary>
    public IList<int> CircularPermutation(int n, int start)
    {
        var result = new List<int>();
        int totalNumbers = 1 << n; // 2^n

        for (int i = 0; i < totalNumbers; i++)
        {
            // Generate the Gray code for the current number
            int grayCode = i ^ (i >> 1);
            result.Add(grayCode ^ start); // XOR with start to shift the permutation
        }

        return result;
    }
}
