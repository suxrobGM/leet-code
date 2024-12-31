using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution923
{
    /// <summary>
    /// 923. 3Sum With Multiplicity - Medium
    /// <a href="https://leetcode.com/problems/3sum-with-multiplicity">See the problem</a>
    /// </summary>
    public int ThreeSumMulti(int[] arr, int target)
    {
        const int MOD = 1_000_000_007;
        Array.Sort(arr);
        int n = arr.Length;
        long count = 0;

        for (int i = 0; i < n - 2; i++)
        {
            int left = i + 1, right = n - 1;
            int newTarget = target - arr[i];

            while (left < right)
            {
                int sum = arr[left] + arr[right];

                if (sum < newTarget)
                {
                    left++;
                }
                else if (sum > newTarget)
                {
                    right--;
                }
                else
                {
                    // Handle duplicates
                    if (arr[left] == arr[right])
                    {
                        long freq = right - left + 1;
                        count += (freq * (freq - 1) / 2) % MOD;
                        count %= MOD;
                        break;
                    }
                    else
                    {
                        // Count left duplicates
                        int leftCount = 1, rightCount = 1;
                        while (left + 1 < right && arr[left] == arr[left + 1])
                        {
                            leftCount++;
                            left++;
                        }
                        while (right - 1 > left && arr[right] == arr[right - 1])
                        {
                            rightCount++;
                            right--;
                        }

                        count += (long)leftCount * rightCount % MOD;
                        count %= MOD;
                        left++;
                        right--;
                    }
                }
            }
        }

        return (int)(count % MOD);
    }
}
