namespace LeetCode.Solutions;

public class Solution2028
{
    /// <summary>
    /// 2028. Find Missing Observations - Medium
    /// <a href="https://leetcode.com/problems/find-missing-observations">See the problem</a>
    /// </summary>
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        var m = rolls.Length;
        var totalSum = mean * (m + n);
        var observedSum = rolls.Sum();
        var missingSum = totalSum - observedSum;

        // Each missing roll must be between 1 and 6
        if (missingSum < n || missingSum > 6 * n)
            return [];

        var missingRolls = new int[n];
        for (var i = 0; i < n; i++)
            missingRolls[i] = 1; // Start with all rolls as 1

        missingSum -= n; // We have already accounted for the minimum value of each roll

        // Distribute the remaining sum across the rolls, ensuring no roll exceeds 6
        for (var i = 0; i < n && missingSum > 0; i++)
        {
            var add = Math.Min(5, missingSum); // We can add at most 5 to each roll (since it starts at 1)
            missingRolls[i] += add;
            missingSum -= add;
        }

        return missingRolls;
    }
}
