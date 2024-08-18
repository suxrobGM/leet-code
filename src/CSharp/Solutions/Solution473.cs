namespace LeetCode.Solutions;

public class Solution473
{
    /// <summary>
    /// 473. Matchsticks to Square - Medium
    /// <a href="https://leetcode.com/problems/matchsticks-to-square">See the problem</a>
    /// </summary>
    public bool Makesquare(int[] matchsticks)
    {
        var totalLength = matchsticks.Sum();
        
        if (totalLength % 4 != 0)
        {
            return false;
        }
            

        var sideLength = totalLength / 4;
        Array.Sort(matchsticks, (a, b) => b.CompareTo(a));  // Sort in descending order

        var sides = new int[4];

        bool Backtrack(int index)
        {
            if (index == matchsticks.Length)
            {
                return sides[0] == sideLength && sides[1] == sideLength && sides[2] == sideLength && sides[3] == sideLength;
            }

            for (int i = 0; i < 4; i++)
            {
                if (sides[i] + matchsticks[index] <= sideLength)
                {
                    sides[i] += matchsticks[index];
                    if (Backtrack(index + 1))
                        return true;
                    sides[i] -= matchsticks[index];
                }

                if (sides[i] == 0)  // If the first stick doesn't fit, no need to try others.
                    break;
            }

            return false;
        }

        return Backtrack(0);
    }
}
