using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1187
{
    /// <summary>
    /// 1187. Make Array Strictly Increasing - Hard
    /// <a href="https://leetcode.com/problems/make-array-strictly-increasing">See the problem</a>
    /// </summary>
    public int MakeArrayIncreasing(int[] arr1, int[] arr2)
    {
        Array.Sort(arr2);
        var sortedArr2 = new List<int>();

        // Remove duplicates
        foreach (int num in arr2)
        {
            if (sortedArr2.Count == 0 || sortedArr2[^1] != num)
                sortedArr2.Add(num);
        }

        var memo = new Dictionary<(int, int), int>();
        int result = Dfs(0, -1);

        return result == int.MaxValue ? -1 : result;

        int Dfs(int i, int prev)
        {
            if (i == arr1.Length) return 0;
            if (memo.ContainsKey((i, prev))) return memo[(i, prev)];

            int minOps = int.MaxValue;

            // Option 1: Keep arr1[i] if valid
            if (arr1[i] > prev)
            {
                int keep = Dfs(i + 1, arr1[i]);
                minOps = Math.Min(minOps, keep);
            }

            // Option 2: Replace arr1[i] with a higher element from arr2
            int idx = UpperBound(sortedArr2, prev);
            if (idx < sortedArr2.Count)
            {
                int replace = Dfs(i + 1, sortedArr2[idx]);
                if (replace != int.MaxValue)
                    minOps = Math.Min(minOps, 1 + replace);
            }

            memo[(i, prev)] = minOps;
            return minOps;
        }

        int UpperBound(List<int> list, int val)
        {
            int l = 0, r = list.Count;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (list[m] <= val)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }
    }
}
