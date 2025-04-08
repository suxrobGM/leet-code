using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1217
{
    /// <summary>
    /// 1217. Minimum Cost to Move Chips to The Same Position - Easy
    /// <a href="https://leetcode.com/problems/minimum-cost-to-move-chips-to-the-same-position">See the problem</a>
    /// </summary>
    public int MinCostToMoveChips(int[] position)
    {
        int oddCount = 0;
        int evenCount = 0;

        foreach (var pos in position)
        {
            if (pos % 2 == 0)
                evenCount++;
            else
                oddCount++;
        }

        return Math.Min(oddCount, evenCount);
    }
}
