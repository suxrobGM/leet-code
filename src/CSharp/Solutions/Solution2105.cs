using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2105
{
    /// <summary>
    /// 2105. Watering Plants II - Medium
    /// <a href="https://leetcode.com/problems/watering-plants-ii">See the problem</a>
    /// </summary>
    public int MinimumRefill(int[] plants, int capacityA, int capacityB)
    {
        int i = 0, j = plants.Length - 1;
        int a = capacityA, b = capacityB;
        var refills = 0;

        while (i < j)
        {
            if (a < plants[i])
            {
                refills++;
                a = capacityA;
            }
            a -= plants[i];

            if (b < plants[j])
            {
                refills++;
                b = capacityB;
            }
            b -= plants[j];

            i++;
            j--;
        }

        if (i == j && Math.Max(a, b) < plants[i])
        {
            refills++;
        }

        return refills;
    }
}
