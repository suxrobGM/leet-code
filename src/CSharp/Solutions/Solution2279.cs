namespace LeetCode.Solutions;

public class Solution2279
{
    /// <summary>
    /// 2279. Maximum Bags With Full Capacity of Rocks - Medium
    /// <a href="https://leetcode.com/problems/maximum-bags-with-full-capacity-of-rocks">See the problem</a>
    /// </summary>
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
    {
        var remainingCapacity = new int[capacity.Length];

        for (var i = 0; i < capacity.Length; i++)
        {
            remainingCapacity[i] = capacity[i] - rocks[i];
        }

        Array.Sort(remainingCapacity);

        var fullBagsCount = 0;

        foreach (var remaining in remainingCapacity)
        {
            if (remaining <= additionalRocks)
            {
                fullBagsCount++;
                additionalRocks -= remaining;
            }
            else
            {
                break;
            }
        }

        return fullBagsCount;
    }
}
