using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1630
{
    /// <summary>
    /// 1630. Arithmetic Subarrays - Medium
    /// <a href="https://leetcode.com/problems/arithmetic-subarrays">See the problem</a>
    /// </summary>
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        List<bool> result = [];

        for (int i = 0; i < l.Length; i++)
        {
            int start = l[i];
            int end = r[i];
            int len = end - start + 1;

            // Extract and sort the subarray
            int[] subarray = new int[len];
            Array.Copy(nums, start, subarray, 0, len);
            Array.Sort(subarray);

            // Calculate the expected difference
            int diff = subarray[1] - subarray[0];
            bool isArithmetic = true;

            for (int j = 2; j < subarray.Length; j++)
            {
                if (subarray[j] - subarray[j - 1] != diff)
                {
                    isArithmetic = false;
                    break;
                }
            }

            result.Add(isArithmetic);
        }

        return result;
    }
}
