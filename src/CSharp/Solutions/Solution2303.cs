using System.Text;

namespace LeetCode.Solutions;

public class Solution2303
{
    /// <summary>
    /// 2303. Calculate Amount Paid in Taxes - Easy
    /// <a href="https://leetcode.com/problems/calculate-amount-paid-in-taxes">See the problem</a>
    /// </summary>
    public double CalculateTax(int[][] brackets, int income)
    {
        double tax = 0;
        int previousLimit = 0;

        foreach (var bracket in brackets)
        {
            int limit = bracket[0];
            int percent = bracket[1];

            if (income <= limit)
            {
                tax += (income - previousLimit) * percent / 100.0;
                break;
            }
            else
            {
                tax += (limit - previousLimit) * percent / 100.0;
                previousLimit = limit;
            }
        }

        return tax;
    }
}
