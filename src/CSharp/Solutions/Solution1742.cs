using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1742
{
    /// <summary>
    /// 1742. Maximum Number of Balls in a Box - Easy
    /// <a href="https://leetcode.com/problems/maximum-number-of-balls-in-a-box">See the problem</a>
    /// </summary>
    public int CountBalls(int lowLimit, int highLimit)
    {
        // Max sum of digits for numbers ≤ 1e5 is 9*5 = 45
        int[] box = new int[46];
        int best = 0;

        for (int x = lowLimit; x <= highLimit; x++)
        {
            int s = SumDigits(x);
            int c = ++box[s];
            if (c > best) best = c;
        }

        return best;
    }

    private int SumDigits(int x)
    {
        int s = 0;
        while (x > 0) { s += x % 10; x /= 10; }
        return s;
    }
}

