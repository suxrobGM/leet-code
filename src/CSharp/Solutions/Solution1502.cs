using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1502
{
    /// <summary>
    /// 1502. Can Make Arithmetic Progression From Sequence - Easy
    /// <a href="https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence">See the problem</a>
    /// </summary>
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        if (arr.Length < 2)
        {
            return true;
        }

        Array.Sort(arr);
        int commonDifference = arr[1] - arr[0];

        for (int i = 2; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] != commonDifference)
            {
                return false;
            }
        }

        return true;
    }
}
