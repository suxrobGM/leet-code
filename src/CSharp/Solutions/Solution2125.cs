namespace LeetCode.Solutions;

public class Solution2125
{
    /// <summary>
    /// 2125. Number of Laser Beams in a Bank - Medium
    /// <a href="https://leetcode.com/problems/number-of-laser-beams-in-a-bank">See the problem</a>
    /// </summary>
    public int NumberOfBeams(string[] bank)
    {
        var result = 0;
        var prev = 0;
        foreach (var row in bank)
        {
            var count = row.Count(c => c == '1');
            if (count > 0)
            {
                result += prev * count;
                prev = count;
            }
        }

        return result;
    }
}
