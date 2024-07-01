namespace LeetCode.Solutions;

public class Solution275
{
    /// <summary>
    /// 275. H-Index II - Medium
    /// <a href="https://leetcode.com/problems/h-index-ii">See the problem</a>
    /// </summary>
    public int HIndex(int[] citations)
    {
        var n = citations.Length;
        var left = 0;
        var right = n - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (citations[mid] == n - mid)
            {
                return n - mid;
            }
            else if (citations[mid] < n - mid)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return n - left;
    }
}
