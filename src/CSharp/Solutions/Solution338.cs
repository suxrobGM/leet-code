namespace LeetCode.Solutions;

public class Solution338
{
    /// <summary>
    /// 338. Counting Bits - Easy
    /// <a href="https://leetcode.com/problems/counting-bits">See the problem</a>
    /// </summary>
    public int[] CountBits(int n)
    {
        var ans = new int[n+1];
        ans[0] = 0; // Base case
        
        for (var i = 1; i <= n; i++) 
        {
            // The number of 1's in i is 1 + the number of 1's in i & (i-1)
            // The expression i & (i - 1) is a well-known bit manipulation trick that removes the lowest set bit from 
            // i. This operation reduces the current problem to a previously solved smaller problem,
            // allowing us to simply add 1 to the result of the subproblem to get the current answer.
            ans[i] = ans[i & (i - 1)] + 1;
        }
        
        return ans;
    }
}
