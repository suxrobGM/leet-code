using System.Text;


namespace LeetCode.Solutions;

public class Solution1716
{
    /// <summary>
    /// 1716. Calculate Money in Leetcode Bank - Easy
    /// <a href="https://leetcode.com/problems/calculate-money-in-leetcode-bank">See the problem</a>
    /// </summary>
    public int TotalMoney(int n)
    {
        int weeks = n / 7;
        int days = n % 7;

        int fullWeeksSum = 28 * weeks + (7 * weeks * (weeks - 1)) / 2;

        int start = weeks + 1;
        int partialSum = (start + (start + days - 1)) * days / 2;

        return fullWeeksSum + partialSum;
    }
}
