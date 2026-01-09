namespace LeetCode.Solutions;

public class Solution1981
{
    /// <summary>
    /// 1981. Minimize the Difference Between Target and Chosen Elements - Medium
    /// <a href="https://leetcode.com/problems/minimize-the-difference-between-target-and-chosen-elements">See the problem</a>
    /// </summary>
    public int MinimizeTheDifference(int[][] mat, int target)
    {
        HashSet<int> possibleSums = [0];

        foreach (var row in mat)
        {
            HashSet<int> currentSums = [];

            foreach (var num in row)
            {
                foreach (var sum in possibleSums)
                {
                    currentSums.Add(sum + num);
                }
            }

            possibleSums = currentSums;
        }

        int minDiff = int.MaxValue;

        foreach (var sum in possibleSums)
        {
            minDiff = Math.Min(minDiff, Math.Abs(sum - target));
        }

        return minDiff;
    }
}
