namespace LeetCode.Solutions;

public class Solution16
{
    /// <summary>
    /// Problem #16
    /// <a href="https://leetcode.com/problems/3sum-closest/">See the problem</a>
    /// </summary>
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums); // sort array first
        var minSum = nums[0] + nums[1] + nums[2]; // since the length of nums are always greater or equal to 3 so safely add the first 3 nums

        for (var i = 0; i < nums.Length - 2; i++)
        {
            // To avoid counting the same number more than once
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                var distance = Math.Abs(sum - target);
                
                if (distance == 0)
                {
                    return target;
                }
                
                var minDistance = Math.Abs(minSum - target);

                if (distance < minDistance)
                {
                    minSum = sum;
                }

                // move pointers
                if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }
        
        return minSum;
    }
}
