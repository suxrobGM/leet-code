using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1013
{
    /// <summary>
    /// 1013. Partition Array Into Three Parts With Equal Sum - Easy
    /// <a href="https://leetcode.com/problems/partition-array-into-three-parts-with-equal-sum</a>
    /// </summary>
    public bool CanThreePartsEqualSum(int[] arr)
    {
        var sum = 0;
        foreach (var num in arr)
        {
            sum += num;
        }

        if (sum % 3 != 0)
        {
            return false;
        }

        var target = sum / 3;
        var count = 0;
        var currentSum = 0;

        foreach (var num in arr)
        {
            currentSum += num;
            if (currentSum == target)
            {
                count++;
                currentSum = 0;
            }
        }

        return count >= 3;
    }
}
