namespace LeetCode.Solutions;

public class Solution2179
{
    /// <summary>
    /// 2179. Count Good Triplets in an Array - Hard
    /// <a href="https://leetcode.com/problems/count-good-triplets-in-an-array">See the problem</a>
    /// </summary>
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;

        // Map each value to its position in nums2.
        var pos2 = new int[n];
        for (var i = 0; i < n; i++)
        {
            pos2[nums2[i]] = i;
        }

        // Fenwick tree over nums2 positions to count, for each element treated as the
        // middle of a triplet, how many already-seen elements precede it in both arrays.
        var tree = new int[n + 1];
        long result = 0;

        for (var i = 0; i < n; i++)
        {
            var p = pos2[nums1[i]];

            // Elements seen so far (before i in nums1) whose nums2 position is < p.
            long less = Query(tree, p);

            // Elements after i in nums1 whose nums2 position is > p.
            // Total values with nums2 position > p is (n - 1 - p); subtract those already seen.
            var greater = n - 1 - p - (i - less);

            result += less * greater;

            Update(tree, p + 1, n);
        }

        return result;
    }

    private static long Query(int[] tree, int index)
    {
        // Prefix sum over Fenwick positions [1, index] = count of nums2 positions < p.
        long sum = 0;
        for (; index > 0; index -= index & -index)
        {
            sum += tree[index];
        }

        return sum;
    }

    private static void Update(int[] tree, int index, int n)
    {
        for (; index <= n; index += index & -index)
        {
            tree[index]++;
        }
    }
}
