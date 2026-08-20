namespace LeetCode.Solutions;

public class Solution2250
{
    /// <summary>
    /// 2250. Count Number of Rectangles Containing Each Point - Medium
    /// <a href="https://leetcode.com/problems/count-number-of-rectangles-containing-each-point">See the problem</a>
    /// </summary>
    public int[] CountRectangles(int[][] rectangles, int[][] points)
    {
        // Heights are bounded by 100, so group lengths by height and sort each
        // bucket; a point only needs to scan the few buckets tall enough for it
        const int maxHeight = 100;
        var lengthsByHeight = new List<int>[maxHeight + 1];

        for (var height = 1; height <= maxHeight; height++)
        {
            lengthsByHeight[height] = [];
        }

        foreach (var rectangle in rectangles)
        {
            lengthsByHeight[rectangle[1]].Add(rectangle[0]);
        }

        for (var height = 1; height <= maxHeight; height++)
        {
            lengthsByHeight[height].Sort();
        }

        var answer = new int[points.Length];

        for (var i = 0; i < points.Length; i++)
        {
            int x = points[i][0], y = points[i][1];
            var count = 0;

            for (var height = y; height <= maxHeight; height++)
            {
                var lengths = lengthsByHeight[height];
                // Rectangles with a length of at least x cover the point
                count += lengths.Count - LowerBound(lengths, x);
            }

            answer[i] = count;
        }

        return answer;
    }

    private static int LowerBound(List<int> values, int target)
    {
        int low = 0, high = values.Count;

        while (low < high)
        {
            var mid = low + (high - low) / 2;

            if (values[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }
}
