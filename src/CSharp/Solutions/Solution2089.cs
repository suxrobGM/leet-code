namespace LeetCode.Solutions;

public class Solution2089
{
    /// <summary>
    /// 2089. Find Target Indices After Sorting Array - Easy
    /// <a href="https://leetcode.com/problems/find-target-indices-after-sorting-array">See the problem</a>
    /// </summary>
    public IList<int> TargetIndices(int[] nums, int target)
    {
        var result = new List<int>();
        var countLess = 0;
        var countEqual = 0;

        foreach (var num in nums)
        {
            if (num < target)
                countLess++;
            else if (num == target)
                countEqual++;
        }

        for (var i = countLess; i < countLess + countEqual; i++)
            result.Add(i);

        return result;
    }
}
