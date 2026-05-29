namespace LeetCode.Solutions;

public class Solution2154
{
    /// <summary>
    /// 2154. Keep Multiplying Found Values by Two - Easy
    /// <a href="https://leetcode.com/problems/keep-multiplying-found-values-by-two">See the problem</a>
    /// </summary>
    public int FindFinalValue(int[] nums, int original)
    {
        var numSet = new HashSet<int>(nums);
        int currentValue = original;

        while (numSet.Contains(currentValue))
        {
            currentValue *= 2;
        }

        return currentValue;
    }
}
