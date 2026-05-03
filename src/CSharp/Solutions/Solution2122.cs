namespace LeetCode.Solutions;

public class Solution2122
{
    /// <summary>
    /// 2122. Recover the Original Array - Hard
    /// <a href="https://leetcode.com/problems/recover-the-original-array">See the problem</a>
    /// </summary>
    public int[] RecoverArray(int[] nums)
    {
        Array.Sort(nums);
        var n = nums.Length;
        var result = new int[n / 2];

        for (var j = 1; j < n; j++)
        {
            var diff = nums[j] - nums[0];
            if (diff <= 0 || diff % 2 != 0)
            {
                continue;
            }

            var k = diff / 2;
            var count = nums.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            var idx = 0;
            var ok = true;
            foreach (var x in nums)
            {
                if (count[x] == 0)
                {
                    continue;
                }

                var target = x + 2 * k;
                if (!count.TryGetValue(target, out var c) || c == 0)
                {
                    ok = false;
                    break;
                }

                count[x]--;
                count[target]--;
                result[idx++] = x + k;
            }

            if (ok && idx == n / 2)
            {
                return result;
            }
        }

        return Array.Empty<int>();
    }
}
