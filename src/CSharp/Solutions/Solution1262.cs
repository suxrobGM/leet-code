using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1262
{
    /// <summary>
    /// 1262. Greatest Sum Divisible by Three - Medium
    /// <a href="https://leetcode.com/problems/greatest-sum-divisible-by-three">See the problem</a>
    /// </summary>
    public int MaxSumDivThree(int[] nums)
    {
        int totalSum = 0;
        var mod1 = new List<int>();
        var mod2 = new List<int>();

        foreach (var num in nums)
        {
            totalSum += num;

            if (num % 3 == 1) mod1.Add(num);
            else if (num % 3 == 2) mod2.Add(num);
        }

        mod1.Sort();
        mod2.Sort();

        if (totalSum % 3 == 0)
            return totalSum;

        int result = 0;

        if (totalSum % 3 == 1)
        {
            int remove1 = mod1.Count >= 1 ? mod1[0] : int.MaxValue;
            int remove2 = mod2.Count >= 2 ? mod2[0] + mod2[1] : int.MaxValue;

            result = totalSum - Math.Min(remove1, remove2);
        }
        else if (totalSum % 3 == 2)
        {
            int remove1 = mod2.Count >= 1 ? mod2[0] : int.MaxValue;
            int remove2 = mod1.Count >= 2 ? mod1[0] + mod1[1] : int.MaxValue;

            result = totalSum - Math.Min(remove1, remove2);
        }

        return result < 0 ? 0 : result;
    }
}
