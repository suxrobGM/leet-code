using System.Text;


namespace LeetCode.Solutions;

public class Solution1710
{
    /// <summary>
    /// 1710. Maximum Units on a Truck - Easy
    /// <a href="https://leetcode.com/problems/maximum-units-on-a-truck">See the problem</a>
    /// </summary>
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        Array.Sort(boxTypes, (a, b) => b[1].CompareTo(a[1])); // Sort by units per box (descending)

        int maxUnits = 0;
        foreach (var box in boxTypes)
        {
            int count = Math.Min(box[0], truckSize);
            maxUnits += count * box[1];
            truckSize -= count;
            if (truckSize == 0) break;
        }

        return maxUnits;
    }
}
