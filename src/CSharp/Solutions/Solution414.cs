namespace LeetCode.Solutions;

public class Solution414
{
    /// <summary>
    /// 414. Third Maximum Number - Easy
    /// <a href="https://leetcode.com/problems/third-maximum-number">See the problem</a>
    /// </summary>
    public int ThirdMax(int[] nums)
    {
        var first = long.MinValue;
        var second = long.MinValue;
        var third = long.MinValue;

        foreach (var num in nums)
        {
            if (num == first || num == second || num == third)
            {
                continue;
            }

            if (num > first)
            {
                third = second;
                second = first;
                first = num;
            }
            else if (num > second)
            {
                third = second;
                second = num;
            }
            else if (num > third)
            {
                third = num;
            }
        }

        return third == long.MinValue ? (int)first : (int)third;
    }
}
