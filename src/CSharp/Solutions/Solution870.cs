using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution870
{
    /// <summary>
    /// 870. Advantage Shuffle - Medium
    /// <a href="https://leetcode.com/problems/advantage-shuffle">See the problem</a>
    /// </summary>
    public int[] AdvantageCount(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;
        var result = new int[n];
        var sortedNums1 = new int[n];
        var sortedNums2 = new int[n];
        Array.Copy(nums1, sortedNums1, n);
        Array.Copy(nums2, sortedNums2, n);
        Array.Sort(sortedNums1);
        Array.Sort(sortedNums2);

        var map = new Dictionary<int, Queue<int>>();
        var remaining = new Queue<int>();

        int i = 0;
        int j = 0;

        while (i < n && j < n)
        {
            if (sortedNums1[i] > sortedNums2[j])
            {
                if (!map.ContainsKey(sortedNums2[j]))
                {
                    map[sortedNums2[j]] = new Queue<int>();
                }

                map[sortedNums2[j]].Enqueue(sortedNums1[i]);
                i++;
                j++;
            }
            else
            {
                remaining.Enqueue(sortedNums1[i]);
                i++;
            }
        }

        while (i < n)
        {
            remaining.Enqueue(sortedNums1[i]);
            i++;
        }

        for (int k = 0; k < n; k++)
        {
            if (map.ContainsKey(nums2[k]) && map[nums2[k]].Count > 0)
            {
                result[k] = map[nums2[k]].Dequeue();
            }
            else
            {
                result[k] = remaining.Dequeue();
            }
        }

        return result;
    }
}
