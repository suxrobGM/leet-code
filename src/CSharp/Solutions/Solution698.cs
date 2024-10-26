using System.Text;

namespace LeetCode.Solutions;

public class Solution698
{
    /// <summary>
    /// 698. Partition to K Equal Sum Subsets - Medium
    /// <a href="https://leetcode.com/problems/partition-to-k-equal-sum-subsets">See the problem</a>
    /// </summary>
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        var sum = nums.Sum();
        if (sum % k != 0)
        {
            return false;
        }

        var target = sum / k;
        var visited = new bool[nums.Length];
        return CanPartition(nums, visited, 0, k, 0, target);
    }

    private bool CanPartition(int[] nums, bool[] visited, int start, int k, int currentSum, int target)
    {
        if (k == 1)
        {
            return true;
        }

        if (currentSum == target)
        {
            return CanPartition(nums, visited, 0, k - 1, 0, target);
        }

        for (var i = start; i < nums.Length; i++)
        {
            if (!visited[i] && currentSum + nums[i] <= target)
            {
                visited[i] = true;
                
                if (CanPartition(nums, visited, i + 1, k, currentSum + nums[i], target))
                {
                    return true;
                }

                visited[i] = false;
            }
        }

        return false;
    }
}
