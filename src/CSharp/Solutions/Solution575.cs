using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution575
{
    /// <summary>
    /// 575. Distribute Candies - Easy
    /// <a href="https://leetcode.com/problems/distribute-candies">See the problem</a>
    /// </summary>
    public int DistributeCandies(int[] candyType)
    {
        var uniqueCandies = new HashSet<int>(candyType);
        return Math.Min(uniqueCandies.Count, candyType.Length / 2);
    }
}
