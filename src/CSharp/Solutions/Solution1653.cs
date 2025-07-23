using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1653
{
    /// <summary>
    /// 1653. Minimum Deletions to Make String Balanced - Medium
    /// <a href="https://leetcode.com/problems/minimum-deletions-to-make-string-balanced">See the problem</a>
    /// </summary>
    public int MinimumDeletions(string s)
    {
        int rightA = s.Count(c => c == 'a');
        int leftB = 0, minDeletions = rightA;

        foreach (char c in s)
        {
            if (c == 'a')
                rightA--; // 'a' moves from right side
            else
                leftB++;  // another 'b' on the left

            minDeletions = Math.Min(minDeletions, leftB + rightA);
        }

        return minDeletions;
    }
}
