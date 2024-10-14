namespace LeetCode.Solutions;

public class Solution645
{
    /// <summary>
    /// 645. Set Mismatch - Easy
    /// <a href="https://leetcode.com/problems/set-mismatch">See the problem</a>
    /// </summary>
    public int[] FindErrorNums(int[] nums)
    {
        var numsSet = new HashSet<int>();
        var duplicateNum = 0;
        var n = nums.Length;

        foreach (var num in nums)
        {
            if (!numsSet.Add(num))
            {
                duplicateNum = num;
            }
        }

        return [duplicateNum, duplicateNum + n * (n + 1) / 2 - nums.Sum()];
    }
}
