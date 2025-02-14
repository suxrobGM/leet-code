using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution991
{
    /// <summary>
    /// 991. Broken Calculator - Medium
    /// <a href="https://leetcode.com/problems/broken-calculator">See the problem</a>
    /// </summary>
    public int BrokenCalc(int startValue, int target)
    {
        var result = 0;

        while (target > startValue)
        {
            result++;

            if (target % 2 == 0)
            {
                target /= 2;
            }
            else
            {
                target++;
            }
        }

        return result + startValue - target;
    }
}
