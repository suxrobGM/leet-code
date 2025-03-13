using System.Text;

namespace LeetCode.Solutions;

public class Solution1093
{
    /// <summary>
    /// 1093. Statistics from a Large Sample - Medium
    /// <a href="https://leetcode.com/problems/statistics-from-a-large-sample">See the problem</a>
    /// </summary>
    public double[] SampleStats(int[] count)
    {
        var listCount = count.ToList();
        var min = listCount.FindIndex(m => m == count.FirstOrDefault(c => c > 0));
        var max = listCount.FindLastIndex(m => m == count.LastOrDefault(c => c > 0));

        var listWithValues = listCount.Where(c => c > 0).ToList();

        var pro = 0d;
        var sum = listCount.Sum();
        var lastIndex = -1;

        foreach (var i in listWithValues)
        {
            pro += (double)i * listCount.IndexOf(i, lastIndex + 1);
            lastIndex = listCount.IndexOf(i);
        }

        var mean = pro / sum;
        var median = FindMedian(count, sum);
        var mode = listCount.FindIndex(m => m == count.Max());
        return [ min, max, mean, median, mode ];
    }
    
    public double FindMedian(int[] count, double sum)
    {
        var cumalativeCount = 0;
        double median1 = -1, median2 = -1;

        for (var i = 0; i <= count.Length; i++)
        {
            if (count[i] > 0)
            {
                cumalativeCount += count[i];

                if (median1 == -1 && cumalativeCount >= sum / 2)
                {
                    median1 = i;
                }
                if (cumalativeCount >= (sum + 1) / 2)
                {
                    median2 = i;
                    break;
                }
            }
        }
        if (sum % 2 == 0)
        {
            return (median1 + median2) / 2;
        }
        return median2;
    }
}
