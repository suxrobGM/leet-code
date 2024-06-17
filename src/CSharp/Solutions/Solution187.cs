using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution187
{
    /// <summary>
    /// 187. Repeated DNA Sequences - Medium
    /// <a href="https://leetcode.com/problems/repeated-dna-sequences">See the problem</a>
    /// </summary>
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        var sequences = new Dictionary<string, int>();
        var result = new List<string>();

        for (int i = 0; i <= s.Length - 10; i++)
        {
            var sequence = s.Substring(i, 10);
            if (sequences.ContainsKey(sequence))
            {
                sequences[sequence]++;
                if (sequences[sequence] == 2)
                {
                    result.Add(sequence);
                }
            }
            else
            {
                sequences[sequence] = 1;
            }
        }

        return result;
    }
}
