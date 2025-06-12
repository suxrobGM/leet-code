using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1524
{
    /// <summary>
    /// 1524. Number of Sub-arrays With Odd Sum - Medium
    /// <a href="https://leetcode.com/problems/number-of-sub-arrays-with-odd-sum">See the problem</a>
    /// </summary>
    public int NumOfSubarrays(int[] arr)
    {
        const int MOD = 1_000_000_007;
        int result = 0, odd = 0, even = 1, curr = 0;

        foreach (int num in arr)
        {
            curr += num;
            curr %= 2;

            if (curr == 1)
            {
                result = (result + even) % MOD;
                odd++;
            }
            else
            {
                result = (result + odd) % MOD;
                even++;
            }
        }

        return result;
    }
}
