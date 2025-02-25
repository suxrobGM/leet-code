using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1024
{
    /// <summary>
    /// 1024. Video Stitching - Medium
    /// <a href="https://leetcode.com/problems/video-stitching</a>
    /// </summary>
    public int VideoStitching(int[][] clips, int time)
    {
        var dp = new int[time + 1];
        for (var i = 0; i < dp.Length; i++)
        {
            dp[i] = int.MaxValue - 1;
        }

        dp[0] = 0;
        for (var i = 1; i <= time; i++)
        {
            foreach (var clip in clips)
            {
                if (clip[0] < i && i <= clip[1])
                {
                    dp[i] = Math.Min(dp[i], dp[clip[0]] + 1);
                }
            }
        }

        return dp[time] == int.MaxValue - 1 ? -1 : dp[time];
    }
}
