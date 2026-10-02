using System.Text;

namespace LeetCode.Solutions;

public class Solution2300
{
    /// <summary>
    /// 2300. Successful Pairs of Spells and Potions - Medium
    /// <a href="https://leetcode.com/problems/successful-pairs-of-spells-and-potions">See the problem</a>
    /// </summary>
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        var result = new int[spells.Length];

        for (var i = 0; i < spells.Length; i++)
        {
            var spell = spells[i];
            var left = 0;
            var right = potions.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if ((long)spell * potions[mid] >= success)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            result[i] = potions.Length - left;
        }

        return result;
    }
}
