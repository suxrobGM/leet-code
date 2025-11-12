using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1899
{
    /// <summary>
    /// 1899. Merge Triplets to Form Target Triplet - Medium
    /// <a href="https://leetcode.com/problems/merge-triplets-to-form-target-triplet">See the problem</a>
    /// </summary>
    public bool MergeTriplets(int[][] triplets, int[] target)
    {
        var found = new bool[3];

        foreach (var triplet in triplets)
        {
            if (triplet[0] > target[0] || triplet[1] > target[1] || triplet[2] > target[2])
                continue;

            for (int i = 0; i < 3; i++)
            {
                if (triplet[i] == target[i])
                {
                    found[i] = true;
                }
            }
        }

        return found[0] && found[1] && found[2];
    }
}
