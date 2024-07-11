using System.Text;

namespace LeetCode.Solutions;

public class Solution349
{
    /// <summary>
    /// 349. Intersection of Two Arrays - Easy
    /// <a href="https://leetcode.com/problems/intersection-of-two-arrays">See the problem</a>
    /// </summary>
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var set1 = new HashSet<int>(nums1);
        var set2 = new HashSet<int>(nums2);
        var result = new List<int>();

        foreach (var num in set1)
        {
            if (set2.Contains(num))
            {
                result.Add(num);
            }
        }

        return result.ToArray();
    }
}
