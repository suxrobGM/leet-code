using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1946
{
    /// <summary>
    /// 1946. Largest Number After Mutating Substring - Medium
    /// <a href="https://leetcode.com/problems/largest-number-after-mutating-substring">See the problem</a>
    /// </summary>
    public string MaximumNumber(string num, int[] change)
    {
        var sb = new StringBuilder(num);
        var changed = false;

        for (var i = 0; i < num.Length; i++)
        {
            var n = num[i] - '0';

            if (n <= change[n])
            {
                if (n < change[n])
                {
                    changed = true;
                }

                if (changed)
                {
                    sb[i] = (char)('0' + change[n]);
                }
            }
            else
            {
                if (changed)
                {
                    break;
                }
            }
        }

        return sb.ToString();
    }
}
