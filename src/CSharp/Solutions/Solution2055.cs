namespace LeetCode.Solutions;

public class Solution2055
{
    /// <summary>
    /// 2055. Plates Between Candles - Medium
    /// <a href="https://leetcode.com/problems/plates-between-candles">See the problem</a>
    /// </summary>
    public int[] PlatesBetweenCandles(string s, int[][] queries)
    {
        var n = s.Length;
        var prefixSum = new int[n];
        var leftCandle = new int[n];
        var rightCandle = new int[n];
        var count = 0;
        var lastCandle = -1;
        for (var i = 0; i < n; i++)
        {
            if (s[i] == '*')
                count++;
            else
                lastCandle = i;
            prefixSum[i] = count;
            leftCandle[i] = lastCandle;
        }

        lastCandle = -1;
        for (var i = n - 1; i >= 0; i--)
        {
            if (s[i] == '|')
                lastCandle = i;
            rightCandle[i] = lastCandle;
        }

        var result = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            var left = rightCandle[queries[i][0]];
            var right = leftCandle[queries[i][1]];
            if (left != -1 && right != -1 && left < right)
                result[i] = prefixSum[right] - prefixSum[left];
        }

        return result;
    }
}
