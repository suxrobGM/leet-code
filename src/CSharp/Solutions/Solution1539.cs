using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1539
{
    /// <summary>
    /// 1539. Kth Missing Positive Number - Easy
    /// <a href="https://leetcode.com/problems/kth-missing-positive-number">See the problem</a>
    /// </summary>
    public int FindKthPositive(int[] arr, int k)
    {
        int missingCount = 0;
        int current = 1;
        int index = 0;

        while (missingCount < k)
        {
            if (index < arr.Length && arr[index] == current)
            {
                index++;
            }
            else
            {
                missingCount++;
                if (missingCount == k)
                {
                    return current;
                }
            }
            current++;
        }

        return -1; // This line should never be reached if k is valid.
    }
}
