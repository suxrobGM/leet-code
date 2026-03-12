namespace LeetCode.Solutions;

public class Solution2060
{
    /// <summary>
    /// 2060. Check if an Original String Exists Given Two Encoded Strings - Hard
    /// <a href="https://leetcode.com/problems/check-if-an-original-string-exists-given-two-encoded-strings">See the problem</a>
    /// </summary>
    public bool PossiblyEquals(string s1, string s2)
    {
        var memo = new Dictionary<(int, int, int), bool>();
        return Dfs(s1, s2, 0, 0, 0, memo);
    }

    private static bool Dfs(string s1, string s2, int i, int j, int diff,
        Dictionary<(int, int, int), bool> memo)
    {
        var key = (i, j, diff);
        if (memo.TryGetValue(key, out var cached))
            return cached;

        if (i == s1.Length && j == s2.Length)
            return memo[key] = diff == 0;

        // diff > 0: s1 has extra unmatched chars, consume from s2
        if (diff > 0)
        {
            if (j < s2.Length)
            {
                if (char.IsDigit(s2[j]))
                {
                    var num = 0;
                    for (var k = j; k < s2.Length && char.IsDigit(s2[k]); k++)
                    {
                        num = num * 10 + (s2[k] - '0');
                        if (Dfs(s1, s2, i, k + 1, diff - num, memo))
                            return memo[key] = true;
                    }
                }
                else
                {
                    if (Dfs(s1, s2, i, j + 1, diff - 1, memo))
                        return memo[key] = true;
                }
            }

            return memo[key] = false;
        }

        // diff < 0: s2 has extra unmatched chars, consume from s1
        if (diff < 0)
        {
            if (i < s1.Length)
            {
                if (char.IsDigit(s1[i]))
                {
                    var num = 0;
                    for (var k = i; k < s1.Length && char.IsDigit(s1[k]); k++)
                    {
                        num = num * 10 + (s1[k] - '0');
                        if (Dfs(s1, s2, k + 1, j, diff + num, memo))
                            return memo[key] = true;
                    }
                }
                else
                {
                    if (Dfs(s1, s2, i + 1, j, diff + 1, memo))
                        return memo[key] = true;
                }
            }

            return memo[key] = false;
        }

        // diff == 0: both aligned
        if (i < s1.Length && char.IsDigit(s1[i]))
        {
            var num = 0;
            for (var k = i; k < s1.Length && char.IsDigit(s1[k]); k++)
            {
                num = num * 10 + (s1[k] - '0');
                if (Dfs(s1, s2, k + 1, j, num, memo))
                    return memo[key] = true;
            }

            return memo[key] = false;
        }

        if (j < s2.Length && char.IsDigit(s2[j]))
        {
            var num = 0;
            for (var k = j; k < s2.Length && char.IsDigit(s2[k]); k++)
            {
                num = num * 10 + (s2[k] - '0');
                if (Dfs(s1, s2, i, k + 1, -num, memo))
                    return memo[key] = true;
            }

            return memo[key] = false;
        }

        // Both are letters
        if (i < s1.Length && j < s2.Length && s1[i] == s2[j])
            return memo[key] = Dfs(s1, s2, i + 1, j + 1, 0, memo);

        return memo[key] = false;
    }
}
