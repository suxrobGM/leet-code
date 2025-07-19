using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1643
{
    /// <summary>
    /// 1643. Kth Smallest Instructions - Hard
    /// <a href="https://leetcode.com/problems/kth-smallest-instructions">See the problem</a>
    /// </summary>
    public string KthSmallestPath(int[] destination, int k)
    {
        int row = destination[0], col = destination[1];
        int total = row + col;
        int H = col, V = row;
        var result = new StringBuilder();

        while (H > 0 || V > 0)
        {
            if (H == 0)
            {
                result.Append('V');
                V--;
            }
            else if (V == 0)
            {
                result.Append('H');
                H--;
            }
            else
            {
                // Calculate how many sequences begin with 'H'
                int count = (int)Comb(H + V - 1, H - 1);
                if (k <= count)
                {
                    result.Append('H');
                    H--;
                }
                else
                {
                    result.Append('V');
                    k -= count;
                    V--;
                }
            }
        }

        return result.ToString();
    }

    private long Comb(int n, int k)
    {
        if (k < 0 || k > n) return 0;
        if (k == 0 || k == n) return 1;

        long res = 1;
        for (int i = 1; i <= k; i++)
        {
            res = res * (n - i + 1) / i;
        }
        return res;
    }
}
