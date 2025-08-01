using System.Text;


namespace LeetCode.Solutions;

public class Solution1679
{
    /// <summary>
    /// 1679. Max Number of K-Sum Pairs - Medium
    /// <a href="https://leetcode.com/problems/max-number-of-k-sum-pairs">See the problem</a>
    /// </summary>
    public int MaxOperations(int[] nums, int k)
    {
        var countMap = new Dictionary<int, int>();
        int operations = 0;

        foreach (int num in nums)
        {
            int complement = k - num;

            if (countMap.ContainsKey(complement) && countMap[complement] > 0)
            {
                operations++;
                countMap[complement]--;
            }
            else
            {
                if (!countMap.ContainsKey(num))
                    countMap[num] = 0;
                countMap[num]++;
            }
        }

        return operations;
    }
}
