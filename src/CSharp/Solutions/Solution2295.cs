namespace LeetCode.Solutions;

public class Solution2295
{
    /// <summary>
    /// 2295. Replace Elements in an Array - Medium
    /// <a href="https://leetcode.com/problems/replace-elements-in-an-array">See the problem</a>
    /// </summary>
    public int[] ArrayChange(int[] nums, int[][] operations)
    {
        var indexMap = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            indexMap[nums[i]] = i;
        }

        foreach (var op in operations)
        {
            var index = indexMap[op[0]];
            nums[index] = op[1];
            indexMap.Remove(op[0]);
            indexMap[op[1]] = index;
        }

        return nums;
    }
}
