using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1333
{
    /// <summary>
    /// 1333. Filter Restaurants by Vegan-Friendly, Price and Distance - Medium
    /// <a href="https://leetcode.com/problems/filter-restaurants-by-vegan-friendly-price-and-distance">See the problem</a>
    /// </summary>
    public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
    {
        var filteredRestaurants = new List<int>();
        foreach (var restaurant in restaurants)
        {
            int id = restaurant[0];
            int rating = restaurant[1];
            int price = restaurant[2];
            int distance = restaurant[3];

            if ((veganFriendly == 0 || restaurant[4] == 1) && price <= maxPrice && distance <= maxDistance)
            {
                filteredRestaurants.Add(id);
            }
        }

        filteredRestaurants.Sort((a, b) => b.CompareTo(a)); // Sort by id in descending order
        return filteredRestaurants;
    }
}
