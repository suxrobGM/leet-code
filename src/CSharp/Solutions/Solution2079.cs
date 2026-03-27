namespace LeetCode.Solutions;

public class Solution2079
{
    /// <summary>
    /// 2079. Watering Plants - Medium
    /// <a href="https://leetcode.com/problems/watering-plants">See the problem</a>
    /// </summary>
    public int WateringPlants(int[] plants, int capacity)
    {
        var result = 0;
        var current = capacity;

        for (var i = 0; i < plants.Length; i++)
        {
            if (current < plants[i])
            {
                result += 2 * i;
                current = capacity;
            }

            current -= plants[i];
            result++;
        }

        return result;
    }
}
