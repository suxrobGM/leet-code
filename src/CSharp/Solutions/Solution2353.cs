namespace LeetCode.Solutions;

public class Solution2353
{
    /// <summary>
    /// 2353. Design a Food Rating System - Medium
    /// <a href="https://leetcode.com/problems/design-a-food-rating-system">See the problem</a>
    /// </summary>
    public class FoodRatings
    {
        private readonly Dictionary<string, (string Cuisine, int Rating)> _foods;
        private readonly Dictionary<string, SortedSet<(int Rating, string Food)>> _foodsByCuisine;

        public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
        {
            _foods = [];
            _foodsByCuisine = [];
            var comparer = Comparer<(int Rating, string Food)>.Create((a, b) =>
            {
                // Highest rating first; break ties by the lexicographically smallest name.
                int ratingComparison = b.Rating.CompareTo(a.Rating);
                return ratingComparison != 0
                    ? ratingComparison
                    : StringComparer.Ordinal.Compare(a.Food, b.Food);
            });

            for (int i = 0; i < foods.Length; i++)
            {
                _foods[foods[i]] = (cuisines[i], ratings[i]);
                if (!_foodsByCuisine.TryGetValue(cuisines[i], out var cuisineFoods))
                {
                    cuisineFoods = new SortedSet<(int Rating, string Food)>(comparer);
                    _foodsByCuisine[cuisines[i]] = cuisineFoods;
                }

                cuisineFoods.Add((ratings[i], foods[i]));
            }
        }

        public void ChangeRating(string food, int newRating)
        {
            var (cuisine, oldRating) = _foods[food];
            if (oldRating == newRating)
            {
                return;
            }

            var cuisineFoods = _foodsByCuisine[cuisine];
            cuisineFoods.Remove((oldRating, food));
            cuisineFoods.Add((newRating, food));
            _foods[food] = (cuisine, newRating);
        }

        public string HighestRated(string cuisine)
        {
            return _foodsByCuisine[cuisine].Min.Food;
        }
    }
}
