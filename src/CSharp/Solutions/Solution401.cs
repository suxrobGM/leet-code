namespace LeetCode.Solutions;

public class Solution401
{
    /// <summary>
    /// 401. Binary Watch - Easy
    /// <a href="https://leetcode.com/problems/binary-watch">See the problem</a>
    /// </summary>
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        var result = new List<string>();

        for (var h = 0; h < 12; h++)
        {
            for (var m = 0; m < 60; m++)
            {
                if (CountBits(h) + CountBits(m) == turnedOn)
                {
                    result.Add($"{h}:{m:D2}");
                }
            }
        }

        return result;
    }

    private int CountBits(int n)
    {
        var count = 0;

        while (n > 0)
        {
            count += n & 1;
            n >>= 1;
        }

        return count;
    }
}
