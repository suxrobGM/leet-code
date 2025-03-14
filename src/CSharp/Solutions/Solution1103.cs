using System.Text;

namespace LeetCode.Solutions;

public class Solution1103
{
    /// <summary>
    /// 1103. Distribute Candies to People - Easy
    /// <a href="https://leetcode.com/problems/distribute-candies-to-people">See the problem</a>
    /// </summary>
    public int[] DistributeCandies(int candies, int num_people)
    {
        var result = new int[num_people];
        var i = 0;

        while (candies > 0)
        {
            result[i % num_people] += Math.Min(candies, i + 1);
            candies -= i + 1;
            i++;
        }
        return result;
    }
}
