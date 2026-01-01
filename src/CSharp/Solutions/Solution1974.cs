namespace LeetCode.Solutions;

public class Solution1974
{
    /// <summary>
    /// 1974. Minimum Time to Type Word Using Special Typewriter - Easy
    /// <a href="https://leetcode.com/problems/minimum-time-to-type-word-using-special-typewriter">See the problem</a>
    /// </summary>
    public int MinTimeToType(string word)
    {
        int totalTime = 0;
        char currentChar = 'a';

        foreach (char targetChar in word)
        {
            int clockwiseDistance = Math.Abs(targetChar - currentChar);
            int counterClockwiseDistance = 26 - clockwiseDistance;
            totalTime += Math.Min(clockwiseDistance, counterClockwiseDistance) + 1; // +1 for typing the character
            currentChar = targetChar;
        }

        return totalTime;
    }
}
