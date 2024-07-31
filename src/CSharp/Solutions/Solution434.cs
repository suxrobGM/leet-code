namespace LeetCode.Solutions;

public class Solution434
{
    /// <summary>
    /// 434. Number of Segments in a String - Easy
    /// <a href="https://leetcode.com/problems/number-of-segments-in-a-string">See the problem</a>
    /// </summary>
    public int CountSegments(string s)
    {
        var count = 0;
        var inSegment = false;
        foreach (var c in s)
        {
            if (c == ' ')
            {
                if (inSegment)
                {
                    count++;
                    inSegment = false;
                }
            }
            else
            {
                inSegment = true;
            }
        }

        return inSegment ? count + 1 : count;
    }
}
