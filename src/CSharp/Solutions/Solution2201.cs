namespace LeetCode.Solutions;

public class Solution2201
{
    /// <summary>
    /// 2201. Count Artifacts That Can Be Extracted - Medium
    /// <a href="https://leetcode.com/problems/count-artifacts-that-can-be-extracted">See the problem</a>
    /// </summary>
    public int DigArtifacts(int n, int[][] artifacts, int[][] dig)
    {
        var digged = new bool[n, n];

        // Mark all dug cells
        foreach (var d in dig)
        {
            digged[d[0], d[1]] = true;
        }

        var count = 0;

        // Check each artifact
        foreach (var artifact in artifacts)
        {
            var (r1, c1, r2, c2) = (artifact[0], artifact[1], artifact[2], artifact[3]);
            var canExtract = true;

            // Check if all cells of the artifact are dug
            for (int i = r1; i <= r2; i++)
            {
                for (int j = c1; j <= c2; j++)
                {
                    if (!digged[i, j])
                    {
                        canExtract = false;
                        break;
                    }
                }

                if (!canExtract) break;
            }

            if (canExtract) count++;
        }

        return count;
    }
}
