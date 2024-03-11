namespace LeetCode.Solutions;

public class Solution1431
{
    /// <summary>
    /// 1431. Kids With the Greatest Number of Candies - Easy
    /// <a href="https://leetcode.com/problems/kids-with-the-greatest-number-of-candies">See the problem</a>
    /// </summary>
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var maxCandies = candies.Max();
        return candies.Select(c => c + extraCandies >= maxCandies).ToList();
    }
}
