using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution954
{
    /// <summary>
    /// 954. Array of Doubled Pairs - Medium
    /// <a href="https://leetcode.com/problems/array-of-doubled-pairs">See the problem</a>
    /// </summary>
    public bool CanReorderDoubled(int[] arr)
    {
        var count = new Dictionary<int, int>();
        var sortedArr = arr.OrderBy(x => x).ToArray();

        foreach (var num in arr)
        {
            count[num] = count.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var num in sortedArr)
        {
            if (count[num] == 0)
            {
                continue;
            }

            if (num < 0)
            {
                if (num % 2 != 0 || count.GetValueOrDefault(num / 2, 0) < count[num])
                {
                    return false;
                }

                count[num / 2] -= count[num];
            }
            else
            {
                if (count.GetValueOrDefault(num * 2, 0) < count[num])
                {
                    return false;
                }

                count[num * 2] -= count[num];
            }

            count[num] = 0;
        }

        return true;
    }
}
