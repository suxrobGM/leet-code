namespace LeetCode.Solutions;

public class Solution2009
{
    /// <summary>
    /// 2009. Minimum Number of Operations to Make Array Continuous - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-make-array-continuous">See the problem</a>
    /// </summary>
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;

        // Get unique elements and sort them
        int[] unique = nums.Distinct().OrderBy(x => x).ToArray();
        int m = unique.Length;

        int maxKept = 0;
        int j = 0;

        // Sliding window: for each left boundary, find elements
        // that fit in range [unique[i], unique[i] + n - 1]
        for (int i = 0; i < m; i++)
        {
            while (j < m && unique[j] <= unique[i] + n - 1)
            {
                j++;
            }
            maxKept = Math.Max(maxKept, j - i);
        }

        return n - maxKept;
    }
}
