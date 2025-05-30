using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1491
{
    /// <summary>
    /// 1491. Average Salary Excluding the Minimum and Maximum Salary - Easy
    /// <a href="https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary">See the problem</a>
    /// </summary>
    public double Average(int[] salary)
    {
        if (salary == null || salary.Length < 3)
            return 0.0;

        int min = int.MaxValue, max = int.MinValue, sum = 0;

        foreach (var s in salary)
        {
            if (s < min) min = s;
            if (s > max) max = s;
            sum += s;
        }

        // Exclude min and max from the sum
        sum -= min + max;
        // Calculate average excluding min and max
        return (double)sum / (salary.Length - 2);
    }
}
