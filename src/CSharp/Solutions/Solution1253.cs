using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1253
{
    /// <summary>
    /// 1253. Reconstruct a 2-Row Binary Matrix - Medium
    /// <a href="https://leetcode.com/problems/reconstruct-a-2-row-binary-matrix">See the problem</a>
    /// </summary>
    public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
    {
        var result = new List<IList<int>>();
        var row1 = new int[colsum.Length];
        var row2 = new int[colsum.Length];

        for (int i = 0; i < colsum.Length; i++)
        {
            if (colsum[i] == 2)
            {
                if (upper > 0 && lower > 0)
                {
                    row1[i] = 1;
                    row2[i] = 1;
                    upper--;
                    lower--;
                }
                else
                {
                    return [];
                }
            }
            else if (colsum[i] == 1)
            {
                if (upper > lower)
                {
                    row1[i] = 1;
                    upper--;
                }
                else
                {
                    row2[i] = 1;
                    lower--;
                }
            }
        }

        if (upper == 0 && lower == 0)
        {
            result.Add(row1.ToList());
            result.Add(row2.ToList());
            return result;
        }

        return [];
    }
}
