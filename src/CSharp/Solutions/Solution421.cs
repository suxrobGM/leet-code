using System.Text;

namespace LeetCode.Solutions;

public class Solution421
{
    /// <summary>
    /// 421. Maximum XOR of Two Numbers in an Array - Medium
    /// <a href="https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array">See the problem</a>
    /// </summary>
    public int FindMaximumXOR(int[] nums)
    {
        var max = 0;
        var mask = 0;

        for (var i = 31; i >= 0; i--)
        {
            mask |= 1 << i;

            var set = new HashSet<int>();

            foreach (var num in nums)
            {
                set.Add(num & mask);
            }

            var temp = max | (1 << i);

            foreach (var prefix in set)
            {
                if (set.Contains(temp ^ prefix))
                {
                    max = temp;
                    break;
                }
            }
        }

        return max;
    }
}
