using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1492
{
    /// <summary>
    /// 1492. The kth Factor of n - Medium
    /// <a href="https://leetcode.com/problems/the-kth-factor-of-n">See the problem</a>
    /// </summary>
    public int KthFactor(int n, int k)
    {
        if (k <= 0 || n <= 0)
            return -1;

        int count = 0;

        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                count++;
                if (count == k)
                    return i;
            }
        }

        return -1; // If k is greater than the number of factors
    }
}
