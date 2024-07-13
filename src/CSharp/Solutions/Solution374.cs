namespace LeetCode.Solutions;

public class Solution374
{
    /// <summary>
    /// 374. Guess Number Higher or Lower - Easy
    /// <a href="https://leetcode.com/problems/guess-number-higher-or-lower">See the problem</a>
    /// </summary>
    public int GuessNumber(int n)
    {
        var left = 1;
        var right = n;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var result = Guess(mid);

            if (result == 0)
            {
                return mid;
            }

            if (result < 0)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }

    private int Guess(int num)
    {
        return 0;
    }
}
