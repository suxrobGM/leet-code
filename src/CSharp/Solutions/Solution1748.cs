using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1748
{
    /// <summary>
    /// 1748. Sum of Unique Elements - Easy
    /// <a href="https://leetcode.com/problems/sum-of-unique-elements">See the problem</a>
    /// </summary>
    public int SumOfUnique(int[] nums)
    {
        int[] freq = new int[101]; // since 1 <= nums[i] <= 100

        foreach (int num in nums)
        {
            freq[num]++;
        }

        int sum = 0;
        for (int i = 1; i <= 100; i++)
        {
            if (freq[i] == 1)
            {
                sum += i;
            }
        }

        return sum;
    }
}

