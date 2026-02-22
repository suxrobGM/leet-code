namespace LeetCode.Solutions;

public class Solution2038
{
    /// <summary>
    /// 2038. Remove Colored Pieces if Both Neighbors are the Same Color - Medium
    /// <a href="https://leetcode.com/problems/remove-colored-pieces-if-both-neighbors-are-the-same-color">See the problem</a>
    /// </summary>
    public bool WinnerOfGame(string colors)
    {
        var alice = 0;
        var bob = 0;

        for (var i = 1; i < colors.Length - 1; i++)
        {
            if (colors[i] == 'A' && colors[i - 1] == 'A' && colors[i + 1] == 'A')
                alice++;
            else if (colors[i] == 'B' && colors[i - 1] == 'B' && colors[i + 1] == 'B')
                bob++;
        }

        return alice > bob;
    }
}
