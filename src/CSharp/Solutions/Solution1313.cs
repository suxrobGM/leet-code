using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1313
{
    /// <summar
    /// 1313. Decompress Run-Length Encoded List - Easy
    /// <a href="https://leetcode.com/problems/decompress-run-length-encoded-list">See the problem</a>
    /// </summary>
    public int[] DecompressRLElist(int[] nums)
    {
        int n = nums.Length;
        int size = 0;
        for (int i = 0; i < n; i += 2)
        {
            size += nums[i];
        }

        int[] result = new int[size];
        int index = 0;
        for (int i = 0; i < n; i += 2)
        {
            for (int j = 0; j < nums[i]; j++)
            {
                result[index++] = nums[i + 1];
            }
        }

        return result;
    }
}
