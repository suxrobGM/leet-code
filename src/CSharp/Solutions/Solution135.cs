namespace LeetCode.Solutions;

public class Solution135
{
    /// <summary>
    /// 135. Candy
    /// <a href="https://leetcode.com/problems/candy">See the problem</a>
    /// </summary>
    public int Candy(int[] ratings)
    {
        var n = ratings.Length;
        var candies = new int[n];
        Array.Fill(candies, 1);

        for (var i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                candies[i] = candies[i - 1] + 1;
            }
        }

        for (var i = n - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
        }

        var totalCandies = candies.Sum();
        return totalCandies;
    }
}
