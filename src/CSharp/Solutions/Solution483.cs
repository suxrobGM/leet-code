namespace LeetCode.Solutions;

public class Solution483
{
    /// <summary>
    /// 483. Smallest Good Base - Hard
    /// <a href="https://leetcode.com/problems/smallest-good-base">See the problem</a>
    /// </summary>
    public string SmallestGoodBase(string n)
    {
        var num = long.Parse(n);
        var maxM = (int)Math.Floor(Math.Log(num) / Math.Log(2));
        for (var m = maxM; m > 1; m--)
        {
            var k = (long)Math.Pow(num, 1.0 / m);
            var sum = 1L;
            var mul = 1L;
            for (var i = 1; i <= m; i++)
            {
                mul *= k;
                sum += mul;
            }
            if (sum == num) return k.ToString();
        }
        return (num - 1).ToString();
    }
}
