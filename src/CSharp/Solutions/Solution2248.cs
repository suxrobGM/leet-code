namespace LeetCode.Solutions;

public class Solution2248
{
    /// <summary>
    /// 2248. Intersection of Multiple Arrays - Easy
    /// <a href="https://leetcode.com/problems/intersection-of-multiple-arrays">See the problem</a>
    /// </summary>
    public IList<int> Intersection(int[][] nums)
    {
        // Values are bounded by 1000 and each row holds distinct integers,
        // so a counting array is enough to find values present in every row
        var counts = new int[1001];
        foreach (var row in nums)
        {
            foreach (var value in row)
            {
                counts[value]++;
            }
        }

        var result = new List<int>();
        for (var value = 1; value <= 1000; value++)
        {
            if (counts[value] == nums.Length)
            {
                result.Add(value);
            }
        }

        return result;
    }
}
