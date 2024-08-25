namespace LeetCode.Solutions;

public class Solution497
{
    /// <summary>
    /// 497. Random Point in Non-overlapping Rectangles - Medium
    /// <a href="https://leetcode.com/problems/random-point-in-non-overlapping-rectangles">See the problem</a>
    /// </summary>
    public class Solution
    {
        private readonly int[][] rects;
        private readonly int[] prefixSums;
        private readonly int totalPoints;
        private readonly Random random;

        public Solution(int[][] rects)
        {
            this.rects = rects;
            prefixSums = new int[rects.Length];
            totalPoints = 0;
            random = new Random();

            for (int i = 0; i < rects.Length; i++)
            {
                int[] rect = rects[i];
                totalPoints += (rect[2] - rect[0] + 1) * (rect[3] - rect[1] + 1);
                prefixSums[i] = totalPoints;
            }
        }

        public int[] Pick()
        {
            int randomPoint = random.Next(totalPoints);
            int left = 0;
            int right = rects.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (prefixSums[mid] <= randomPoint)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            int[] rect = rects[left];
            int width = rect[2] - rect[0] + 1;
            int height = rect[3] - rect[1] + 1;
            int pointsInRect = width * height;
            int offset = randomPoint - (left == 0 ? 0 : prefixSums[left - 1]);
            int x = rect[0] + offset % width;
            int y = rect[1] + offset / width;

            return [x, y];
        }
    }
}
