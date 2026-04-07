namespace LeetCode.Solutions;

public class Solution2094
{
    /// <summary>
    /// 2094. Finding 3-Digit Even Numbers - Easy
    /// <a href="https://leetcode.com/problems/finding-3-digit-even-numbers">See the problem</a>
    /// </summary>
    public int[] FindEvenNumbers(int[] digits)
    {
        var count = new int[10];
        foreach (var d in digits) count[d]++;

        var result = new List<int>();

        for (var num = 100; num < 1000; num += 2)
        {
            var a = num / 100;
            var b = num / 10 % 10;
            var c = num % 10;

            count[a]--;
            count[b]--;
            count[c]--;

            if (count[a] >= 0 && count[b] >= 0 && count[c] >= 0)
                result.Add(num);

            count[a]++;
            count[b]++;
            count[c]++;
        }

        return result.ToArray();
    }
}
