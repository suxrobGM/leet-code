using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1317
{
    /// <summary>
    /// 1317. Convert Integer to the Sum of Two No-Zero Integers - Easy
    /// <a href="https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers">See the problem</a>
    /// </summary>
    public int[] GetNoZeroIntegers(int n)
    {
        int a = 1, b = n - 1;
        while (a < n && b > 0)
        {
            if (HasNoZero(a) && HasNoZero(b))
            {
                return [a, b];
            }
            a++;
            b--;
        }
        return [0, 0];
    }

    private bool HasNoZero(int num)
    {
        while (num > 0)
        {
            if (num % 10 == 0) return false;
            num /= 10;
        }
        return true;
    }
}
