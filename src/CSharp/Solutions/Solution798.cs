
namespace LeetCode.Solutions;

public class Solution798
{
    /// <summary>
    /// 798. Smallest Rotation with Highest Score - Hard
    /// <a href="https://leetcode.com/problems/smallest-rotation-with-highest-score">See the problem</a>
    /// </summary>
    public int BestRotation(int[] nums)
    {
        int n = nums.Length;
        int[] change = new int[n];

        // Populate the change array
        for (int i = 0; i < n; i++)
        {
            int low = (i + 1) % n;
            int high = (i - nums[i] + n + 1) % n;
            change[low]++;
            change[high]--;

            if (low > high)
            {
                change[0]++;
            }
        }

        // Calculate the cumulative score for each rotation using the change array
        int maxScore = -1;
        int bestK = 0;
        int currentScore = 0;

        for (int k = 0; k < n; k++)
        {
            currentScore += change[k];
            if (currentScore > maxScore)
            {
                maxScore = currentScore;
                bestK = k;
            }
        }

        return bestK;
    }
}
