namespace LeetCode.Solutions;

public class Solution2357
{
    /// <summary>
    /// 2357. Make Array Zero by Subtracting Equal Amounts - Easy
    /// <a href="https://leetcode.com/problems/make-array-zero-by-subtracting-equal-amounts">See the problem</a>
    /// </summary>
    public int MinimumOperations(int[] nums)
    {
        var distinctPositiveValues = new HashSet<int>();
        foreach (int num in nums)
        {
            if (num > 0)
            {
                distinctPositiveValues.Add(num);
            }
        }

        // Subtracting the smallest positive value removes one distinct positive level.
        return distinctPositiveValues.Count;
    }
}
