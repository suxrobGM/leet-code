namespace LeetCode.Solutions;

public class Solution2171
{
    /// <summary>
    /// 2171. Removing Minimum Number of Magic Beans - Medium
    /// <a href="https://leetcode.com/problems/removing-minimum-number-of-magic-beans">See the problem</a>
    /// </summary>
    public long MinimumRemoval(int[] beans)
    {
        Array.Sort(beans);
        long total = beans.Sum(x => (long)x);
        long max = 0;
        long current = 0;
        for (int i = 0; i < beans.Length; i++)
        {
            current += beans[i];
            max = Math.Max(max, (long)beans[i] * (beans.Length - i));
        }
        return total - max;
    }
}
