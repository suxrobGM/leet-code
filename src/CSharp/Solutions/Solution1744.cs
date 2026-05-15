using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1744
{
    /// <summary>
    /// 1744. Can You Eat Your Favorite Candy on Your Favorite Day? - Medium
    /// <a href="https://leetcode.com/problems/can-you-eat-your-favorite-candy-on-your-favorite-day">See the problem</a>
    /// </summary>
    public bool[] CanEat(int[] candiesCount, int[][] queries)
    {
        long[] prefix = new long[candiesCount.Length + 1];
        for (int i = 0; i < candiesCount.Length; i++)
        {
            prefix[i + 1] = prefix[i] + candiesCount[i];
        }

        bool[] answer = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int favoriteType = queries[i][0];
            int favoriteDay = queries[i][1];
            int dailyCap = queries[i][2];

            long minimumEaten = favoriteDay + 1L;
            long maximumEaten = (favoriteDay + 1L) * dailyCap;
            long beforeFavoriteType = prefix[favoriteType];
            long throughFavoriteType = prefix[favoriteType + 1];

            answer[i] = maximumEaten > beforeFavoriteType && minimumEaten <= throughFavoriteType;
        }

        return answer;
    }
}
