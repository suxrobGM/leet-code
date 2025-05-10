using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1342
{
    /// <summary>
    /// 1342. Number of Steps to Reduce a Number to Zero - Easy
    /// <a href="https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero">See the problem</a>
    /// </summary>
    public int NumberOfSteps(int num)
    {
        int steps = 0;

        while (num > 0)
        {
            if ((num & 1) == 1)
            {
                num--;
            }
            else
            {
                num >>= 1;
            }
            steps++;
        }

        return steps;
    }
}
