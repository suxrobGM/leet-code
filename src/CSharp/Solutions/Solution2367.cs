namespace LeetCode.Solutions;

public class Solution2367
{
    /// <summary>
    /// 2367. Number of Arithmetic Triplets - Easy
    /// <a href="https://leetcode.com/problems/number-of-arithmetic-triplets">See the problem</a>
    /// </summary>
    public int ArithmeticTriplets(int[] nums, int diff)
    {
        var seen = new HashSet<int>();
        int count = 0;

        foreach (int num in nums)
        {
            if (seen.Contains(num - diff) && seen.Contains(num - 2 * diff))
            {
                count++;
            }

            seen.Add(num);
        }

        return count;
    }
}
