namespace LeetCode.Solutions;

public class Solution386
{
    /// <summary>
    /// 386. Lexicographical Numbers - Medium
    /// <a href="https://leetcode.com/problems/lexicographical-numbers">See the problem</a>
    /// </summary>
    public IList<int> LexicalOrder(int n)
    {
        var result = new List<int>();
        var current = 1;

        for (var i = 1; i <= n; i++)
        {
            result.Add(current);

            if (current * 10 <= n)
            {
                current *= 10;
            }
            else if (current % 10 != 9 && current + 1 <= n)
            {
                current++;
            }
            else
            {
                while (current % 10 == 9 || current + 1 > n)
                {
                    current /= 10;
                }

                current++;
            }
        }

        return result;
    }
}
