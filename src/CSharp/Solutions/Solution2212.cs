namespace LeetCode.Solutions;

public class Solution2212
{
    /// <summary>
    /// 2212. Maximum Points in an Archery Competition - Medium
    /// <a href="https://leetcode.com/problems/maximum-points-in-an-archery-competition">See the problem</a>
    /// </summary>
    public int[] MaximumBobPoints(int numArrows, int[] aliceArrows)
    {
        var maxScore = 0;
        var bestDistribution = new int[12];

        // Iterate through all possible distributions of arrows for Bob
        for (var mask = 0; mask < (1 << 12); mask++)
        {
            var bobArrows = new int[12];
            var arrowsUsed = 0;
            var score = 0;

            for (var i = 0; i < 12; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    bobArrows[i] = aliceArrows[i] + 1;
                    arrowsUsed += bobArrows[i];
                    score += i;
                }
            }

            if (arrowsUsed <= numArrows && score > maxScore)
            {
                maxScore = score;
                bestDistribution = bobArrows;
            }
        }

        // If there are remaining arrows, distribute them to the first index
        var remainingArrows = numArrows - bestDistribution.Sum();
        if (remainingArrows > 0)
        {
            bestDistribution[0] += remainingArrows;
        }

        return bestDistribution;
    }
}
