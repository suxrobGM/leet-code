namespace LeetCode.Solutions;

public class Solution492
{
    /// <summary>
    /// 492. Construct the Rectangle - Easy
    /// <a href="https://leetcode.com/problems/construct-the-rectangle">See the problem</a>
    /// </summary>
    public int[] ConstructRectangle(int area)
    {
        var sqrt = (int)Math.Sqrt(area);
        while (area % sqrt != 0)
        {
            sqrt--;
        }

        return [area / sqrt, sqrt];
    }
}
