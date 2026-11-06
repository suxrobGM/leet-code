namespace LeetCode.Solutions;

public class Solution2344
{
    /// <summary>
    /// 2344. Minimum Deletions to Make Array Divisible - Hard
    /// <a href="https://leetcode.com/problems/minimum-deletions-to-make-array-divisible">See the problem</a>
    /// </summary>
    public int MinOperations(int[] nums, int[] numsDivide)
    {
        int gcd = numsDivide[0];
        foreach (int value in numsDivide)
        {
            int remaining = value;
            while (remaining != 0)
                (gcd, remaining) = (remaining, gcd % remaining);
        }

        // A valid minimum must divide the GCD of every value in numsDivide.
        int smallestDivisor = int.MaxValue;
        foreach (int value in nums)
        {
            if (gcd % value == 0 && value < smallestDivisor)
                smallestDivisor = value;
        }

        if (smallestDivisor == int.MaxValue)
            return -1;

        // Delete exactly the elements smaller than the smallest valid minimum.
        int deletions = 0;
        foreach (int value in nums)
        {
            if (value < smallestDivisor)
                deletions++;
        }

        return deletions;
    }
}
