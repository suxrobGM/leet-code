using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1477
{
    /// <summary>
    /// 1477. Find Two Non-overlapping Sub-arrays Each With Target Sum - Medium
    /// <a href="https://leetcode.com/problems/find-two-non-overlapping-sub-arrays-each-with-target-sum">See the problem</a>
    /// </summary>
    public int MinSumOfLengths(int[] arr, int target)
    {
        int n = arr.Length;
        var minLen = new int[n];
        Array.Fill(minLen, int.MaxValue);

        int left = 0, sum = 0, best = int.MaxValue, res = int.MaxValue;

        for (int right = 0; right < n; right++)
        {
            sum += arr[right];

            // Shrink the window
            while (sum > target)
            {
                sum -= arr[left++];
            }

            // If valid subarray found
            if (sum == target)
            {
                int currLen = right - left + 1;

                // If there's a valid subarray before the current one
                if (left > 0 && minLen[left - 1] != int.MaxValue)
                {
                    res = Math.Min(res, currLen + minLen[left - 1]);
                }

                best = Math.Min(best, currLen);
            }

            minLen[right] = best;
        }

        return res == int.MaxValue ? -1 : res;
    }
}
