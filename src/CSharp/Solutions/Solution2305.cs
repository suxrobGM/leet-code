using System.Text;

namespace LeetCode.Solutions;

public class Solution2305
{
    /// <summary>
    /// 2305. Fair Distribution of Cookies - Medium
    /// <a href="https://leetcode.com/problems/fair-distribution-of-cookies">See the problem</a>
    /// </summary>
    public int DistributeCookies(int[] cookies, int k)
    {
        // Sort in descending order so large bags are placed first, which prunes faster
        Array.Sort(cookies, (a, b) => b.CompareTo(a));

        int[] children = new int[k];
        int result = int.MaxValue;

        void Backtrack(int index, int currentMax)
        {
            // Prune branches that can't beat the best unfairness found so far
            if (currentMax >= result)
            {
                return;
            }

            if (index == cookies.Length)
            {
                result = currentMax;
                return;
            }

            for (int i = 0; i < k; i++)
            {
                children[i] += cookies[index];
                Backtrack(index + 1, Math.Max(currentMax, children[i]));
                children[i] -= cookies[index];

                // Giving the bag to any other empty child is an equivalent state
                if (children[i] == 0)
                {
                    break;
                }
            }
        }

        Backtrack(0, 0);
        return result;
    }
}
