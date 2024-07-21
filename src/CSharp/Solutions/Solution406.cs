using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution406
{
    /// <summary>
    /// 406. Queue Reconstruction by Height - Medium
    /// <a href="https://leetcode.com/problems/queue-reconstruction-by-height">See the problem</a>
    /// </summary>
    public int[][] ReconstructQueue(int[][] people)
    {
        Array.Sort(people, (a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : b[0].CompareTo(a[0]));

        var result = new List<int[]>();
        foreach (var person in people)
        {
            result.Insert(person[1], person);
        }

        return result.ToArray();
    }
}
