using System.Text;

namespace LeetCode.Solutions;

public class Solution350
{
    /// <summary>
    /// 350. Intersection of Two Arrays II - Easy
    /// <a href="https://leetcode.com/problems/intersection-of-two-arrays">See the problem</a>
    /// </summary>
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var frequency = new Dictionary<int, int>();
        var result = new List<int>();

        foreach (var num in nums1)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var num in nums2)
        {
            if (frequency.ContainsKey(num) && frequency[num] > 0)
            {
                result.Add(num);
                frequency[num]--;
            }
        }

        return result.ToArray();
    }
}
