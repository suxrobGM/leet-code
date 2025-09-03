using System.Text;

namespace LeetCode.Solutions;

public class Solution1792
{
    /// <summary>
    /// 1792. Maximum Average Pass Ratio - Medium
    /// <a href="https://leetcode.com/problems/maximum-average-pass-ratio">See the problem</a>
    /// </summary>
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        var pq = new PriorityQueue<(int pass, int total), double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));

        foreach (var c in classes)
        {
            int pass = c[0], total = c[1];
            pq.Enqueue((pass, total), Gain(pass, total));
        }

        for (int i = 0; i < extraStudents; i++)
        {
            var (p, t) = pq.Dequeue();
            p++; t++;
            pq.Enqueue((p, t), Gain(p, t));
        }

        double sum = 0;
        while (pq.Count > 0)
        {
            var (p, t) = pq.Dequeue();
            sum += (double)p / t;
        }

        return sum / classes.Length;
    }

    private double Gain(int pass, int total)
    {
        return (double)(pass + 1) / (total + 1) - (double)pass / total;
    }
}

