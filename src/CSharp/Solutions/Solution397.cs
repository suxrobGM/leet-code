namespace LeetCode.Solutions;

public class Solution397
{
    /// <summary>
    /// 397. Integer Replacement - Medium
    /// <a href="https://leetcode.com/problems/integer-replacement">See the problem</a>
    /// </summary>
    public int IntegerReplacement(int n)
    {
        var count = 0;

        while (n != 1)
        {
            if ((n & 1) == 0)
            {
                n >>= 1;
            }
            else if (n == 3 || ((n >> 1) & 1) == 0)
            {
                n--;
            }
            else
            {
                n++;
            }

            count++;
        }

        return count;
    }
}
