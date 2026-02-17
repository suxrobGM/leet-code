namespace LeetCode.Solutions;

public class Solution2032
{
    /// <summary>
    /// 2032. Two Out of Three - Easy
    /// <a href="https://leetcode.com/problems/two-out-of-three">See the problem</a>
    /// </summary>
    public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
    {
        var set1 = new HashSet<int>(nums1);
        var set2 = new HashSet<int>(nums2);
        var set3 = new HashSet<int>(nums3);

        var result = new List<int>();
        for (var i = 1; i <= 100; i++)
        {
            var count = 0;
            if (set1.Contains(i))
                count++;
            if (set2.Contains(i))
                count++;
            if (set3.Contains(i))
                count++;

            if (count >= 2)
                result.Add(i);
        }

        return result;
    }
}
