namespace LeetCode.Solutions;

public class Solution373
{
    /// <summary>
    /// 373. Find K Pairs with Smallest Sums - Medium
    /// <a href="https://leetcode.com/problems/find-k-pairs-with-smallest-sums">See the problem</a>
    /// </summary>
    public int[][] KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var result = new List<int[]>();
        var heap = new SortedSet<(int sum, int i, int j)>(Comparer<(int sum, int i, int j)>.Create((a, b) => a.sum == b.sum ? a.i == b.i ? a.j.CompareTo(b.j) : a.i.CompareTo(b.i) : a.sum.CompareTo(b.sum)));

        if (nums1.Length == 0 || nums2.Length == 0)
        {
            return result.ToArray();
        }

        for (var i = 0; i < nums1.Length && i < k; i++)
        {
            heap.Add((nums1[i] + nums2[0], i, 0));
        }

        while (k-- > 0 && heap.Count > 0)
        {
            var (sum, i, j) = heap.Min;
            heap.Remove(heap.Min);

            result.Add(new[] {nums1[i], nums2[j]});

            if (j + 1 < nums2.Length)
            {
                heap.Add((nums1[i] + nums2[j + 1], i, j + 1));
            }
        }

        return result.ToArray();
    }
}
