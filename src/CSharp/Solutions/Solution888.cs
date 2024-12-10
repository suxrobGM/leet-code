namespace LeetCode.Solutions;

public class Solution888
{
    /// <summary>
    /// 888. Fair Candy Swap - Easy
    /// <a href="https://leetcode.com/problems/fair-candy-swap">See the problem</a>
    /// </summary>
    public int[] FairCandySwap(int[] aliceSizes, int[] bobSizes)
    {
        var aliceSum = aliceSizes.Sum();
        var bobSum = bobSizes.Sum();
        var diff = (aliceSum - bobSum) / 2;

        var bobSet = new HashSet<int>(bobSizes);

        foreach (var aliceSize in aliceSizes)
        {
            var bobSize = aliceSize - diff;
            if (bobSet.Contains(bobSize))
            {
                return [aliceSize, bobSize];
            }
        }

        return [];
    }
}
