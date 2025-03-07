using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1054
{
    /// <summary>
    /// 1054. Distant Barcodes - Medium
    /// <a href="https://leetcode.com/problems/distant-barcodes"</a>
    /// </summary>
    public int[] RearrangeBarcodes(int[] barcodes)
    {
        var n = barcodes.Length;
        var map = new Dictionary<int, int>();

        foreach (var barcode in barcodes)
        {
            map[barcode] = map.GetValueOrDefault(barcode, 0) + 1;
        }

        var sorted = map.OrderByDescending(x => x.Value).SelectMany(x => Enumerable.Repeat(x.Key, x.Value)).ToArray();
        var result = new int[n];
        var index = 0;

        for (var i = 0; i < n; i += 2)
        {
            result[i] = sorted[index++];

            if (index >= n)
            {
                index = 1;
            }
        }

        for (var i = 1; i < n; i += 2)
        {
            result[i] = sorted[index++];

            if (index >= n)
            {
                index = 1;
            }
        }

        return result;
    }
}
