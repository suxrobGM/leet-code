namespace LeetCode.Solutions;

public class Solution2178
{
    /// <summary>
    /// 2178. Maximum Split of Positive Even Integers - Medium
    /// <a href="https://leetcode.com/problems/maximum-split-of-positive-even-integers">See the problem</a>
    /// </summary>
    public IList<long> MaximumEvenSplit(long finalSum)
    {
        if (finalSum % 2 != 0)
        {
            return new List<long>();
        }

        var result = new List<long>();
        long current = 2;
        while (finalSum > 0)
        {
            if (finalSum - current > current)
            {
                result.Add(current);
                finalSum -= current;
                current += 2;
            }
            else
            {
                result.Add(finalSum);
                break;
            }
        }

        return result;
    }
}
