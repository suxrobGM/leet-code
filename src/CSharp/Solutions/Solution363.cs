namespace LeetCode.Solutions;

public class Solution363
{
    /// <summary>
    /// 363. Max Sum of Rectangle No Larger Than K - Hard
    /// <a href="https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k">See the problem</a>
    /// </summary>
    public int MaxSumSubmatrix(int[][] matrix, int k)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var result = int.MinValue;

        for (var l = 0; l < cols; l++)
        {
            var sums = new int[rows];

            for (var r = l; r < cols; r++)
            {
                for (var i = 0; i < rows; i++)
                {
                    sums[i] += matrix[i][r];
                }

                var set = new SortedSet<int> {0};
                var sum = 0;

                foreach (var s in sums)
                {
                    sum += s;
                    var ceil = set.GetViewBetween(sum - k, sum - k).Min;

                    if (ceil != null)
                    {
                        result = Math.Max(result, sum - ceil);
                    }

                    set.Add(sum);
                }
            }
        }

        return result;
    }
}
