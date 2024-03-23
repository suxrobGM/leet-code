namespace LeetCode.Solutions;

public class Solution50
{
    /// <summary>
    /// 50. Pow(x, n) - Medium
    /// <a href="https://leetcode.com/problems/powx-n">See the problem</a>
    /// </summary>
    public double MyPow(double x, int n)
    {
        // Convert n to long to handle the case when n = Int32.MinValue
        long nLong = n;
        
        if (nLong < 0) 
        {
            x = 1 / x;
            nLong = -nLong;
        }

        var ans = 1.0;
        var currentProduct = x;
        
        for (var i = nLong; i > 0; i /= 2) 
        {
            if (i % 2 == 1) 
            {
                ans *= currentProduct;
            }
            currentProduct *= currentProduct;
        }

        return ans;
    }
}
