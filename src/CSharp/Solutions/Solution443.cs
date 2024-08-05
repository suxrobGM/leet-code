namespace LeetCode.Solutions;

public class Solution443
{
    /// <summary>
    /// 443. String Compression - Medium
    /// <a href="https://leetcode.com/problems/string-compression">See the problem</a>
    /// </summary>
    public int Compress(char[] chars)
    {
        var index = 0;
        var i = 0;

        while (i < chars.Length)
        {
            var j = i;

            while (j < chars.Length && chars[j] == chars[i])
            {
                j++;
            }

            chars[index++] = chars[i];

            if (j - i > 1)
            {
                var count = j - i;

                foreach (var c in count.ToString())
                {
                    chars[index++] = c;
                }
            }

            i = j;
        }

        return index;
    }
}
