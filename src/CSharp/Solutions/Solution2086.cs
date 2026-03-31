namespace LeetCode.Solutions;

public class Solution2086
{
    /// <summary>
    /// 2086. Minimum Number of Food Buckets to Feed the Hamsters - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-food-buckets-to-feed-the-hamsters">See the problem</a>
    /// </summary>
    public int MinimumBuckets(string hamsters)
    {
        var n = hamsters.Length;
        var fed = new bool[n];
        var buckets = 0;

        for (var i = 0; i < n; i++)
        {
            if (hamsters[i] != 'H' || fed[i]) continue;

            if (i + 1 < n && hamsters[i + 1] == '.')
            {
                buckets++;
                if (i + 2 < n && hamsters[i + 2] == 'H')
                    fed[i + 2] = true;
            }
            else if (i - 1 >= 0 && hamsters[i - 1] == '.')
                buckets++;
            else
                return -1;
        }

        return buckets;
    }
}
