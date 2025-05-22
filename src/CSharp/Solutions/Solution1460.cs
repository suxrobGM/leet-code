using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1460
{
    /// <summary>
    /// 1460. Make Two Arrays Equal by Reversing Subarrays - Easy
    /// <a href="https://leetcode.com/problems/make-two-arrays-equal-by-reversing-subarrays">See the problem</a>
    /// </summary>
    public bool CanBeEqual(int[] target, int[] arr)
    {
        if (target.Length != arr.Length)
            return false;

        var count = new Dictionary<int, int>();

        foreach (var num in target)
        {
            if (count.ContainsKey(num))
                count[num]++;
            else
                count[num] = 1;
        }

        foreach (var num in arr)
        {
            if (count.ContainsKey(num))
            {
                count[num]--;
                if (count[num] == 0)
                    count.Remove(num);
            }
            else
                return false;
        }

        return count.Count == 0;
    }
}
