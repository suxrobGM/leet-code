namespace LeetCode.Solutions;

public class Solution393
{
    /// <summary>
    /// 393. UTF-8 Validation - Medium
    /// <a href="https://leetcode.com/problems/utf-8-validation">See the problem</a>
    /// </summary>
    public bool ValidUtf8(int[] data)
    {
        var count = 0;

        foreach (var num in data)
        {
            if (count == 0)
            {
                if ((num >> 5) == 0b110)
                {
                    count = 1;
                }
                else if ((num >> 4) == 0b1110)
                {
                    count = 2;
                }
                else if ((num >> 3) == 0b11110)
                {
                    count = 3;
                }
                else if ((num >> 7) != 0)
                {
                    return false;
                }
            }
            else
            {
                if ((num >> 6) != 0b10)
                {
                    return false;
                }

                count--;
            }
        }

        return count == 0;
    }
}
