using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1250
{
    /// <summary>
    /// 1250. Check If It Is a Good Array - Hard
    /// <a href="https://leetcode.com/problems/check-if-it-is-a-good-array">See the problem</a>
    /// </summary>
    public bool IsGoodArray(int[] nums)
    {
        int gcd = nums[0];
        foreach (var num in nums)
        {
            gcd = GCD(gcd, num);
            if (gcd == 1) return true;
        }
        return gcd == 1;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
