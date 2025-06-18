using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1550
{
    /// <summary>
    /// 1550. Three Consecutive Odds - Easy
    /// <a href="https://leetcode.com/problems/three-consecutive-odds">See the problem</a>
    /// </summary>
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        int count = 0;

        foreach (var num in arr)
        {
            if (num % 2 != 0)
            {
                count++;
                if (count == 3)
                {
                    return true;
                }
            }
            else
            {
                count = 0;
            }
        }

        return false;
    }
}
