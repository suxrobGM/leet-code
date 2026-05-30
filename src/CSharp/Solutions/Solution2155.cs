namespace LeetCode.Solutions;

public class Solution2155
{
    /// <summary>
    /// 2155. All Divisions With the Highest Score of a Binary Array - Medium
    /// <a href="https://leetcode.com/problems/all-divisions-with-the-highest-score-of-a-binary-array">See the problem</a>
    /// </summary>
    public IList<int> MaxScoreIndices(int[] nums)
    {
        int n = nums.Length;
        int totalOnes = 0;
        foreach (int x in nums) totalOnes += x;

        int leftZeros = 0, rightOnes = totalOnes;
        int best = rightOnes;
        var result = new List<int> { 0 };

        for (int i = 1; i <= n; i++)
        {
            if (nums[i - 1] == 0) leftZeros++;
            else rightOnes--;

            int score = leftZeros + rightOnes;
            if (score > best)
            {
                best = score;
                result.Clear();
                result.Add(i);
            }
            else if (score == best)
            {
                result.Add(i);
            }
        }
        return result;
    }
}
