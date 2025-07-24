using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1655
{
    /// <summary>
    /// 1655. Distribute Repeating Integers - Hard
    /// <a href="https://leetcode.com/problems/distribute-repeating-integers">See the problem</a>
    /// </summary>
    public bool CanDistribute(int[] nums, int[] quantity)
    {
        var freqMap = nums.GroupBy(x => x).Select(g => g.Count()).ToArray();
        Array.Sort(quantity);
        Array.Reverse(quantity); // Try larger requests first for efficiency

        var memo = new Dictionary<(int, int), bool>(); // (freqIndex, mask)

        return Dfs(0, 0);

        bool Dfs(int i, int mask)
        {
            if (mask == (1 << quantity.Length) - 1) return true;
            if (i == freqMap.Length) return false;
            if (memo.ContainsKey((i, mask))) return memo[(i, mask)];

            int available = freqMap[i];

            // Try all subsets of unvisited customers
            for (int subset = mask ^ ((1 << quantity.Length) - 1); subset > 0; subset = (subset - 1) & (mask ^ ((1 << quantity.Length) - 1)))
            {
                int sum = 0;
                for (int j = 0; j < quantity.Length; j++)
                {
                    if ((subset & (1 << j)) != 0)
                        sum += quantity[j];
                }

                if (sum <= available && Dfs(i + 1, mask | subset))
                {
                    memo[(i, mask)] = true;
                    return true;
                }
            }

            // Try skipping current freq
            if (Dfs(i + 1, mask))
            {
                memo[(i, mask)] = true;
                return true;
            }

            memo[(i, mask)] = false;
            return false;
        }
    }
}
