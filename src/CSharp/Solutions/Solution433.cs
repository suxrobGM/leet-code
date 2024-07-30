namespace LeetCode.Solutions;

public class Solution433
{
    /// <summary>
    /// 433. Minimum Genetic Mutation - Medium
    /// <a href="https://leetcode.com/problems/minimum-genetic-mutation">See the problem</a>
    /// </summary>
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        var bankSet = new HashSet<string>(bank);

        if (!bankSet.Contains(endGene))
        {
            return -1;
        }

        var queue = new Queue<string>();
        queue.Enqueue(startGene);

        var mutations = 0;
        while (queue.Count > 0)
        {
            var size = queue.Count;
            for (var i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                if (current == endGene)
                {
                    return mutations;
                }

                foreach (var next in GetNextMutations(current, bankSet))
                {
                    queue.Enqueue(next);
                }
            }

            mutations++;
        }

        return -1;
    }

    private IEnumerable<string> GetNextMutations(string current, HashSet<string> bank)
    {
        var mutations = new List<string>();
        var chars = new[] { 'A', 'C', 'G', 'T' };
        foreach (var i in Enumerable.Range(0, current.Length))
        {
            foreach (var c in chars)
            {
                if (current[i] == c)
                {
                    continue;
                }

                var mutation = current[..i] + c + current[(i + 1)..];

                if (!bank.Contains(mutation))
                {
                    continue;
                }

                bank.Remove(mutation);
                mutations.Add(mutation);
            }
        }

        return mutations;
    }
}
