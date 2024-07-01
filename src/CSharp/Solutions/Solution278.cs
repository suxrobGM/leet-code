namespace LeetCode.Solutions;

public class Solution278
{
    public bool IsBadVersion(int version) => true;


    /// <summary>
    /// 278. First Bad Version - Easy
    /// <a href="https://leetcode.com/problems/first-bad-version">See the problem</a>
    /// </summary>
    public int FirstBadVersion(int n)
    {
        var left = 1;
        var right = n;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (IsBadVersion(mid))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left;
    }
}
