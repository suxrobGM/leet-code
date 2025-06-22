using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1562
{
    /// <summary>
    /// 1562. Find Latest Group of Size M - Medium
    /// <a href="https://leetcode.com/problems/find-latest-group-of-size-m">See the problem</a>
    /// </summary>
    public int FindLatestStep(int[] arr, int m)
    {
        int n = arr.Length;
        if (m == n)
            return n;

        int[] lengths = new int[n + 2]; // group length boundaries
        Dictionary<int, int> count = []; // group size -> count
        int res = -1;

        for (int step = 0; step < n; step++)
        {
            int i = arr[step];
            int left = lengths[i - 1];
            int right = lengths[i + 1];
            int total = left + right + 1;

            lengths[i - left] = total;
            lengths[i + right] = total;

            // update count map
            if (left > 0)
            {
                count[left]--;
                if (count[left] == 0)
                    count.Remove(left);
            }
            if (right > 0)
            {
                count[right]--;
                if (count[right] == 0)
                    count.Remove(right);
            }

            if (!count.ContainsKey(total))
                count[total] = 0;
            count[total]++;

            if (count.ContainsKey(m))
                res = step + 1;
        }

        return res;
    }
}
