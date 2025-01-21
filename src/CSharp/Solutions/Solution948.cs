using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution948
{
    /// <summary>
    /// 948. Bag of Tokens - Medium
    /// <a href="https://leetcode.com/problems/bag-of-tokens">See the problem</a>
    /// </summary>
    public int BagOfTokensScore(int[] tokens, int power)
    {
        Array.Sort(tokens);
        var left = 0;
        var right = tokens.Length - 1;
        var score = 0;
        var maxScore = 0;

        while (left <= right)
        {
            if (power >= tokens[left])
            {
                power -= tokens[left];
                score++;
                maxScore = Math.Max(maxScore, score);
                left++;
            }
            else if (score > 0)
            {
                power += tokens[right];
                score--;
                right--;
            }
            else
            {
                break;
            }
        }

        return maxScore;
    }
}
