using System.Text;

namespace LeetCode.Solutions;

public class Solution710
{
    /// <summary>
    /// 710. Random Pick with Blacklist - Hard
    /// <a href="https://leetcode.com/problems/random-pick-with-blacklist">See the problem</a>
    /// </summary>
    public class Solution
    {
        private Random random = new();
        private Dictionary<int, int> mapping = [];
        private int range;

        public Solution(int n, int[] blacklist)
        {
            var m = n - blacklist.Length;
            range = m;

            var blacklistedSet = new HashSet<int>(blacklist);

            // Create a set of potential values we can remap to, starting from [m, n - 1]
            var remapIndex = m;
            foreach (var b in blacklist)
            {
                // If the blacklisted number is within our range [0, m - 1], we need to remap it
                if (b < m)
                {
                    // Find the next number in [m, n - 1] that is not blacklisted
                    while (blacklistedSet.Contains(remapIndex))
                    {
                        remapIndex++;
                    }
                    mapping[b] = remapIndex;  // Map blacklisted index in range to a valid index
                    remapIndex++;
                }
            }
        }

        public int Pick()
        {
            // Generate a random number in range [0, range - 1]
            var x = random.Next(range);
            // Return the mapped value if x is blacklisted, otherwise return x itself
            return mapping.ContainsKey(x) ? mapping[x] : x;
        }
    }
}
