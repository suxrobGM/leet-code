using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1854
{
    /// <summary>
    /// 1854. Maximum Population Year - Easy
    /// <a href="https://leetcode.com/problems/maximum-population-year">See the problem</a>
    /// </summary>
    public int MaximumPopulation(int[][] logs)
    {
        int[] population = new int[2051];
        foreach (var log in logs)
        {
            population[log[0]]++;
            population[log[1]]--;
        }

        int maxPop = 0, year = 0, currPop = 0;
        for (int i = 1950; i <= 2050; i++)
        {
            currPop += population[i];
            if (currPop > maxPop)
            {
                maxPop = currPop;
                year = i;
            }
        }
        return year;
    }
}
