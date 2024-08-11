namespace LeetCode.Solutions;

public class Solution458
{
    /// <summary>
    /// 458. Poor Pigs - Hard
    /// <a href="https://leetcode.com/problems/poor-pigs">See the problem</a>
    /// </summary>
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest) 
    {
        int pigs = 0;
        int tests = minutesToTest / minutesToDie + 1;
        while (Math.Pow(tests, pigs) < buckets)
        {
            pigs++;
        }
        return pigs;
    }
}
