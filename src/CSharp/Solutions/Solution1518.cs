using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1518
{
    /// <summary>
    /// 1518. Water Bottles - Easy
    /// <a href="https://leetcode.com/problems/water-bottles">See the problem</a>
    /// </summary>
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        int totalDrunk = numBottles;
        int emptyBottles = numBottles;

        while (emptyBottles >= numExchange)
        {
            int newBottles = emptyBottles / numExchange;
            totalDrunk += newBottles;
            emptyBottles = newBottles + (emptyBottles % numExchange);
        }

        return totalDrunk;
    }
}
