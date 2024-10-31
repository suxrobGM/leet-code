using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution728
{
    /// <summary>
    /// 728. Self Dividing Numbers - Easy
    /// <a href="https://leetcode.com/problems/self-dividing-numbers">See the problem</a>
    /// </summary>
    public IList<int> SelfDividingNumbers(int left, int right)
    {
        var result = new List<int>();

        for (var i = left; i <= right; i++)
        {
            if (IsSelfDividing(i))
            {
                result.Add(i);
            }
        }

        return result;
    }

    private bool IsSelfDividing(int num)
    {
        var n = num;

        while (n > 0)
        {
            var digit = n % 10;
            if (digit == 0 || num % digit != 0)
            {
                return false;
            }
            n /= 10;
        }

        return true;
    }
}
