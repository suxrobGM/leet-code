namespace LeetCode.Solutions;

public class Solution2259
{
    /// <summary>
    /// 2259. Remove Digit From Number to Maximize Result - Easy
    /// <a href="https://leetcode.com/problems/remove-digit-from-number-to-maximize-result">See the problem</a>
    /// </summary>
    public string RemoveDigit(string number, char digit)
    {
        var lastOccurrence = -1;

        for (var index = 0; index < number.Length; index++)
        {
            if (number[index] != digit)
            {
                continue;
            }

            lastOccurrence = index;

            // Removing a digit that is smaller than its successor pulls a bigger digit
            // forward, so the leftmost such position yields the maximum result.
            if (index + 1 < number.Length && number[index + 1] > digit)
            {
                return number.Remove(index, 1);
            }
        }

        return number.Remove(lastOccurrence, 1);
    }
}
