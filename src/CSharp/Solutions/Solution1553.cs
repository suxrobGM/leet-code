using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1553
{
    /// <summary>
    /// 1553. Minimum Number of Days to Eat N Oranges - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-days-to-eat-n-oranges">See the problem</a>
    /// </summary>
    public int MinDays(int n)
    {
        var memo = new Dictionary<int, int>();

        if (n <= 1) return n;
        if (memo.ContainsKey(n)) return memo[n];

        int by2 = n % 2 + 1 + MinDays(n / 2);  // eat mod + 1 day to eat n/2
        int by3 = n % 3 + 1 + MinDays(n / 3);  // eat mod + 1 day to eat 2n/3

        int result = Math.Min(by2, by3);
        memo[n] = result;
        return result;
    }
}
