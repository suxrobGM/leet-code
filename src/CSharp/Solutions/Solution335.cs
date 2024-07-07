namespace LeetCode.Solutions;

public class Solution335
{
    /// <summary>
    /// 335. Self Crossing - Hard
    /// <a href="https://leetcode.com/problems/self-crossing">See the problem</a>
    /// </summary>
    public bool IsSelfCrossing(int[] distance)
    {
        if (distance.Length < 4)
        {
            return false;
        }

        for (var i = 3; i < distance.Length; i++)
        {
            if (distance[i] >= distance[i - 2] && distance[i - 1] <= distance[i - 3])
            {
                return true;
            }

            if (i >= 4 && distance[i - 1] == distance[i - 3] && distance[i] + distance[i - 4] >= distance[i - 2])
            {
                return true;
            }

            if (i >= 5 &&
                distance[i - 2] >= distance[i - 4] &&
                distance[i] + distance[i - 4] >= distance[i - 2] &&
                distance[i - 1] <= distance[i - 3] &&
                distance[i - 1] + distance[i - 5] >= distance[i - 3]
            )
            {
                return true;
            }
        }

        return false;
    }
}
