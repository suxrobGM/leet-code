namespace LeetCode.Solutions;

public class Solution2281
{
    private const long Modulo = 1_000_000_007;

    /// <summary>
    /// 2281. Sum of Total Strength of Wizards - Hard
    /// <a href="https://leetcode.com/problems/sum-of-total-strength-of-wizards">See the problem</a>
    /// </summary>
    public int TotalStrength(int[] strength)
    {
        var n = strength.Length;
        var previousLess = new int[n];
        var nextLessOrEqual = new int[n];
        var stack = new Stack<int>();

        for (var i = 0; i < n; i++)
        {
            while (stack.Count > 0 && strength[stack.Peek()] >= strength[i])
            {
                stack.Pop();
            }

            previousLess[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        stack.Clear();

        for (var i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && strength[stack.Peek()] > strength[i])
            {
                stack.Pop();
            }

            nextLessOrEqual[i] = stack.Count == 0 ? n : stack.Peek();
            stack.Push(i);
        }

        var prefixSum = new long[n + 1];
        var prefixOfPrefix = new long[n + 2];

        for (var i = 0; i < n; i++)
        {
            prefixSum[i + 1] = (prefixSum[i] + strength[i]) % Modulo;
            prefixOfPrefix[i + 2] = (prefixOfPrefix[i + 1] + prefixSum[i + 1]) % Modulo;
        }

        long answer = 0;

        for (var i = 0; i < n; i++)
        {
            var left = previousLess[i];
            var right = nextLessOrEqual[i];
            long leftChoices = i - left;
            long rightChoices = right - i;

            var rightPrefixSum = (prefixOfPrefix[right + 1] - prefixOfPrefix[i + 1] + Modulo) % Modulo;
            var leftPrefixSum = (prefixOfPrefix[i + 1] - prefixOfPrefix[left + 1] + Modulo) % Modulo;
            var subarraySum = (rightPrefixSum * leftChoices - leftPrefixSum * rightChoices) % Modulo;

            answer = (answer + strength[i] * subarraySum) % Modulo;
        }

        return (int)((answer + Modulo) % Modulo);
    }
}
