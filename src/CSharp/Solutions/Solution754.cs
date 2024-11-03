using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution754
{
    /// <summary>
    /// 754. Reach a Number - Medium
    /// <a href="https://leetcode.com/problems/reach-a-number">See the problem</a>
    /// </summary>
    public int ReachNumber(int target)
    {
        target = Math.Abs(target);
        var k = 0;

        while (target > 0)
        {
            target -= ++k;
        }

        return target % 2 == 0 ? k : k + 1 + k % 2;
    }
}
