namespace LeetCode.Solutions;

public class Solution2001
{
    /// <summary>
    /// 2001. Number of Pairs of Interchangeable Rectangles - Medium
    /// <a href="https://leetcode.com/problems/number-of-pairs-of-interchangeable-rectangles">See the problem</a>
    /// </summary>
    public long InterchangeableRectangles(int[][] rectangles)
    {
        var ratioCount = new Dictionary<double, long>();
        long result = 0;

        foreach (var rectangle in rectangles)
        {
            double ratio = (double)rectangle[0] / rectangle[1];

            if (ratioCount.ContainsKey(ratio))
            {
                result += ratioCount[ratio];
                ratioCount[ratio]++;
            }
            else
            {
                ratioCount[ratio] = 1;
            }
        }

        return result;
    }
}
