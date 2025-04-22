using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1281
{
    /// <summary>
    /// 1281. Subtract the Product and Sum of Digits of an Integer - Easy
    /// <a href="https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer">See the problem</a>
    /// </summary>
    public int SubtractProductAndSum(int n)
    {
        int product = 1, sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            product *= digit;
            sum += digit;
            n /= 10;
        }
        return product - sum;
    }
}
