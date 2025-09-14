using System.Text;

namespace LeetCode.Solutions;

public class Solution1822
{
    /// <summary>
    /// 1822. Sign of the Product of an Array - Easy
    /// <a href="https://leetcode.com/problems/sign-of-the-product-of-an-array">See the problem</a>
    /// </summary>
    public int ArraySign(int[] nums)
    {
        int sign = 1;
        foreach (int x in nums)
        {
            if (x == 0) return 0;
            if (x < 0) sign = -sign;
        }
        return sign;
    }
}
