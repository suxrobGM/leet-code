namespace LeetCode.Solutions;

public class Solution2224
{
    /// <summary>
    /// 2224. Minimum Number of Operations to Convert Time - Easy
    /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-convert-time">See the problem</a>
    /// </summary>
    public int ConvertTime(string current, string correct)
    {
        int currentTime = (current[0] - '0') * 10 + (current[1] - '0');
        currentTime *= 60;
        currentTime += (current[3] - '0') * 10 + (current[4] - '0');

        int correctTime = (correct[0] - '0') * 10 + (correct[1] - '0');
        correctTime *= 60;
        correctTime += (correct[3] - '0') * 10 + (correct[4] - '0');

        int diff = correctTime - currentTime;
        int result = 0;

        foreach (int op in new[] { 60, 15, 5, 1 })
        {
            result += diff / op;
            diff %= op;
        }

        return result;
    }
}
