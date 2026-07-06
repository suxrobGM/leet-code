namespace LeetCode.Solutions;

public class Solution2195
{
    /// <summary>
    /// 2195. Append K Integers With Minimal Sum - Medium
    /// <a href="https://leetcode.com/problems/append-k-integers-with-minimal-sum">See the problem</a>
    /// </summary>
    public long MinimalKSum(int[] nums, int k)
    {
        Array.Sort(nums);

        var sum = 0L;
        var remaining = (long)k;
        var current = 1L; // next candidate integer to append

        foreach (var num in nums)
        {
            if (remaining == 0)
            {
                break;
            }

            if (num <= current)
            {
                // Skip duplicates and values already covered.
                current = Math.Max(current, num + 1);
                continue;
            }

            // Integers in [current, num - 1] are available to append.
            var available = Math.Min(remaining, num - current);
            var last = current + available - 1;
            sum += (current + last) * available / 2;
            remaining -= available;
            current = num + 1;
        }

        if (remaining > 0)
        {
            var last = current + remaining - 1;
            sum += (current + last) * remaining / 2;
        }

        return sum;
    }
}
