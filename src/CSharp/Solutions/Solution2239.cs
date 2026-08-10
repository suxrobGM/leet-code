namespace LeetCode.Solutions;

public class Solution2239
{
    /// <summary>
    /// 2239. Find Closest Number to Zero - Easy
    /// <a href="https://leetcode.com/problems/find-closest-number-to-zero">See the problem</a>
    /// </summary>
    public int FindClosestNumber(int[] nums)
    {
        var closest = nums[0];

        foreach (var num in nums)
        {
            var distance = Math.Abs(num);
            var closestDistance = Math.Abs(closest);

            if (distance < closestDistance || (distance == closestDistance && num > closest))
            {
                closest = num;
            }
        }

        return closest;
    }
}
