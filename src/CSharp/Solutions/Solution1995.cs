namespace LeetCode.Solutions;

public class Solution1995
{
    /// <summary>
    /// 1995. Count Special Quadruplets - Easy
    /// <a href="https://leetcode.com/problems/count-special-quadruplets">See the problem</a>
    /// </summary>
    public int CountQuadruplets(int[] nums)
    {
        int n = nums.Length;
        int count = 0;

        for (int a = 0; a < n - 3; a++)
        {
            for (int b = a + 1; b < n - 2; b++)
            {
                for (int c = b + 1; c < n - 1; c++)
                {
                    for (int d = c + 1; d < n; d++)
                    {
                        if (nums[a] + nums[b] + nums[c] == nums[d])
                        {
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }
}
