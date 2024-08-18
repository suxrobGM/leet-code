namespace LeetCode.Solutions;

public class Solution475
{
    /// <summary>
    /// 475. Heaters - Medium
    /// <a href="https://leetcode.com/problems/heaters">See the problem</a>
    /// </summary>
    public int FindRadius(int[] houses, int[] heaters)
    {
        Array.Sort(heaters);
        var result = 0;

        foreach (var house in houses)
        {
            var index = Array.BinarySearch(heaters, house);
            if (index < 0)
            {
                index = ~index;
                var left = index > 0 ? house - heaters[index - 1] : int.MaxValue;
                var right = index < heaters.Length ? heaters[index] - house : int.MaxValue;
                result = Math.Max(result, Math.Min(left, right));
            }
        }

        return result;
    }
}
