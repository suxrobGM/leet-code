using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1738
{
    const int MOD = 1_000_000_007;

    /// <summary>
    /// 1738. Find Kth Largest XOR Coordinate Value - Medium
    /// <a href="https://leetcode.com/problems/find-kth-largest-xor-coordinate-value">See the problem</a>
    /// </summary>
    public int KthLargestValue(int[][] matrix, int k)
    {
        int m = matrix.Length, n = matrix[0].Length;

        // prefix XOR, reusing a 2D array (or two 1D rows would also work)
        int[,] px = new int[m, n];

        // Min-heap of size at most k; store values with priority = value
        var heap = new PriorityQueue<int, int>();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int val = matrix[i][j];
                if (i > 0) val ^= px[i - 1, j];
                if (j > 0) val ^= px[i, j - 1];
                if (i > 0 && j > 0) val ^= px[i - 1, j - 1];

                px[i, j] = val;

                if (heap.Count < k)
                {
                    heap.Enqueue(val, val);
                }
                else if (val > heap.Peek())
                {
                    heap.Dequeue();
                    heap.Enqueue(val, val);
                }
            }
        }

        return heap.Peek(); // the k-th largest
    }
}

