namespace LeetCode.Solutions;

public class Solution2164
{
    /// <summary>
    /// 2164. Sort Even and Odd Indices Independently - Easy
    /// <a href="https://leetcode.com/problems/sort-even-and-odd-indices-independently">See the problem</a>
    /// </summary>
    public int[] SortEvenOdd(int[] nums)
    {
        int n = nums.Length;
        List<int> even = [], odd = [];
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0) even.Add(nums[i]);
            else odd.Add(nums[i]);
        }
        even.Sort();                       // even indices ascending
        odd.Sort((a, b) => b - a);         // odd indices descending

        int[] result = new int[n];
        for (int i = 0, e = 0, o = 0; i < n; i++)
        {
            if (i % 2 == 0) result[i] = even[e++];
            else result[i] = odd[o++];
        }
        return result;
    }
}
