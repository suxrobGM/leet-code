namespace LeetCode.Solutions;

public class Solution457
{
    /// <summary>
    /// 457. Circular Array Loop - Medium
    /// <a href="https://leetcode.com/problems/circular-array-loop">See the problem</a>
    /// </summary>
    public bool CircularArrayLoop(int[] nums) 
    {
        int n = nums.Length;

        int NextIndex(int current, int[] nums)
        {
            int next = ((current + nums[current]) % n + n) % n; // ensure the index is within bounds
            return next;
        }

        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                continue; // already processed
            }

            // slow and fast pointers
            int slow = i, fast = i;
            bool isForward = nums[i] > 0;

            while (true)
            {
                // move slow pointer one step
                slow = NextIndex(slow, nums);
                if (nums[slow] == 0 || (nums[slow] > 0 != isForward)) 
                {
                    break;
                }

                // move fast pointer two steps
                fast = NextIndex(fast, nums);
                if (nums[fast] == 0 || (nums[fast] > 0 != isForward)) 
                {
                    break;
                }

                fast = NextIndex(fast, nums);
                if (nums[fast] == 0 || (nums[fast] > 0 != isForward)) 
                {
                    break;
                }
                // if slow meets fast, we have found a cycle
                if (slow == fast)
                {
                    // check for cycle length greater than 1
                    if (slow == NextIndex(slow, nums)) 
                    {
                        break; // single element loop, invalid
                    }

                    return true;
                }
            }

            // mark all nodes visited in this loop as 0 (processed)
            int index = i;
            while (nums[index] != 0)
            {
                int next = NextIndex(index, nums);
                nums[index] = 0;
                index = next;
            }
        }

        return false;
    }
}
