using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution904
{
    /// <summary>
    /// 904. Fruit Into Baskets - Medium
    /// <a href="https://leetcode.com/problems/fruit-into-baskets">See the problem</a>
    /// </summary>
    public int TotalFruit(int[] fruits)
    {
        int n = fruits.Length;
        int maxFruits = 0;
        int i = 0;
        var fruitCount = new Dictionary<int, int>();

        for (int j = 0; j < n; j++)
        {
            if (!fruitCount.ContainsKey(fruits[j]))
            {
                fruitCount[fruits[j]] = 0;
            }

            fruitCount[fruits[j]]++;

            while (fruitCount.Count > 2)
            {
                fruitCount[fruits[i]]--;

                if (fruitCount[fruits[i]] == 0)
                {
                    fruitCount.Remove(fruits[i]);
                }

                i++;
            }

            maxFruits = Math.Max(maxFruits, j - i + 1);
        }

        return maxFruits;
    }
}
