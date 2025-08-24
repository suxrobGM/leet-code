using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1753
{
    /// <summary>
    /// 1753. Maximum Score From Removing Stones - Medium
    /// <a href="https://leetcode.com/problems/maximum-score-from-removing-stones">See the problem</a>
    /// </summary>
    public int MaximumScore(int a, int b, int c)
    {
        int[] stones = [a, b, c];
        Array.Sort(stones);
        int score = 0;

        while (stones[2] > 0 && stones[1] > 0)
        {
            score++;
            stones[2]--;
            stones[1]--;
            Array.Sort(stones);
        }

        return score;
    }
}
