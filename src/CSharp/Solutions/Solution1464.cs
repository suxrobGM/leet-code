using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1464
{
    /// <summary>
    /// 1464. Maximum Product of Two Elements in an Array - Easy
    /// <a href="https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array">See the problem</a>
    /// </summary>
    public int MaxProduct(int[] nums)
    {
        // Find the two largest numbers in the array
        int max1 = 0, max2 = 0;
        foreach (var num in nums)
        {
            if (num > max1)
            {
                max2 = max1;
                max1 = num;
            }
            else if (num > max2)
            {
                max2 = num;
            }
        }

        // Return the product of the two largest numbers minus 1
        return (max1 - 1) * (max2 - 1);
    }
}
