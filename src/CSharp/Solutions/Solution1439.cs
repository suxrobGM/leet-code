namespace LeetCode.Solutions;

public class Solution1439
{
    /// <summary>
    /// 1439. Find the Kth Smallest Sum of a Matrix With Sorted Rows - Hard
    /// <a href="https://leetcode.com/problems/find-the-kth-smallest-sum-of-a-matrix-with-sorted-rows">See the problem</a>
    /// </summary>
    public int KthSmallest(int[][] mat, int k)
    {
        int m = mat.Length;
        var comparer = Comparer<(int sum, int[] indices)>.Create((a, b) => a.sum - b.sum);
        var pq = new PriorityQueue<(int sum, int[] indices), int>();
        var visited = new HashSet<string>();

        int sum0 = 0;
        var startIndices = new int[m];

        for (int i = 0; i < m; i++)
            sum0 += mat[i][0];

        pq.Enqueue((sum0, startIndices), sum0);
        visited.Add(string.Join(",", startIndices));

        while (pq.Count > 0)
        {
            var (sum, indices) = pq.Dequeue();
            k--;
            if (k == 0) return sum;

            for (int i = 0; i < m; i++)
            {
                int[] newIndices = (int[])indices.Clone();
                if (newIndices[i] + 1 < mat[i].Length)
                {
                    newIndices[i]++;
                    int newSum = sum - mat[i][indices[i]] + mat[i][newIndices[i]];
                    string key = string.Join(",", newIndices);
                    if (!visited.Contains(key))
                    {
                        visited.Add(key);
                        pq.Enqueue((newSum, newIndices), newSum);
                    }
                }
            }
        }

        return -1;
    }
}
