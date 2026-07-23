namespace LeetCode.Solutions;

public class Solution2215
{
    /// <summary>
    /// 2215. Find the Difference of Two Arrays - Easy
    /// <a href="https://leetcode.com/problems/find-the-difference-of-two-arrays">See the problem</a>
    /// </summary>
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        var set1 = new HashSet<int>(nums1);
        var set2 = new HashSet<int>(nums2);

        var result1 = new List<int>();
        var result2 = new List<int>();

        foreach (var num in set1)
        {
            if (!set2.Contains(num))
            {
                result1.Add(num);
            }
        }

        foreach (var num in set2)
        {
            if (!set1.Contains(num))
            {
                result2.Add(num);
            }
        }

        return [result1, result2];
    }
}
